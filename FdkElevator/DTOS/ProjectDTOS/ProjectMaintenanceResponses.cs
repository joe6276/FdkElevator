using FdkElevator.Models.Projects;

namespace FdkElevator.DTOS.ProjectDTOS
{
    public class ProjectMaintenanceResponses
    {
        public class AssetComponentResponse
        {
            public Guid Id { get; set; }
            public Guid LiftAssetId { get; set; }
            public string ComponentType { get; set; } = string.Empty;
            public string ComponentName { get; set; } = string.Empty;
            public string SerialNumber { get; set; } = string.Empty;
            public string SupplierId { get; set; } = string.Empty;
            public DateTime? WarrantyStartDate { get; set; }
            public DateTime? WarrantyEndDate { get; set; }
            public DateTime? LastReplacementDate { get; set; }
            public ProjectMaintenanceAssetComponentStatus ComponentStatus { get; set; }
            public string Notes { get; set; } = string.Empty;
            public DateTime CreatedAt { get; set; }
        }

        public class AssetStatusHistoryResponse
        {
            public Guid Id { get; set; }
            public Guid LiftAssetId { get; set; }
            public Guid? JobId { get; set; }
            public ProjectMaintenanceAssetStatus? OldStatus { get; set; }
            public ProjectMaintenanceAssetStatus NewStatus { get; set; }
            public string Reason { get; set; } = string.Empty;
            public DateTime ChangedAt { get; set; }
            public Guid? ChangedByUserId { get; set; }
        }

        public class LiftAssetSummaryResponse
        {
            public Guid Id { get; set; }
            public Guid ClientId { get; set; }
            public Guid ProjectId { get; set; }
            public string AssetCode { get; set; } = string.Empty;
            public string LiftName { get; set; } = string.Empty;
            public ProjectMaintenanceAssetType LiftAssetType { get; set; }
            public string Manufacturer { get; set; } = string.Empty;
            public string Model { get; set; } = string.Empty;
            public string SerialNumber { get; set; } = string.Empty;
            public ProjectMaintenanceAssetStatus CurrentStatus { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime? UpdatedAt { get; set; }
        }

        public class LiftAssetDetailResponse
        {
            public Guid Id { get; set; }
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
            public ProjectMaintenanceAssetStatus CurrentStatus { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime? UpdatedAt { get; set; }

            public List<AssetComponentResponse> Components { get; set; } = new();
            public List<AssetStatusHistoryResponse> StatusHistory { get; set; } = new();
        }


        // ─────────────────────────────────────────────────────────────
        // CONTRACTS & WARRANTIES
        // ─────────────────────────────────────────────────────────────

        public class AMCContractAssetResponse
        {
            public Guid Id { get; set; }
            public Guid AMCContractId { get; set; }
            public Guid LiftAssetId { get; set; }
            public string AssetCode { get; set; } = string.Empty;
            public string LiftName { get; set; } = string.Empty;
            public DateTime CoverageStartDate { get; set; }
            public DateTime CoverageEndDate { get; set; }
            public bool IsActive { get; set; }
            public DateTime CreatedAt { get; set; }
        }

        public class AMCContractSummaryResponse
        {
            public Guid Id { get; set; }
            public Guid ClientId { get; set; }
            public Guid ProjectId { get; set; }
            public string ContractCode { get; set; } = string.Empty;
            public ProjectMaintenanceContractType ContractType { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public ProjectMaintenanceContractStatus ContractStatus { get; set; }
            public decimal? ContractValue { get; set; }
            public string CurrencyCode { get; set; } = string.Empty;
            public DateTime CreatedAt { get; set; }
        }

        public class AMCContractDetailResponse
        {
            public Guid Id { get; set; }
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
            public string CurrencyCode { get; set; } = string.Empty;
            public string Inclusions { get; set; } = string.Empty;
            public string Exclusions { get; set; } = string.Empty;
            public ProjectMaintenanceContractStatus ContractStatus { get; set; }
            public DateTime CreatedAt { get; set; }

            public List<AMCContractAssetResponse> ContractAssets { get; set; } = new();
        }

        public class WarrantyRecordResponse
        {
            public Guid Id { get; set; }
            public Guid LiftAssetId { get; set; }
            public Guid? ComponentId { get; set; }
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

        public class MaintenanceScheduleResponse
        {
            public Guid Id { get; set; }
            public Guid LiftAssetId { get; set; }
            public string AssetCode { get; set; } = string.Empty;
            public string LiftName { get; set; } = string.Empty;
            public Guid? AMCContractId { get; set; }
            public string? ContractCode { get; set; }
            public Guid? ChecklistTemplateId { get; set; }
            public string? TemplateName { get; set; }
            public ProjectMaintenanceScheduleType ScheduleType { get; set; }
            public ProjectMaintenanceScheduleFrequency Frequency { get; set; }
            public DateTime FirstDueDate { get; set; }
            public DateTime NextDueDate { get; set; }
            public bool IsActive { get; set; }
            public DateTime CreatedAt { get; set; }
        }


