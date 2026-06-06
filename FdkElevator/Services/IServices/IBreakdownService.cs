using FdkElevator.DTOS.ComplaintDTOS;
using FdkElevator.Models.Complaints;

namespace FdkElevator.Services.IServices
{
    public interface IBreakdownService
    {

        Task<BreakdownComplaint> LogComplaintAsync(CreateComplaintDto dto);

        Task<BreakdownComplaint> AssignPriorityAndSLAAsync(Guid complaintId, ComplaintPriority priority);

       
        Task<BreakdownDispatch> DispatchTechnicianAsync(Guid complaintId, DispatchTechnicianDto dto);
        
        Task<TechnicianDiagnosis> SubmitDiagnosisAsync(Guid complaintId, SubmitDiagnosisDto dto);
        Task AddDiagnosisMediaAsync(Guid diagnosisId, List<string> mediaUrls);
        Task AddSparePartsAsync(Guid diagnosisId, List<SparePartDto> parts);

      
        Task<RepairQuotation> CreateQuotationAsync(Guid complaintId, CreateQuotationDto dto);
        Task<RepairQuotation> UpdateQuotationStatusAsync(Guid quotationId, ComplaintQuotationStatus status);
        Task UpdateJobStatusAsync(Guid complaintId, BreakdownJobStatus status);

      
        Task<JobClosure> CloseJobAsync(Guid complaintId, CloseJobDto dto);

       
        Task<RootCauseAnalysis> SubmitRCAAsync(Guid complaintId, SubmitRCADto dto);

        Task<BreakdownComplaintSummaryDto> GetComplaintSummaryAsync(Guid complaintId);
        Task<List<BreakdownComplaintSummaryDto>> GetComplaintsByProjectAsync(Guid projectId);
        Task<List<BreakdownComplaintSummaryDto>> GetOpenComplaintsAsync();
        Task MonitorSLABreachesAsync();
    }
}
