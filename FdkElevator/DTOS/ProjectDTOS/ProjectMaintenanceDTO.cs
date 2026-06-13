using FdkElevator.Models.Auth;
using FdkElevator.Models.Projects;
using System.ComponentModel.DataAnnotations.Schema;

namespace FdkElevator.DTOS.ProjectDTOS
{
    public class ProjectMaintenanceDTO
    {
    

        public class CreateLiftAssetRequest
        {
            public Guid ClientId { get; set; }
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

            public ICollection<CreateAssetComponentRequest> Components { get; set; } = new List<CreateAssetComponentRequest>();
        }

        public class UpdateLiftAssetRequest
        {
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
            public ProjectMaintenanceAssetStatus CurrentStatus { get; set; }
        }

        public class CreateAssetComponentRequest
        {
            
            public string ComponentType { get; set; } = string.Empty;
            public string ComponentName { get; set; } = string.Empty;
            public string SerialNumber { get; set; } = string.Empty;
            public string SupplierId { get; set; } = string.Empty;
            public DateTime? WarrantyStartDate { get; set; }
            public DateTime? WarrantyEndDate { get; set; }
            public DateTime? LastReplacementDate { get; set; }
            public ProjectMaintenanceAssetComponentStatus ComponentStatus { get; set; } = ProjectMaintenanceAssetComponentStatus.Installed;
            public string Notes { get; set; } = string.Empty;
        }

        public class UpdateAssetComponentRequest
        {
            public string ComponentType { get; set; } = string.Empty;
            public string ComponentName { get; set; } = string.Empty;
            public string SerialNumber { get; set; } = string.Empty;
            public string SupplierId { get; set; } = string.Empty;
            public DateTime? WarrantyStartDate { get; set; }
            public DateTime? WarrantyEndDate { get; set; }
            public DateTime? LastReplacementDate { get; set; }
            public ProjectMaintenanceAssetComponentStatus ComponentStatus { get; set; }
            public string Notes { get; set; } = string.Empty;
        }

        public class CreateAssetStatusHistoryRequest
        {
            public Guid LiftAssetId { get; set; }
            public Guid? JobId { get; set; }
            public ProjectMaintenanceAssetStatus? OldStatus { get; set; }
            public ProjectMaintenanceAssetStatus NewStatus { get; set; }
            public string Reason { get; set; } = string.Empty;
            public Guid? ChangedByUserId { get; set; }
        }


        // ─────────────────────────────────────────────────────────────
        // CONTRACTS & WARRANTIES
        // ─────────────────────────────────────────────────────────────

        public class CreateAMCContractRequest
        {
            public Guid ClientId { get; set; }
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
        }

        public class UpdateAMCContractRequest
        {
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
            public ProjectMaintenanceContractStatus ContractStatus { get; set; }
        }

        public class CreateAMCContractAssetRequest
        {
            public Guid AMCContractId { get; set; }
            public Guid LiftAssetId { get; set; }
            public DateTime CoverageStartDate { get; set; }
            public DateTime CoverageEndDate { get; set; }
            public bool IsActive { get; set; } = true;
        }

        public class UpdateAMCContractAssetRequest
        {
            public DateTime CoverageStartDate { get; set; }
            public DateTime CoverageEndDate { get; set; }
            public bool IsActive { get; set; }
        }

        public class CreateWarrantyRecordRequest
        {
            public Guid LiftAssetId { get; set; }
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

        public class UpdateWarrantyRecordRequest
        {
            public string WarrantyType { get; set; } = string.Empty;
            public string ProviderType { get; set; } = string.Empty;
            public string ProviderId { get; set; } = string.Empty;
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public ProjectMaintenanceWarrantyStatus WarrantyStatus { get; set; }
            public string TermsSummary { get; set; } = string.Empty;
            public string Exclusions { get; set; } = string.Empty;
        }


        // ─────────────────────────────────────────────────────────────
        // SCHEDULING
        // ─────────────────────────────────────────────────────────────

        public class CreateMaintenanceScheduleRequest
        {
            public Guid LiftAssetId { get; set; }
            public Guid? AMCContractId { get; set; }
            public Guid?  ProjectId { get; set; }
            public Guid? ChecklistTemplateId { get; set; }
            public ProjectMaintenanceScheduleType ScheduleType { get; set; }
            public ProjectMaintenanceScheduleFrequency Frequency { get; set; }
            public DateTime FirstDueDate { get; set; }
            public DateTime NextDueDate { get; set; }
            public bool IsActive { get; set; } = true;
        }