        // ─────────────────────────────────────────────────────────────
        // TICKETS & JOBS
        // ─────────────────────────────────────────────────────────────

        public class JobAssignmentResponse
        {
            public Guid Id { get; set; }
            public Guid JobId { get; set; }
            public Guid UserId { get; set; }
            public string UserFullName { get; set; } = string.Empty;
            public string RoleOnJob { get; set; } = string.Empty;
            public DateTime AssignedAt { get; set; }
            public DateTime? CheckInAt { get; set; }
            public DateTime? CheckOutAt { get; set; }
            public ProjectMaintenanceJobAssignmentStatus Status { get; set; }
        }

        public class JobStatusHistoryResponse
        {
            public Guid Id { get; set; }
            public Guid JobId { get; set; }
            public ProjectMaintenanceJobStatus? OldStatus { get; set; }
            public ProjectMaintenanceJobStatus NewStatus { get; set; }
            public Guid? ChangedByUserId { get; set; }
            public DateTime ChangedAt { get; set; }
            public string PublicNote { get; set; } = string.Empty;
            public string InternalNote { get; set; } = string.Empty;
            public bool IsClientVisible { get; set; }
        }

        public class ServiceTicketSummaryResponse
        {
            public Guid Id { get; set; }
            public Guid ClientId { get; set; }
            public Guid ProjectId { get; set; }
            public Guid? LiftAssetId { get; set; }
            public string AssetCode { get; set; } = string.Empty;
            public string TicketCode { get; set; } = string.Empty;
            public string SourceChannel { get; set; } = string.Empty;
            public ProjectMaintenanceServiceType ServiceType { get; set; }
            public ProjectMaintenanceTicketPriority Priority { get; set; }
            public string FaultCategory { get; set; } = string.Empty;
            public bool PassengerTrapped { get; set; }
            public ProjectMaintenanceTicketStatus CurrentStatus { get; set; }
            public DateTime ReportedAt { get; set; }
        }

        public class ServiceTicketDetailResponse
        {
            public Guid Id { get; set; }
            public Guid ClientId { get; set; }
            public Guid ProjectId { get; set; }
            public Guid? LiftAssetId { get; set; }
            public string AssetCode { get; set; } = string.Empty;
            public string LiftName { get; set; } = string.Empty;
            public string TicketCode { get; set; } = string.Empty;
            public string SourceChannel { get; set; } = string.Empty;
            public ProjectMaintenanceServiceType ServiceType { get; set; }
            public ProjectMaintenanceTicketPriority Priority { get; set; }
            public string FaultCategory { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            public bool PassengerTrapped { get; set; }
            public string ReportedByName { get; set; } = string.Empty;
            public string ReportedByPhone { get; set; } = string.Empty;
            public DateTime ReportedAt { get; set; }
            public ProjectMaintenanceTicketStatus CurrentStatus { get; set; }

            public List<ServiceJobSummaryResponse> ServiceJobs { get; set; } = new();
            public List<EvidenceUploadResponse> EvidenceUploads { get; set; } = new();
        }

        public class ServiceJobSummaryResponse
        {
            public Guid Id { get; set; }
            public Guid? TicketId { get; set; }
            public string? TicketCode { get; set; }
            public Guid? ScheduleId { get; set; }
            public Guid LiftAssetId { get; set; }
            public string AssetCode { get; set; } = string.Empty;
            public string JobCode { get; set; } = string.Empty;
            public ProjectMaintenanceServiceType ServiceType { get; set; }
            public ProjectMaintenanceCoverageDecision CoverageDecision { get; set; }
            public DateTime? PlannedStart { get; set; }
            public DateTime? PlannedEnd { get; set; }
            public ProjectMaintenanceJobStatus CurrentStatus { get; set; }
            public DateTime CreatedAt { get; set; }
        }

        public class ServiceJobDetailResponse
        {
            public Guid Id { get; set; }
            public Guid? TicketId { get; set; }
            public string? TicketCode { get; set; }
            public Guid? ScheduleId { get; set; }
            public Guid LiftAssetId { get; set; }
            public string AssetCode { get; set; } = string.Empty;
            public string LiftName { get; set; } = string.Empty;
            public string JobCode { get; set; } = string.Empty;
            public ProjectMaintenanceServiceType ServiceType { get; set; }
            public ProjectMaintenanceCoverageDecision CoverageDecision { get; set; }
            public DateTime? PlannedStart { get; set; }
            public DateTime? PlannedEnd { get; set; }
            public DateTime? ActualStart { get; set; }
            public DateTime? ActualEnd { get; set; }
            public ProjectMaintenanceJobStatus CurrentStatus { get; set; }
            public Guid? AssignedSupervisorId { get; set; }
            public string Notes { get; set; } = string.Empty;
            public DateTime CreatedAt { get; set; }

