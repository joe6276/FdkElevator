using FdkElevator.AppDbContext;
using FdkElevator.Models.Projects;
using FdkElevator.Services.IServices;
using Microsoft.EntityFrameworkCore;
using static FdkElevator.DTOS.ProjectDTOS.ProjectMaintenanceDTO;

namespace FdkElevator.Services
{
    public class ProjectMaintenanceService : IProjectMaintenance
    {
        private readonly ApplicationDbContext _context;
        public ProjectMaintenanceService(ApplicationDbContext context)
        {
            _context = context;
        }

        public string addMaintenanceSchedule(List<MaintenanceSchedule> schedule)
        {
            _context.maintenanceSchedules.AddRange(schedule);
            _context.SaveChanges();
            return "Maintenance Schedule added successfully";
        }

        public string addpayment(List<ProjectMaintenancePayment> payments)
        {
            foreach (var payment in payments)
            {

                var projectMaintenance = payment.ProjectMaintenanceId;
                var projectId = _context.projectMaintenances.Select(x => x.ProjectId).SingleOrDefault();

                var project = _context.projects
                    .Where(p => p.Id == projectId)
                    .SingleOrDefault();

                payment.ClientId = project.ClientId;
                _context.projectMaintenancePayments.Add(payment);
                _context.SaveChanges();
            }

            return "Payments added successfully";
        }


        public async Task<ProjectMaintenanceSummaryDto?> GetProjectSummaryAsync(Guid projectId)
        {
            var maintenance = await _context.projectMaintenances
                .Where(pm => pm.ProjectId == projectId)
                .Include(pm => pm.AMCContract)
                    .ThenInclude(a => a.user)
                .Include(pm => pm.MaintenanceSchedules)
                    .ThenInclude(ms => ms.user)
                .Include(pm => pm.ProjectMaintenancePayments)
                    .ThenInclude(p => p.user)
                .FirstOrDefaultAsync();

            if (maintenance == null) return null;

            // Technician Reports are linked to ProjectId directly
            var techReports = await _context.technicianReports
                .Where(tr => tr.ProjectId == projectId)
                .Include(tr => tr.user)
                .Include(tr => tr.Attachments)
                .ToListAsync();

            return new ProjectMaintenanceSummaryDto
            {
                ProjectMaintenanceId = maintenance.Id,
                ProjectId = maintenance.ProjectId,

                AMCContract = maintenance.AMCContract == null ? null : new AMCContractResponseDto
                {
                    Id = maintenance.AMCContract.Id,
                    ClientName = maintenance.AMCContract.user?.Name ?? string.Empty,
                    ContractType = maintenance.AMCContract.ContractType,
                    Coverage = maintenance.AMCContract.Coverage,
                    StartDate = maintenance.AMCContract.StartDate,
                    EndDate = maintenance.AMCContract.EndDate,
                    NumberOfPMVisits = maintenance.AMCContract.NumberOfPMVisits,
                    IncludedParts = maintenance.AMCContract.IncludedParts,
                    ExcludedParts = maintenance.AMCContract.ExcludedParts,
                    SLA = maintenance.AMCContract.SLA,
                    Price = maintenance.AMCContract.Price,
                    PaymentSchedule = maintenance.AMCContract.PaymentSchedule,
                    EscalationContacts = maintenance.AMCContract.EscalationContacts,
                    RenewalReminderDate = maintenance.AMCContract.RenewalReminderDate,
                },

                MaintenanceSchedules = maintenance.MaintenanceSchedules?
                    .Select(ms => new MaintenanceScheduleDto
                    {
                        Id = ms.Id,
                        TechnicianName = ms.user?.Name ?? string.Empty,
                        TechnicianEmail = ms.user?.Email ?? string.Empty,
                        ScheduledDate = ms.ScheduledDate,
                        JobType = ms.JobType.ToString(),
                        Status = ms.Status.ToString(),
                        Priority = ms.Priority.ToString(),
                    }).ToList() ?? [],

                Payments = maintenance.ProjectMaintenancePayments?
                    .Select(p => new ProjectMaintenancePaymentDto
                    {
                        Id = p.Id,
                        ClientName = p.user?.Name ?? string.Empty,
                        Amount = p.Amount,
                        PaymentDate = p.PaymentDate,
                        PaymentReceiptImage = p.PaymentReceiptImage,
                        IsPaid = p.isPaid,
                    }).ToList() ?? [],

                TechnicianReports = techReports
                    .Select(tr => new TechnicianReportDto
                    {
                        Id = tr.Id,
                        TechnicianName = tr.user?.Name ?? string.Empty,
                        Observations = tr.Observations,
                        Recommendation = tr.Recommendation,
                        NextVisitDate = tr.NextVisitDate,
                        Attachments = tr.Attachments?
                                            .Select(a => a.AttachmentURL)
                                            .ToList() ?? [],
                    }).ToList(),
            };
        }

