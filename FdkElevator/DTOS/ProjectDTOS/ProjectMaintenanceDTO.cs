using FdkElevator.Models.Auth;
using FdkElevator.Models.Projects;
using System.ComponentModel.DataAnnotations.Schema;

namespace FdkElevator.DTOS.ProjectDTOS
{
    public class ProjectMaintenanceDTO
    {

        public class ProjectMaintenanceRequest
        {
            public Guid ProjectId { get; set; }
            public AMCContractRequest AMCContract { get; set; }

        }

        public class AMCContractRequest
        {
           
            public Guid ClientId { get; set; }
            public string ContractType { get; set; }
            public string Coverage { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public int NumberOfPMVisits { get; set; }
            public string IncludedParts { get; set; }
            public string ExcludedParts { get; set; }
            public string SLA { get; set; }
            public decimal Price { get; set; }
            public string PaymentSchedule { get; set; }
            public string EscalationContacts { get; set; }
            public DateTime RenewalReminderDate { get; set; }
        }

        public class AMCContractDto
        {
            public Guid Id { get; set; }
            public string ContractType { get; set; }
            public string Coverage { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public int NumberOfPMVisits { get; set; }
            public string IncludedParts { get; set; }
            public string ExcludedParts { get; set; }
            public string SLA { get; set; }
            public decimal Price { get; set; }
            public string PaymentSchedule { get; set; }
            public string EscalationContacts { get; set; }
            public DateTime RenewalReminderDate { get; set; }
            public string ClientName { get; set; }
        }

        public class ProjectWithContractDto
        {
            public Guid ProjectId { get; set; }
            public Guid ProjectMaintenanceId { get; set; }
            public AMCContractDto AMCContract { get; set; }
        }


        public class ProjectMaintenancePaymentRequest
        {
 
            public Guid ProjectMaintenanceId { get; set; }
            public decimal Amount { get; set; }
            public DateTime PaymentDate { get; set; }
        }


        public class MaintenanceScheduleRequest
        {
            
            public Guid AssignedTechnician { get; set; }
            public Guid projectMaintenanceId { get; set; }
            public DateTime ScheduledDate { get; set; }
            public JobType JobType { get; set; }
            public MaintenanceStatus Status { get; set; }
            public MaintenancePriority Priority { get; set; }

        }


        public class TechnicianReportRequest
        {
           
            public Guid ProjectId { get; set; }
            public Guid TechnicianId { get; set; }
   
            public ICollection<ReportAttachmentsRequest> Attachments { get; set; }

            public string Observations { get; set; } = string.Empty;

            public string Recommendation { get; set; } = string.Empty;


            public DateTime NextVisitDate { get; set; }

        }

        public class ReportAttachmentsRequest
        {
            public string AttachmentURL { get; set; } = string.Empty;

        }


        public class ProjectMaintenanceSummaryDto
        {
            public Guid ProjectMaintenanceId { get; set; }
            public Guid ProjectId { get; set; }
            public AMCContractResponseDto AMCContract { get; set; }
            public List<MaintenanceScheduleDto> MaintenanceSchedules { get; set; }
            public List<ProjectMaintenancePaymentDto> Payments { get; set; }
            public List<TechnicianReportDto> TechnicianReports { get; set; }
        }

        public class AMCContractResponseDto
        {
            public Guid Id { get; set; }
            public string ClientName { get; set; }
            public string ContractType { get; set; }
            public string Coverage { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public int NumberOfPMVisits { get; set; }
            public string IncludedParts { get; set; }
            public string ExcludedParts { get; set; }
            public string SLA { get; set; }
            public decimal Price { get; set; }
            public string PaymentSchedule { get; set; }
            public string EscalationContacts { get; set; }
            public DateTime RenewalReminderDate { get; set; }
        }

        public class MaintenanceScheduleDto
        {
            public Guid Id { get; set; }
            public string TechnicianName { get; set; }
            public string TechnicianEmail { get; set; }
            public DateTime ScheduledDate { get; set; }
            public string JobType { get; set; }
            public string Status { get; set; }
            public string Priority { get; set; }
        }

        public class ProjectMaintenancePaymentDto
        {
            public Guid Id { get; set; }
            public string ClientName { get; set; }
            public decimal Amount { get; set; }
            public DateTime PaymentDate { get; set; }
            public string? PaymentReceiptImage { get; set; }
            public bool? IsPaid { get; set; }
        }

        public class TechnicianReportDto
        {
            public Guid Id { get; set; }
            public string TechnicianName { get; set; }
            public string Observations { get; set; }
            public string Recommendation { get; set; }
            public DateTime NextVisitDate { get; set; }
            public List<string?> Attachments { get; set; }
        }
    }
}