        public class UpdateMaintenanceScheduleRequest
        {
            public Guid? ChecklistTemplateId { get; set; }
            public ProjectMaintenanceScheduleType ScheduleType { get; set; }
            public ProjectMaintenanceScheduleFrequency Frequency { get; set; }
            public DateTime NextDueDate { get; set; }
            public bool IsActive { get; set; }
        }


        // ─────────────────────────────────────────────────────────────
        // TICKETS & JOBS
        // ─────────────────────────────────────────────────────────────

        public class CreateServiceTicketRequest
        {
            public Guid ClientId { get; set; }
            public Guid ProjectId { get; set; }
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
        }

        public class UpdateServiceTicketRequest
        {
            public Guid? LiftAssetId { get; set; }
            public ProjectMaintenanceServiceType ServiceType { get; set; }
            public ProjectMaintenanceTicketPriority Priority { get; set; }
            public string FaultCategory { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            public bool PassengerTrapped { get; set; }
            public string ReportedByName { get; set; } = string.Empty;
            public string ReportedByPhone { get; set; } = string.Empty;
            public ProjectMaintenanceTicketStatus CurrentStatus { get; set; }
        }

        public class CreateServiceJobRequest
        {
            public Guid? TicketId { get; set; }
            public Guid? ScheduleId { get; set; }
            public Guid LiftAssetId { get; set; }
            public string JobCode { get; set; } = string.Empty;
            public ProjectMaintenanceServiceType ServiceType { get; set; }
            public ProjectMaintenanceCoverageDecision CoverageDecision { get; set; } = ProjectMaintenanceCoverageDecision.PendingReview;
            public DateTime? PlannedStart { get; set; }
            public DateTime? PlannedEnd { get; set; }
            public Guid? AssignedSupervisorId { get; set; }
            public string Notes { get; set; } = string.Empty;
        }

        public class UpdateServiceJobRequest
        {
            public ProjectMaintenanceServiceType ServiceType { get; set; }
            public ProjectMaintenanceCoverageDecision CoverageDecision { get; set; }
            public DateTime? PlannedStart { get; set; }
            public DateTime? PlannedEnd { get; set; }
            public DateTime? ActualStart { get; set; }
            public DateTime? ActualEnd { get; set; }
            public ProjectMaintenanceJobStatus CurrentStatus { get; set; }
            public Guid? AssignedSupervisorId { get; set; }
            public string Notes { get; set; } = string.Empty;
        }

        public class CreateJobAssignmentRequest
        {
            public Guid JobId { get; set; }
            public Guid UserId { get; set; }
            public string RoleOnJob { get; set; } = string.Empty;
        }

        public class UpdateJobAssignmentRequest
        {
            public DateTime? CheckInAt { get; set; }
            public DateTime? CheckOutAt { get; set; }
            public ProjectMaintenanceJobAssignmentStatus Status { get; set; }
        }

        public class CreateJobStatusHistoryRequest
        {
            public Guid JobId { get; set; }
            public ProjectMaintenanceJobStatus? OldStatus { get; set; }
            public ProjectMaintenanceJobStatus NewStatus { get; set; }
            public Guid? ChangedByUserId { get; set; }
            public string PublicNote { get; set; } = string.Empty;
            public string InternalNote { get; set; } = string.Empty;
            public bool IsClientVisible { get; set; } = false;
        }


        // ─────────────────────────────────────────────────────────────
        // CHECKLISTS
        // ─────────────────────────────────────────────────────────────

        public class CreateChecklistTemplateRequest
        {
            public string TemplateCode { get; set; } = string.Empty;
            public string TemplateName { get; set; } = string.Empty;
            public ProjectMaintenanceServiceType ServiceType { get; set; }
            public ProjectMaintenanceAssetType? LiftAssetType { get; set; }
            public string FaultCategory { get; set; } = string.Empty;
            public bool IsActive { get; set; } = true;
        }

        public class UpdateChecklistTemplateRequest
        {
            public string TemplateName { get; set; } = string.Empty;
            public ProjectMaintenanceServiceType ServiceType { get; set; }
            public ProjectMaintenanceAssetType? LiftAssetType { get; set; }
            public string FaultCategory { get; set; } = string.Empty;
            public bool IsActive { get; set; }
        }