            public List<JobAssignmentResponse> Assignments { get; set; } = new();
            public List<JobChecklistResponseDto> ChecklistResponses { get; set; } = new();
            public List<EvidenceUploadResponse> EvidenceUploads { get; set; } = new();
            public List<ServicePartsRequestResponse> PartsRequests { get; set; } = new();
            public List<ServiceQuoteResponse> Quotes { get; set; } = new();
            public List<ServiceInvoiceResponse> Invoices { get; set; } = new();
            public List<JobStatusHistoryResponse> StatusHistory { get; set; } = new();
        }


        // ─────────────────────────────────────────────────────────────
        // CHECKLISTS
        // ─────────────────────────────────────────────────────────────

        public class ChecklistItemResponse
        {
            public Guid Id { get; set; }
            public Guid ChecklistTemplateId { get; set; }
            public int ItemOrder { get; set; }
            public string SectionName { get; set; } = string.Empty;
            public string ItemText { get; set; } = string.Empty;
            public ProjectMaintenanceChecklistInputType ExpectedInputType { get; set; }
            public bool IsCritical { get; set; }
            public bool EvidenceRequired { get; set; }
        }

        public class ChecklistTemplateResponse
        {
            public Guid Id { get; set; }
            public string TemplateCode { get; set; } = string.Empty;
            public string TemplateName { get; set; } = string.Empty;
            public ProjectMaintenanceServiceType ServiceType { get; set; }
            public ProjectMaintenanceAssetType? LiftAssetType { get; set; }
            public string FaultCategory { get; set; } = string.Empty;
            public bool IsActive { get; set; }

            public List<ChecklistItemResponse> Items { get; set; } = new();
        }

        public class JobChecklistResponseDto
        {
            public Guid Id { get; set; }
            public Guid JobId { get; set; }
            public Guid ChecklistItemId { get; set; }
            public string ItemText { get; set; } = string.Empty;
            public string SectionName { get; set; } = string.Empty;
            public bool IsCritical { get; set; }
            public ProjectMaintenanceChecklistResult Result { get; set; }
            public decimal? NumericValue { get; set; }
            public string TextValue { get; set; } = string.Empty;
            public string Remarks { get; set; } = string.Empty;
            public Guid SubmittedByUserId { get; set; }
            public DateTime SubmittedAt { get; set; }
            public Guid? ApprovedByUserId { get; set; }
            public DateTime? ApprovedAt { get; set; }

            public List<EvidenceUploadResponse> EvidenceUploads { get; set; } = new();
        }


        // ─────────────────────────────────────────────────────────────
        // EVIDENCE
        // ─────────────────────────────────────────────────────────────

        public class EvidenceUploadResponse
        {
            public Guid Id { get; set; }
            public Guid? JobId { get; set; }
            public Guid? TicketId { get; set; }
            public Guid? ResponseId { get; set; }
            public ProjectMaintenanceEvidenceType EvidenceType { get; set; }
            public string FileName { get; set; } = string.Empty;
            public string FileUrl { get; set; } = string.Empty;
            public Guid UploadedByUserId { get; set; }
            public DateTime UploadedAt { get; set; }
            public bool IsClientVisible { get; set; }
        }


        // ─────────────────────────────────────────────────────────────
        // PARTS, QUOTES & INVOICES
        // ─────────────────────────────────────────────────────────────

        public class ServicePartsRequestResponse
        {
            public Guid Id { get; set; }
            public Guid JobId { get; set; }
            public string InventoryItemId { get; set; } = string.Empty;
            public string PartName { get; set; } = string.Empty;
            public decimal Quantity { get; set; }
            public ProjectMaintenancePartUrgency Urgency { get; set; }
            public ProjectMaintenancePartRequestStatus Status { get; set; }
            public string SupplierId { get; set; } = string.Empty;
            public string WarrantyClaimId { get; set; } = string.Empty;
            public string Notes { get; set; } = string.Empty;
        }

        public class ServiceInvoiceResponse
        {
            public Guid Id { get; set; }
            public Guid JobId { get; set; }
            public Guid? QuoteId { get; set; }
            public string InvoiceCode { get; set; } = string.Empty;
            public ProjectMaintenanceInvoiceStatus Status { get; set; }
            public decimal TotalAmount { get; set; }
            public decimal PaidAmount { get; set; }
            public decimal BalanceDue => TotalAmount - PaidAmount;
            public DateTime? DueDate { get; set; }
            public DateTime CreatedAt { get; set; }
        }

        public class ServiceQuoteResponse
        {
            public Guid Id { get; set; }
            public Guid JobId { get; set; }
            public string QuoteCode { get; set; } = string.Empty;
            public ProjectMaintenanceQuoteStatus Status { get; set; }
            public decimal TotalAmount { get; set; }
            public string CurrencyCode { get; set; } = string.Empty;
            public DateTime? ClientApprovedAt { get; set; }
            public DateTime CreatedAt { get; set; }

            public List<ServiceInvoiceResponse> Invoices { get; set; } = new();
        }
    
}
}
