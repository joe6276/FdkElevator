using FdkElevator.Models.Auth;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace FdkElevator.Models.Projects
{public enum ProjectMaintenanceAssetType
    {
        PassengerLift,
        GoodsLift,
        HospitalLift,
        FreightLift,
        HomeLift,
        Dumbwaiter,
        Escalator,
        MovingWalk,
        PlatformLift,
        HydraulicLift,
        TractionMR,
        TractionMRL
    }
 
    public enum ProjectMaintenanceAssetStatus
    {
        Active,
        UnderMaintenance,
        OutOfService,
        Suspended,
        Decommissioned
    }
 
    public enum ProjectMaintenanceAssetComponentStatus
    {
        Installed,
        NotInstalled,
        UnderMaintenance,
        OutOfService
    }
 
    public enum ProjectMaintenanceContractType
    {
        AMCComprehensive  = 0,
        AMCLabourOnly     = 1,
        AMCPartsIncluded  = 2,
        WarrantyInstaller = 3,
        WarrantyOEM       = 4,
        OutOfContract     = 5,
        BillablePerVisit  = 6
    }
 
    public enum ProjectMaintenanceContractStatus
    {
        Draft          = 0,
        Active         = 1,
        Suspended      = 2,
        Expired        = 3,
        Terminated     = 4,
        RenewalPending = 5
    }
 
    public enum ProjectMaintenanceWarrantyStatus
    {
        Active         = 0,
        ExpiringSoon   = 1,
        Expired        = 2,
        Suspended      = 3,
        ClaimSubmitted = 4,
        ClaimApproved  = 5,
        ClaimRejected  = 6
    }
 
    public enum ProjectMaintenanceScheduleType
    {
        PreventiveAMC,
        PreventiveWarranty,
        StatutoryInspection,
        CorrectiveFollowUp
    }
 
    public enum ProjectMaintenanceScheduleFrequency
    {
        Weekly,
        BiWeekly,
        Monthly,
        BiMonthly,
        Quarterly,
        SemiAnnual,
        Annual
    }
 
    public enum ProjectMaintenanceServiceType
    {
        PreventiveAMC,
        PreventiveWarranty,
        CorrectiveBreakdown,
        CorrectiveRepair,
        EmergencyEntrapment,
        StatutoryInspection,
        ModernizationSupport,
        ClientRequestedVisit
    }
 
    public enum ProjectMaintenanceTicketPriority
    {
        Low,
        Normal,
        High,
        Critical,
        Emergency
    }
 
    public enum ProjectMaintenanceTicketStatus
    {
        Open,
        Acknowledged,
        Assigned,
        InProgress,
        Resolved,
        Closed,
        Cancelled
    }
 
    public enum ProjectMaintenanceJobStatus
    {
        Scheduled,
        Assigned,
        EnRoute,
        OnSite,
        InDiagnosis,
        InProgress,
        WaitingParts,
        WaitingClientApproval,
        WaitingSupplier,
        Testing,
        SubmittedForReview,
        ReturnedForCorrection,
        Approved,
        ClientSigned,
        Closed,
        Reopened,
        Cancelled
    }
 
    public enum ProjectMaintenanceCoverageDecision
    {
        PendingReview,
        CoveredByAMC,
        CoveredByWarranty,
        Billable,
        ExcludedMisuse,
        ExcludedPowerIssue,
        ExcludedWaterIngress,
        SupplierClaim
    }
 
    public enum ProjectMaintenanceChecklistResult
    {
        Pass,
        Fail,
        NotApplicable,
        NeedsAttention,
        Deferred,
        RepairedOnSite
    }
 
    public enum ProjectMaintenanceChecklistInputType
    {
        PassFailNA,
        Numeric,
        Text,
        YesNo,
        Photo
    }
 
    public enum ProjectMaintenancePartUrgency
    {
        Normal,
        Urgent,
        Critical
    }
 
    public enum ProjectMaintenancePartRequestStatus
    {
        Requested,
        Approved,
        Ordered,
        Received,
        Installed,
        Cancelled
    }
 
    public enum ProjectMaintenanceQuoteStatus
    {
        Draft,
        Sent,
        ClientApproved,
        ClientRejected,
        Cancelled
    }
 
    public enum ProjectMaintenanceInvoiceStatus
    {
        InvoiceDraft,
        Sent,
        PartiallyPaid,
        Paid,
        Overdue,
        Cancelled
    }
 
    public enum ProjectMaintenanceEvidenceType
    {
        Photo,
        Video,
        Document,
        Signature,
        Report
    }
 
    public enum ProjectMaintenanceJobAssignmentStatus
    {
        Assigned,
        CheckedIn,
        CheckedOut,
        Cancelled
    }
 
 
    // ─────────────────────────────────────────────────────────────
    // ASSETS
    // ─────────────────────────────────────────────────────────────
 
    public class LiftAsset
    {
        public Guid Id { get; set; }
 
        [ForeignKey("ClientId")]
        public User User { get; set; }
        public Guid ClientId { get; set; }
 
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
        public Guid ProjectId { get; set; }
 
        public string AssetCode { get; set; } = string.Empty;
        public string LiftName { get; set; } = string.Empty;
        public ProjectMaintenanceAssetType LiftAssetType { get; set; }
        public string Manufacturer { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string SerialNumber { get; set; } = string.Empty;
        public string UnitNumber { get; set; } = string.Empty;
        public string DriveType { get; set; } = string.Empty;
        public string ControllerBrand { get; set; } = string.Empty;
        public string ControllerModel { get; set; } = string.Empty;
        public int? Stops { get; set; }
        public decimal? CapacityKg { get; set; }
        public decimal? SpeedMps { get; set; }
        public DateTime? InstalledDate { get; set; }
        public DateTime? HandoverDate { get; set; }
        public ProjectMaintenanceAssetStatus CurrentStatus { get; set; } = ProjectMaintenanceAssetStatus.Active;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
 
        public ICollection<AssetComponent> Components { get; set; } = new List<AssetComponent>();
        public ICollection<AMCContractAsset> ContractAssets { get; set; } = new List<AMCContractAsset>();
        public ICollection<WarrantyRecord> WarrantyRecords { get; set; } = new List<WarrantyRecord>();
        public ICollection<MaintenanceSchedule> MaintenanceSchedules { get; set; } = new List<MaintenanceSchedule>();
        public ICollection<ServiceTicket> ServiceTickets { get; set; } = new List<ServiceTicket>();
        public ICollection<ServiceJob> ServiceJobs { get; set; } = new List<ServiceJob>();
        public ICollection<AssetStatusHistory> StatusHistory { get; set; } = new List<AssetStatusHistory>();
    }
 
    public class AssetComponent
    {
        public Guid Id { get; set; }
 
        [ForeignKey("LiftAssetId")]
        public LiftAsset LiftAsset { get; set; }
        public Guid LiftAssetId { get; set; }
 
        public string ComponentType { get; set; } = string.Empty;
        public string ComponentName { get; set; } = string.Empty;
        public string SerialNumber { get; set; } = string.Empty;
        public string SupplierId { get; set; } = string.Empty;
        public DateTime? WarrantyStartDate { get; set; }
        public DateTime? WarrantyEndDate { get; set; }
        public DateTime? LastReplacementDate { get; set; }
        public ProjectMaintenanceAssetComponentStatus ComponentStatus { get; set; } = ProjectMaintenanceAssetComponentStatus.Installed;
        public string Notes { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
 
    public class AssetStatusHistory
    {
        public Guid Id { get; set; }
 
        [ForeignKey("LiftAssetId")]
        public LiftAsset LiftAsset { get; set; }
        public Guid LiftAssetId { get; set; }
 
        [ForeignKey("JobId")]
        public ServiceJob? ServiceJob { get; set; }
        public Guid? JobId { get; set; }
 
        public ProjectMaintenanceAssetStatus? OldStatus { get; set; }
        public ProjectMaintenanceAssetStatus NewStatus { get; set; }
        public string Reason { get; set; } = string.Empty;
        public DateTime ChangedAt { get; set; } = DateTime.UtcNow;
        public Guid? ChangedByUserId { get; set; }
    }
 
 
    // ─────────────────────────────────────────────────────────────
    // CONTRACTS & WARRANTIES
    // ─────────────────────────────────────────────────────────────
 
    public class AMCContract
    {
        public Guid Id { get; set; }
 
        [ForeignKey("ClientId")]
        public User User { get; set; }
        public Guid ClientId { get; set; }
 
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
        public Guid ProjectId { get; set; }
 
        public string ContractCode { get; set; } = string.Empty;
        public ProjectMaintenanceContractType ContractType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ProjectMaintenanceScheduleFrequency ServiceFrequency { get; set; }
        public string SLAPolicy { get; set; } = string.Empty;
        public string BillingCycle { get; set; } = string.Empty;
        public decimal? ContractValue { get; set; }
        public string CurrencyCode { get; set; } = "USD";
        public string Inclusions { get; set; } = string.Empty;
        public string Exclusions { get; set; } = string.Empty;
        public ProjectMaintenanceContractStatus ContractStatus { get; set; } = ProjectMaintenanceContractStatus.Draft;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
 
        public ICollection<AMCContractAsset> ContractAssets { get; set; } = new List<AMCContractAsset>();
        public ICollection<MaintenanceSchedule> MaintenanceSchedules { get; set; } = new List<MaintenanceSchedule>();
    }
 
    public class AMCContractAsset
    {
        public Guid Id { get; set; }
 
        [ForeignKey("AMCContractId")]
        public AMCContract AMCContract { get; set; }
        public Guid AMCContractId { get; set; }
 
        [ForeignKey("LiftAssetId")]
        public LiftAsset LiftAsset { get; set; }
        public Guid LiftAssetId { get; set; }
 
        public DateTime CoverageStartDate { get; set; }
        public DateTime CoverageEndDate { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
 
    public class WarrantyRecord
    {
        public Guid Id { get; set; }
 
        [ForeignKey("LiftAssetId")]
        public LiftAsset LiftAsset { get; set; }
        public Guid LiftAssetId { get; set; }
 
        [ForeignKey("ComponentId")]
        public AssetComponent? AssetComponent { get; set; }
        public Guid? ComponentId { get; set; }
 
        public string WarrantyType { get; set; } = string.Empty;
        public string ProviderType { get; set; } = string.Empty;
        public string ProviderId { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ProjectMaintenanceWarrantyStatus WarrantyStatus { get; set; } = ProjectMaintenanceWarrantyStatus.Active;
        public string TermsSummary { get; set; } = string.Empty;
        public string Exclusions { get; set; } = string.Empty;
    }
 
 
    // ─────────────────────────────────────────────────────────────
    // SCHEDULING
    // ─────────────────────────────────────────────────────────────
 
    public class MaintenanceSchedule
    {
        public Guid Id { get; set; }
 
        [ForeignKey("LiftAssetId")]
        public LiftAsset LiftAsset { get; set; }
        public Guid LiftAssetId { get; set; }
 
        [ForeignKey("AMCContractId")]
        public AMCContract? AMCContract { get; set; }
        public Guid? AMCContractId { get; set; }
 
        [ForeignKey("ChecklistTemplateId")]
        public ChecklistTemplate? ChecklistTemplate { get; set; }
        public Guid? ChecklistTemplateId { get; set; }
 
        public ProjectMaintenanceScheduleType ScheduleType { get; set; }
        public ProjectMaintenanceScheduleFrequency Frequency { get; set; }
        public DateTime FirstDueDate { get; set; }
        public DateTime NextDueDate { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
 
        public ICollection<ServiceJob> ServiceJobs { get; set; } = new List<ServiceJob>();
    }
 
 
    // ─────────────────────────────────────────────────────────────
    // TICKETS & JOBS
    // ─────────────────────────────────────────────────────────────
 
    public class ServiceTicket
    {
        public Guid Id { get; set; }
 
        [ForeignKey("ClientId")]
        public User User { get; set; }
        public Guid ClientId { get; set; }
 
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
        public Guid ProjectId { get; set; }
 
        [ForeignKey("LiftAssetId")]
        public LiftAsset? LiftAsset { get; set; }
        public Guid? LiftAssetId { get; set; }
 
        public string TicketCode { get; set; } = string.Empty;
        public string SourceChannel { get; set; } = string.Empty;
        public ProjectMaintenanceServiceType ServiceType { get; set; }
        public ProjectMaintenanceTicketPriority Priority { get; set; }
        public string FaultCategory { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool PassengerTrapped { get; set; } = false;
        public string ReportedByName { get; set; } = string.Empty;
        public string ReportedByPhone { get; set; } = string.Empty;
        public DateTime ReportedAt { get; set; } = DateTime.UtcNow;
        public ProjectMaintenanceTicketStatus CurrentStatus { get; set; } = ProjectMaintenanceTicketStatus.Open;
 
        public ICollection<ServiceJob> ServiceJobs { get; set; } = new List<ServiceJob>();
        public ICollection<EvidenceUpload> EvidenceUploads { get; set; } = new List<EvidenceUpload>();
    }
 
    public class ServiceJob
    {
        public Guid Id { get; set; }
 
        [ForeignKey("TicketId")]
        public ServiceTicket? ServiceTicket { get; set; }
        public Guid? TicketId { get; set; }
 
        [ForeignKey("ScheduleId")]
        public MaintenanceSchedule? MaintenanceSchedule { get; set; }
        public Guid? ScheduleId { get; set; }
 
        [ForeignKey("LiftAssetId")]
        public LiftAsset LiftAsset { get; set; }
        public Guid LiftAssetId { get; set; }
 
        public string JobCode { get; set; } = string.Empty;
        public ProjectMaintenanceServiceType ServiceType { get; set; }
        public ProjectMaintenanceCoverageDecision CoverageDecision { get; set; } = ProjectMaintenanceCoverageDecision.PendingReview;
        public DateTime? PlannedStart { get; set; }
        public DateTime? PlannedEnd { get; set; }
        public DateTime? ActualStart { get; set; }
        public DateTime? ActualEnd { get; set; }
        public ProjectMaintenanceJobStatus CurrentStatus { get; set; } = ProjectMaintenanceJobStatus.Scheduled;
        public Guid? AssignedSupervisorId { get; set; }
        public string Notes { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
 
        public ICollection<JobAssignment> Assignments { get; set; } = new List<JobAssignment>();
        public ICollection<JobChecklistResponse> ChecklistResponses { get; set; } = new List<JobChecklistResponse>();
        public ICollection<EvidenceUpload> EvidenceUploads { get; set; } = new List<EvidenceUpload>();
        public ICollection<ServicePartsRequest> PartsRequests { get; set; } = new List<ServicePartsRequest>();
        public ICollection<ServiceQuote> Quotes { get; set; } = new List<ServiceQuote>();
        public ICollection<ServiceInvoice> Invoices { get; set; } = new List<ServiceInvoice>();
        public ICollection<JobStatusHistory> StatusHistory { get; set; } = new List<JobStatusHistory>();
    }
 
    public class JobAssignment
    {
        public Guid Id { get; set; }
 
        [ForeignKey("JobId")]
        public ServiceJob ServiceJob { get; set; }
        public Guid JobId { get; set; }
 
        [ForeignKey("UserId")]
        public User User { get; set; }
        public Guid UserId { get; set; }
 
        public string RoleOnJob { get; set; } = string.Empty;
        public DateTime AssignedAt { get; set; } = DateTime.UtcNow;
        public DateTime? CheckInAt { get; set; }
        public DateTime? CheckOutAt { get; set; }
        public ProjectMaintenanceJobAssignmentStatus Status { get; set; } = ProjectMaintenanceJobAssignmentStatus.Assigned;
    }
 
    public class JobStatusHistory
    {
        public Guid Id { get; set; }
 
        [ForeignKey("JobId")]
        public ServiceJob ServiceJob { get; set; }
        public Guid JobId { get; set; }
 
        public ProjectMaintenanceJobStatus? OldStatus { get; set; }
        public ProjectMaintenanceJobStatus NewStatus { get; set; }
        public Guid? ChangedByUserId { get; set; }
        public DateTime ChangedAt { get; set; } = DateTime.UtcNow;
        public string PublicNote { get; set; } = string.Empty;
        public string InternalNote { get; set; } = string.Empty;
        public bool IsClientVisible { get; set; } = false;
    }
 
 
    // ─────────────────────────────────────────────────────────────
    // CHECKLISTS
    // ─────────────────────────────────────────────────────────────
 
    public class ChecklistTemplate
    {
        public Guid Id { get; set; }
 
        public string TemplateCode { get; set; } = string.Empty;
        public string TemplateName { get; set; } = string.Empty;
        public ProjectMaintenanceServiceType ServiceType { get; set; }
        public ProjectMaintenanceAssetType? LiftAssetType { get; set; }
        public string FaultCategory { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
 
        public ICollection<ChecklistItem> Items { get; set; } = new List<ChecklistItem>();
    }
 
    public class ChecklistItem
    {
        public Guid Id { get; set; }
 
        [ForeignKey("ChecklistTemplateId")]
        public ChecklistTemplate ChecklistTemplate { get; set; }
        public Guid ChecklistTemplateId { get; set; }
 
        public int ItemOrder { get; set; }
        public string SectionName { get; set; } = string.Empty;
        public string ItemText { get; set; } = string.Empty;
        public ProjectMaintenanceChecklistInputType ExpectedInputType { get; set; } = ProjectMaintenanceChecklistInputType.PassFailNA;
        public bool IsCritical { get; set; } = false;
        public bool EvidenceRequired { get; set; } = false;
 
        public ICollection<JobChecklistResponse> Responses { get; set; } = new List<JobChecklistResponse>();
    }
 
    public class JobChecklistResponse
    {
        public Guid Id { get; set; }
 
        [ForeignKey("JobId")]
        public ServiceJob ServiceJob { get; set; }
        public Guid JobId { get; set; }
 
        [ForeignKey("ChecklistItemId")]
        public ChecklistItem ChecklistItem { get; set; }
        public Guid ChecklistItemId { get; set; }
 
        public ProjectMaintenanceChecklistResult Result { get; set; }
        public decimal? NumericValue { get; set; }
        public string TextValue { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
        public Guid SubmittedByUserId { get; set; }
        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
        public Guid? ApprovedByUserId { get; set; }
        public DateTime? ApprovedAt { get; set; }
 
        public ICollection<EvidenceUpload> EvidenceUploads { get; set; } = new List<EvidenceUpload>();
    }
 
 
    // ─────────────────────────────────────────────────────────────
    // EVIDENCE
    // ─────────────────────────────────────────────────────────────
 
    public class EvidenceUpload
    {
        public Guid Id { get; set; }
 
        [ForeignKey("JobId")]
        public ServiceJob? ServiceJob { get; set; }
        public Guid? JobId { get; set; }
 
        [ForeignKey("TicketId")]
        public ServiceTicket? ServiceTicket { get; set; }
        public Guid? TicketId { get; set; }
 
        [ForeignKey("ResponseId")]
        public JobChecklistResponse? ChecklistResponse { get; set; }
        public Guid? ResponseId { get; set; }
 
        public ProjectMaintenanceEvidenceType EvidenceType { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string FileUrl { get; set; } = string.Empty;
        public Guid UploadedByUserId { get; set; }
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
        public bool IsClientVisible { get; set; } = false;
    }
 
 
    // ─────────────────────────────────────────────────────────────
    // PARTS, QUOTES & INVOICES
    // ─────────────────────────────────────────────────────────────
 
    public class ServicePartsRequest
    {
        public Guid Id { get; set; }
 
        [ForeignKey("JobId")]
        public ServiceJob ServiceJob { get; set; }
        public Guid JobId { get; set; }
 
        public string InventoryItemId { get; set; } = string.Empty;
        public string PartName { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public ProjectMaintenancePartUrgency Urgency { get; set; } = ProjectMaintenancePartUrgency.Normal;
        public ProjectMaintenancePartRequestStatus Status { get; set; } = ProjectMaintenancePartRequestStatus.Requested;
        public string SupplierId { get; set; } = string.Empty;
        public string WarrantyClaimId { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
    }
 
    public class ServiceQuote
    {
        public Guid Id { get; set; }
 
        [ForeignKey("JobId")]
        public ServiceJob ServiceJob { get; set; }
        public Guid JobId { get; set; }
 
        public string QuoteCode { get; set; } = string.Empty;
        public ProjectMaintenanceQuoteStatus Status { get; set; } = ProjectMaintenanceQuoteStatus.Draft;
        public decimal TotalAmount { get; set; } = 0;
        public string CurrencyCode { get; set; } = "USD";
        public DateTime? ClientApprovedAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
 
        public ICollection<ServiceInvoice> Invoices { get; set; } = new List<ServiceInvoice>();
    }
 
    public class ServiceInvoice
    {
        public Guid Id { get; set; }
 
        [ForeignKey("JobId")]
        public ServiceJob ServiceJob { get; set; }
        public Guid JobId { get; set; }
 
        [ForeignKey("QuoteId")]
        public ServiceQuote? ServiceQuote { get; set; }
        public Guid? QuoteId { get; set; }
 
        public string InvoiceCode { get; set; } = string.Empty;
        public ProjectMaintenanceInvoiceStatus Status { get; set; } = ProjectMaintenanceInvoiceStatus.InvoiceDraft;
        public decimal TotalAmount { get; set; } = 0;
        public decimal PaidAmount { get; set; } = 0;
        public DateTime? DueDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
