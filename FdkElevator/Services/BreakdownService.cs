using AutoMapper;
using FdkElevator.AppDbContext;
using FdkElevator.DTOS.ComplaintDTOS;
using FdkElevator.Models.Complaints;
using FdkElevator.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace FdkElevator.Services
{
    public class BreakdownService : IBreakdownService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BreakdownService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // ── ① Intake ─────────────────────────────────────
        public async Task<BreakdownComplaint> LogComplaintAsync(CreateComplaintDto dto)
        {
            var priority = dto.PassengerTrapped
                ? ComplaintPriority.Emergency
                : ResolvePriority(dto.FaultType, dto.IsAMCClient);

            var slaConfig = await _context.SLAConfigurations
                .FirstOrDefaultAsync(s => s.Priority == priority && s.IsAMC == dto.IsAMCClient);

            var now = DateTime.UtcNow;

            var complaint = _mapper.Map<BreakdownComplaint>(dto);
            complaint.Priority = priority;
            complaint.SLAConfigId = slaConfig?.Id;
            complaint.SLAResponseDeadline = slaConfig != null
                ? now.AddMinutes(slaConfig.ResponseTimeMinutes) : now.AddHours(24);
            complaint.SLAResolutionDeadline = slaConfig != null
                ? now.AddHours(slaConfig.ResolutionTimeHours) : now.AddHours(72);

            var repeatCount = await _context.breakdownComplaints
                .Where(c => c.ProjectId == dto.ProjectId
                         && c.FaultType == dto.FaultType
                         && c.Status == BreakdownJobStatus.Closed)
                .CountAsync();

            if (repeatCount > 0)
            {
                complaint.IsRepeatedFault = true;
                complaint.RepeatCount = repeatCount;
            }

            _context.breakdownComplaints.Add(complaint);
            await _context.SaveChangesAsync();
            return complaint;
        }

        // ── ③ Priority & SLA ─────────────────────────────
        public async Task<BreakdownComplaint> AssignPriorityAndSLAAsync(
            Guid complaintId, ComplaintPriority priority)
        {
            var complaint = await GetComplaintOrThrowAsync(complaintId);

            var slaConfig = await _context.SLAConfigurations
                .FirstOrDefaultAsync(s => s.Priority == priority
                                       && s.IsAMC == complaint.IsAMCClient);

            var now = DateTime.UtcNow;
            complaint.Priority = priority;
            complaint.SLAConfigId = slaConfig?.Id;
            complaint.SLAResponseDeadline = slaConfig != null
                ? now.AddMinutes(slaConfig.ResponseTimeMinutes) : now.AddHours(24);
            complaint.SLAResolutionDeadline = slaConfig != null
                ? now.AddHours(slaConfig.ResolutionTimeHours) : now.AddHours(72);

            await _context.SaveChangesAsync();
            return complaint;
        }

        // ── ④ Dispatch ───────────────────────────────────
        public async Task<BreakdownDispatch> DispatchTechnicianAsync(
            Guid complaintId, DispatchTechnicianDto dto)
        {
            var complaint = await GetComplaintOrThrowAsync(complaintId);

            var dispatch = _mapper.Map<BreakdownDispatch>(dto);
            dispatch.BreakdownComplaintId = complaintId;
            complaint.Status = BreakdownJobStatus.Dispatched;

            _context.breakdownDispatches.Add(dispatch);
            await _context.SaveChangesAsync();
            return dispatch;
        }



        // ── ⑤ Diagnosis ──────────────────────────────────
        public async Task<TechnicianDiagnosis> SubmitDiagnosisAsync(
            Guid complaintId, SubmitDiagnosisDto dto)
        {
            var complaint = await GetComplaintOrThrowAsync(complaintId);

            var diagnosis = _mapper.Map<TechnicianDiagnosis>(dto);
            diagnosis.BreakdownComplaintId = complaintId;

            if (dto.MediaUrls?.Any() == true)
            {
                diagnosis.Media = dto.MediaUrls.Select(url => new DiagnosisMedia
                {
                    Id = Guid.NewGuid(),
                    MediaURL = url,
                    UploadedAt = DateTime.UtcNow,
                }).ToList();
            }

            if (dto.SpareParts?.Any() == true)
                diagnosis.SparePartsNeeded = _mapper.Map<List<SparePartRequest>>(dto.SpareParts);

            complaint.Status = dto.SafetyStatus == SafetyStatus.UnsafeDoNotUse
                ? BreakdownJobStatus.AwaitingApproval
                : dto.SpareParts?.Any() == true
                    ? BreakdownJobStatus.AwaitingParts
                    : BreakdownJobStatus.DiagnosisInProgress;

            _context.technicianDiagnoses.Add(diagnosis);
            await _context.SaveChangesAsync();
            return diagnosis;
        }

        public async Task AddDiagnosisMediaAsync(Guid diagnosisId, List<string> mediaUrls)
        {
            var media = mediaUrls.Select(url => new DiagnosisMedia
            {
                Id = Guid.NewGuid(),
                TechnicianDiagnosisId = diagnosisId,
                MediaURL = url,
                UploadedAt = DateTime.UtcNow,
            });

            _context.diagnosisMedias.AddRange(media);
            await _context.SaveChangesAsync();
        }

        public async Task AddSparePartsAsync(Guid diagnosisId, List<SparePartDto> parts)
        {
            var spareParts = _mapper.Map<List<SparePartRequest>>(parts);
            spareParts.ForEach(s => s.TechnicianDiagnosisId = diagnosisId);

            _context.SparePartRequests.AddRange(spareParts);
            await _context.SaveChangesAsync();
        }

        // ── ⑥ Quotation ──────────────────────────────────
        public async Task<RepairQuotation> CreateQuotationAsync(
            Guid complaintId, CreateQuotationDto dto)
        {
            var complaint = await GetComplaintOrThrowAsync(complaintId);

            var quotation = _mapper.Map<RepairQuotation>(dto);
            quotation.BreakdownComplaintId = complaintId;
            quotation.LineItems = _mapper.Map<List<QuotationLineItem>>(dto.LineItems);
            complaint.Status = BreakdownJobStatus.AwaitingApproval;

            _context.RepairQuotations.Add(quotation);
            await _context.SaveChangesAsync();
            return quotation;
        }

        public async Task<RepairQuotation> UpdateQuotationStatusAsync(
            Guid quotationId, ComplaintQuotationStatus status)
        {
            var quotation = await _context.RepairQuotations
                .Include(q => q.BreakdownComplaint)
                .FirstOrDefaultAsync(q => q.Id == quotationId)
                ?? throw new KeyNotFoundException("Quotation not found.");

            quotation.Status = status;

            if (status == ComplaintQuotationStatus.Approved)
            {
                quotation.ApprovedDate = DateTime.UtcNow;
                quotation.BreakdownComplaint.Status = BreakdownJobStatus.RepairInProgress;
            }
            else if (status == ComplaintQuotationStatus.Rejected)
            {
                quotation.BreakdownComplaint.Status = BreakdownJobStatus.Cancelled;
            }

            await _context.SaveChangesAsync();
            return quotation;
        }

        // ── ⑦ Repair ─────────────────────────────────────
        public async Task UpdateJobStatusAsync(Guid complaintId, BreakdownJobStatus status)
        {
            var complaint = await GetComplaintOrThrowAsync(complaintId);
            complaint.Status = status;
            await _context.SaveChangesAsync();
        }

        // ── ⑧ Closure ────────────────────────────────────
        public async Task<JobClosure> CloseJobAsync(Guid complaintId, CloseJobDto dto)
        {
            var complaint = await GetComplaintOrThrowAsync(complaintId);

            var closure = _mapper.Map<JobClosure>(dto);
            closure.BreakdownComplaintId = complaintId;
            closure.RepeatedFaultFlagged = complaint.IsRepeatedFault;
            complaint.Status = BreakdownJobStatus.Completed;

            _context.JobClosures.Add(closure);
            await _context.SaveChangesAsync();
            return closure;
        }

        // ── ⑨ RCA ────────────────────────────────────────
        public async Task<RootCauseAnalysis> SubmitRCAAsync(
            Guid complaintId, SubmitRCADto dto)
        {
            var complaint = await GetComplaintOrThrowAsync(complaintId);

            var breakdownCount = await _context.breakdownComplaints
                .Where(c => c.ProjectId == complaint.ProjectId
                         && c.FaultType == complaint.FaultType
                         && c.ComplaintDateTime >= DateTime.UtcNow.AddDays(-90))
                .CountAsync();

            var rca = _mapper.Map<RootCauseAnalysis>(dto);
            rca.BreakdownComplaintId = complaintId;
            rca.ProjectId = complaint.ProjectId;
            rca.BreakdownCountLast90Days = breakdownCount;
            complaint.Status = BreakdownJobStatus.Closed;

            _context.RootCauseAnalyses.Add(rca);
            await _context.SaveChangesAsync();
            return rca;
        }

        // ── Queries ───────────────────────────────────────
        public async Task<BreakdownComplaintSummaryDto> GetComplaintSummaryAsync(Guid complaintId)
        {
            var complaint = await _context.breakdownComplaints
                .Include(x => x.Project)
                .Include(x => x.Dispatch).ThenInclude(d => d.Technician)
                .Include(x => x.Diagnosis).ThenInclude(d => d.Media)
                .Include(x => x.Diagnosis).ThenInclude(d => d.SparePartsNeeded)
                .Include(x => x.Quotation)
                .Include(x => x.JobClosure)
                .Include(x => x.RootCauseAnalysis)
                .FirstOrDefaultAsync(x => x.Id == complaintId)
                ?? throw new KeyNotFoundException("Complaint not found.");

            return _mapper.Map<BreakdownComplaintSummaryDto>(complaint);
        }

        public async Task<List<BreakdownComplaintSummaryDto>> GetComplaintsByProjectAsync(
            Guid projectId)
        {
            var complaints = await _context.breakdownComplaints
                .Where(c => c.ProjectId == projectId)
                .Include(x => x.Project)
                .Include(x => x.Dispatch).ThenInclude(d => d.Technician)
                .Include(x => x.Diagnosis)
                .Include(x => x.Quotation)
                .Include(x => x.JobClosure)
                .Include(x => x.RootCauseAnalysis)
                .OrderByDescending(c => c.ComplaintDateTime)
                .ToListAsync();

            return _mapper.Map<List<BreakdownComplaintSummaryDto>>(complaints);
        }

        public async Task<List<BreakdownComplaintSummaryDto>> GetOpenComplaintsAsync()
        {
            var closed = new[] { BreakdownJobStatus.Closed, BreakdownJobStatus.Cancelled };

            var complaints = await _context.breakdownComplaints
                .Where(c => !closed.Contains(c.Status))
                .Include(x => x.Project)
                .Include(x => x.Dispatch).ThenInclude(d => d.Technician)
                .Include(x => x.Diagnosis)
                .Include(x => x.Quotation)
                .Include(x => x.JobClosure)
                .OrderBy(c => c.Priority)
                .ThenBy(c => c.SLAResolutionDeadline)
                .ToListAsync();

            return _mapper.Map<List<BreakdownComplaintSummaryDto>>(complaints);
        }

        // ── SLA Monitor ───────────────────────────────────
        public async Task MonitorSLABreachesAsync()
        {
            var now = DateTime.UtcNow;
            var open = await _context.breakdownComplaints
                .Where(c => c.Status != BreakdownJobStatus.Closed
                         && c.Status != BreakdownJobStatus.Cancelled
                         && c.SLAStatus != SLAStatus.Breached)
                .ToListAsync();

            foreach (var c in open)
            {
                if (now > c.SLAResolutionDeadline)
                    c.SLAStatus = SLAStatus.Breached;
                else if (now > c.SLAResolutionDeadline.AddHours(-1))
                    c.SLAStatus = SLAStatus.AtRisk;
            }

            await _context.SaveChangesAsync();
        }

        // ── Helpers ───────────────────────────────────────
        private async Task<BreakdownComplaint> GetComplaintOrThrowAsync(Guid id) =>
            await _context.breakdownComplaints.FindAsync(id)
                ?? throw new KeyNotFoundException($"Complaint {id} not found.");

        private static ComplaintPriority ResolvePriority(FaultType fault, bool isAMC) =>
            fault switch
            {
                FaultType.TrappedPassenger => ComplaintPriority.Emergency,
                FaultType.LiftStopped => ComplaintPriority.High,
                FaultType.ControllerFault => ComplaintPriority.High,
                FaultType.PowerIssue => ComplaintPriority.High,
                FaultType.DoorFault => isAMC ? ComplaintPriority.Medium : ComplaintPriority.High,
                FaultType.LevelingProblem => ComplaintPriority.Medium,
                FaultType.AlarmIntercomIssue => ComplaintPriority.Medium,
                FaultType.MechanicalIssue => ComplaintPriority.Medium,
                FaultType.WaterIngress => ComplaintPriority.Medium,
                FaultType.Vandalism => ComplaintPriority.Low,
                FaultType.NoiseVibration => ComplaintPriority.Low,
                _ => ComplaintPriority.Low,
            };

     
    }
}