        public class CreateChecklistItemRequest
        {
            public Guid ChecklistTemplateId { get; set; }
            public int ItemOrder { get; set; }
            public string SectionName { get; set; } = string.Empty;
            public string ItemText { get; set; } = string.Empty;
            public ProjectMaintenanceChecklistInputType ExpectedInputType { get; set; } = ProjectMaintenanceChecklistInputType.PassFailNA;
            public bool IsCritical { get; set; } = false;
            public bool EvidenceRequired { get; set; } = false;
        }

        public class UpdateChecklistItemRequest
        {
            public int ItemOrder { get; set; }
            public string SectionName { get; set; } = string.Empty;
            public string ItemText { get; set; } = string.Empty;
            public ProjectMaintenanceChecklistInputType ExpectedInputType { get; set; }
            public bool IsCritical { get; set; }
            public bool EvidenceRequired { get; set; }
        }

        public class CreateJobChecklistResponseRequest
        {
            public Guid JobId { get; set; }
            public Guid ChecklistItemId { get; set; }
            public ProjectMaintenanceChecklistResult Result { get; set; }
            public decimal? NumericValue { get; set; }
            public string TextValue { get; set; } = string.Empty;
            public string Remarks { get; set; } = string.Empty;
            public Guid SubmittedByUserId { get; set; }
        }

        public class ApproveJobChecklistResponseRequest
        {
            public Guid ApprovedByUserId { get; set; }
        }


        // ─────────────────────────────────────────────────────────────
        // EVIDENCE
        // ─────────────────────────────────────────────────────────────

        public class CreateEvidenceUploadRequest
        {
            public Guid? JobId { get; set; }
            public Guid? TicketId { get; set; }
            public Guid? ResponseId { get; set; }
            public ProjectMaintenanceEvidenceType EvidenceType { get; set; }
            public string FileName { get; set; } = string.Empty;
            public string FileUrl { get; set; } = string.Empty;
            public Guid UploadedByUserId { get; set; }
            public bool IsClientVisible { get; set; } = false;
        }

        public class UpdateEvidenceUploadRequest
        {
            public bool IsClientVisible { get; set; }
        }


        // ─────────────────────────────────────────────────────────────
        // PARTS, QUOTES & INVOICES
        // ─────────────────────────────────────────────────────────────

        public class CreateServicePartsRequestDto
        {
            public Guid JobId { get; set; }
            public string InventoryItemId { get; set; } = string.Empty;
            public string PartName { get; set; } = string.Empty;
            public decimal Quantity { get; set; }
            public ProjectMaintenancePartUrgency Urgency { get; set; } = ProjectMaintenancePartUrgency.Normal;
            public string SupplierId { get; set; } = string.Empty;
            public string WarrantyClaimId { get; set; } = string.Empty;
            public string Notes { get; set; } = string.Empty;
        }

        public class UpdateServicePartsRequestDto
        {
            public string InventoryItemId { get; set; } = string.Empty;
            public string PartName { get; set; } = string.Empty;
            public decimal Quantity { get; set; }
            public ProjectMaintenancePartUrgency Urgency { get; set; }
            public ProjectMaintenancePartRequestStatus Status { get; set; }
            public string SupplierId { get; set; } = string.Empty;
            public string WarrantyClaimId { get; set; } = string.Empty;
            public string Notes { get; set; } = string.Empty;
        }

        public class CreateServiceQuoteRequest
        {
            public Guid JobId { get; set; }
            public string QuoteCode { get; set; } = string.Empty;
            public decimal TotalAmount { get; set; } = 0;
            public string CurrencyCode { get; set; } = "USD";
        }

        public class UpdateServiceQuoteRequest
        {
            public ProjectMaintenanceQuoteStatus Status { get; set; }
            public decimal TotalAmount { get; set; }
            public string CurrencyCode { get; set; } = "USD";
            public DateTime? ClientApprovedAt { get; set; }
        }

        public class CreateServiceInvoiceRequest
        {
            public Guid JobId { get; set; }
            public Guid? QuoteId { get; set; }
            public string InvoiceCode { get; set; } = string.Empty;
            public decimal TotalAmount { get; set; } = 0;
            public DateTime? DueDate { get; set; }
        }

        public class UpdateServiceInvoiceRequest
        {
            public ProjectMaintenanceInvoiceStatus Status { get; set; }
            public decimal TotalAmount { get; set; }
            public decimal PaidAmount { get; set; }
            public DateTime? DueDate { get; set; }
        }
    }

}

