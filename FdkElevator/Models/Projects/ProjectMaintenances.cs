using FdkElevator.Models.Auth;
using System.ComponentModel.DataAnnotations.Schema;

namespace FdkElevator.Models.Projects
{
    public class ProjectMaintenances
    {

        public Guid Id { get; set; }

        public Guid ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public Project project { get; set; }

        public ICollection<MaintenanceSchedule> MaintenanceSchedules { get; set; }

        public ICollection<ProjectMaintenancePayment> ProjectMaintenancePayments { get; set; }

        public AMCContract AMCContract { get; set; }

    }

    public class AMCContract
    {
        public Guid Id { get; set; }
        public Guid ProjectMaintenanceId { get; set; }
        public ProjectMaintenances ProjectMaintenance { get; set; }
        [ForeignKey("ClientId")]
        public User user { get; set; }
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

    public class ProjectMaintenancePayment
    {
        public Guid Id { get; set; }
        public Guid ProjectMaintenanceId { get; set; }
        [ForeignKey("ProjectMaintenanceId")]
        public ProjectMaintenances projectMaintenances { get; set; }

        [ForeignKey("ClientId")]
        public User user { get; set; }
        public Guid ClientId { get; set; }

        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string ?PaymentReceiptImage { get; set; } = string.Empty;

        public bool? isPaid { get; set; } = false;
    }

    public enum JobType
    {
        Monthly,
        Quarterly,
        Custom
    }
    public enum MaintenanceStatus
    {
        Pending,
        Completed,
        Missed
    }
    public enum MaintenancePriority
    {
        Low,
        Medium,
        High
    }

    public class MaintenanceSchedule
    {
        public Guid Id { get; set; }

        public Guid AssignedTechnician { get; set; }

        [ForeignKey("AssignedTechnician")]
        public User user { get; set; }
        public Guid projectMaintenanceId { get; set; }

        [ForeignKey("projectMaintenanceId")]
        public ProjectMaintenances projectMaintenances { get; set; }

        public DateTime ScheduledDate { get; set; }
        public JobType JobType { get; set; }          
        public MaintenanceStatus Status { get; set; }           
        public MaintenancePriority Priority { get; set; }

    }

    public class TechnicianReport
    {
        public Guid Id { get; set; }

        public Guid ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public Project project { get; set; }
        public Guid TechnicianId { get; set; }

        [ForeignKey("TechnicianId")]
        public User user { get; set; }

        public ICollection<ReportAttachments> Attachments { get; set; }

        public string Observations { get; set; } = string.Empty;

        public string Recommendation { get; set; } = string.Empty;


        public DateTime NextVisitDate { get; set; }

    }

    public class ReportAttachments
    {
        public Guid Id { get; set; }
        public Guid TechnicianReportId { get; set; }
        [ForeignKey("TechnicianReportId")]
        public TechnicianReport technicianReport { get; set; }
        public string? AttachmentURL { get; set; } = string.Empty;

    }
}