        public string addProjectMaintenance(ProjectMaintenances projectMaintenance)
        {
          _context.projectMaintenances.Add(projectMaintenance);
            _context.SaveChanges();
            return "Project Maintenance added successfully";
        }

        public string addTechnicianReport(TechnicianReport report)
        {
            _context.technicianReports.Add(report);
            _context.SaveChanges();
            return "Report Added Successfully";
        }

        public AMCContract getContractById(Guid Id)
        {
           return _context.AMCContracts.Where(x=>x.Id == Id).FirstOrDefault();
        }

        public List<MaintenanceSchedule> getMaintenanceSchedulesByProjectId(Guid projectId)
        {
            return _context.maintenanceSchedules.Where(ms => ms.projectMaintenances.ProjectId == projectId).ToList();
        }

        public ProjectWithContractDto  getProjectMaintenancesByProjectId(Guid projectId)
        {
            var projectMaintenance =  _context.projectMaintenances
       .Include(pm => pm.project)
       .Include(pm => pm.AMCContract)
           .ThenInclude(c => c.user)
       .FirstOrDefault(pm => pm.ProjectId == projectId);

            if (projectMaintenance == null)
                throw new KeyNotFoundException($"No maintenance record found for project {projectId}");

            var contract = projectMaintenance.AMCContract;

            return new ProjectWithContractDto
            {
                ProjectId = projectMaintenance.ProjectId,
                ProjectMaintenanceId = projectMaintenance.Id,
                AMCContract = contract == null ? null : new AMCContractDto
                {
                    Id = contract.Id,
                    ContractType = contract.ContractType,
                    Coverage = contract.Coverage,
                    StartDate = contract.StartDate,
                    EndDate = contract.EndDate,
                    NumberOfPMVisits = contract.NumberOfPMVisits,
                    IncludedParts = contract.IncludedParts,
                    ExcludedParts = contract.ExcludedParts,
                    SLA = contract.SLA,
                    Price = contract.Price,
                    PaymentSchedule = contract.PaymentSchedule,
                    EscalationContacts = contract.EscalationContacts,
                    RenewalReminderDate = contract.RenewalReminderDate,
                    ClientName = contract.user != null
                        ? $"{contract.user.Name}".Trim()
                        : null
                }
            };
        }

        public TechnicianReport getTechnicianReportsByProjectId(Guid projectId)
        {
           return _context.technicianReports
                .Include(tr => tr.project)
                .FirstOrDefault(tr => tr.ProjectId == projectId);
        }

        public string markPaymentAsPaid(Guid paymentId, string paymentReceiptImage)
        {
           var payment = _context.projectMaintenancePayments.FirstOrDefault(p => p.Id == paymentId);
            if (payment == null)
            {
                throw new Exception("Payment not found");
            }
            payment.PaymentReceiptImage = paymentReceiptImage;
            payment.isPaid = true;

            _context.projectMaintenancePayments.Update(payment);
            _context.SaveChanges();
            return "Payment marked as paid";
        }

        public string updateContract(AMCContract contract)
        {
           _context.AMCContracts.Update(contract);
            _context.SaveChanges();
            return "Contract updated successfully";
        }

        public string updateMaintenanceSchedule(MaintenanceSchedule schedule)
        {
            _context.maintenanceSchedules.Update(schedule);
            _context.SaveChanges();
            return "Maintenance Schedule updated successfully";
        }
    }
}
