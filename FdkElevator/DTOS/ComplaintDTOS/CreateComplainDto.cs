using FdkElevator.Models.Complaints;
using FdkElevator.Models.Quotations;

namespace FdkElevator.DTOS.ComplaintDTOS
{
 
    public class CreateComplaintDto
    {
        public Guid ProjectId { get; set; }
        public ComplaintSource Source { get; set; }
        public string? QRCodeReference { get; set; }
        public string? WhatsAppMessageRef { get; set; }
        public string? EmailReference { get; set; }
        public Guid? ReportedByUserId { get; set; }
        public string? ReportedByExternal { get; set; }
        public string? ReportedByPhone { get; set; }
        public FaultType FaultType { get; set; }
        public string? FaultDescription { get; set; }
        public bool PassengerTrapped { get; set; } = false;
        public bool IsAMCClient { get; set; } = false;
    }

    public class DispatchTechnicianDto
    {
        public Guid TechnicianId { get; set; }
        public Guid? DispatchedById { get; set; }
        public string? DispatchNotes { get; set; }
    }

    public class UpdateDispatchTimestampDto
    {
        public DateTime? ArrivalTime { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? CompletionTime { get; set; }
        public DateTime? ClientConfirmationTime { get; set; }
    }

    public class SubmitDiagnosisDto
    {
        public Guid TechnicianId { get; set; }
        public string? FaultCode { get; set; }
        public string SuspectedRootCause { get; set; }
        public string ComponentAffected { get; set; }
        public string? TemporaryFixApplied { get; set; }
        public bool PermanentFixRequired { get; set; }
        public string? PermanentFixDescription { get; set; }
        public SafetyStatus SafetyStatus { get; set; }
        public List<string>? MediaUrls { get; set; }
        public List<SparePartDto>? SpareParts { get; set; }
    }

    public class SparePartDto
    {
        public string PartName { get; set; }
        public string? PartCode { get; set; }
        public int QuantityNeeded { get; set; }
    }

    public class CreateQuotationDto
    {
        public QuotationReason Reason { get; set; }
        public decimal LaborCost { get; set; }
        public decimal PartsCost { get; set; }
        public string? Notes { get; set; }
        public Guid? ApprovedByClientId { get; set; }
        public List<QuotationLineItemDto> LineItems { get; set; }
    }

    public class QuotationLineItemDto
    {
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }


    public class CloseJobDto
    {
        public Guid ClosedByTechnicianId { get; set; }
        public LiftRunningStatus LiftRunningStatus { get; set; }
        public string ServiceReportSummary { get; set; }
        public string? Recommendations { get; set; }
        public bool ClientSignatureObtained { get; set; }
        public bool InvoiceTriggered { get; set; }
        public string? InvoiceURL { get; set; }
    }


    public class SubmitRCADto
    {
        public Guid ReviewedByManagerId { get; set; }
        public string RootCauseSummary { get; set; }
        public string ComponentHistory { get; set; }
        public RCAOutcome Outcome { get; set; }
        public string? ActionPlan { get; set; }
        public DateTime? PlannedActionDate { get; set; }
        public bool ModernizationProposalSent { get; set; }
    }

    public class BreakdownComplaintSummaryDto
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; }
        public string FaultType { get; set; }
        public string Source { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public string SLAStatus { get; set; }
        public bool PassengerTrapped { get; set; }
        public bool IsRepeatedFault { get; set; }
        public DateTime ComplaintDateTime { get; set; }
        public DateTime SLAResponseDeadline { get; set; }
        public DateTime SLAResolutionDeadline { get; set; }

        public DispatchSummaryDto? Dispatch { get; set; }
        public DiagnosisSummaryDto? Diagnosis { get; set; }
        public QuotationSummaryDto? Quotation { get; set; }
        public ClosureSummaryDto? Closure { get; set; }
        public RCASummaryDto? RCA { get; set; }
    }

    public class DispatchSummaryDto
    {
        public string TechnicianName { get; set; }
        public DateTime DispatchTime { get; set; }
        public DateTime? ArrivalTime { get; set; }
        public DateTime? CompletionTime { get; set; }
    }
    public class DiagnosisSummaryDto
    {
        public string? FaultCode { get; set; }
        public string SuspectedRootCause { get; set; }
        public string ComponentAffected { get; set; }
        public string SafetyStatus { get; set; }
        public bool PermanentFixRequired { get; set; }
        public List<string> MediaUrls { get; set; }
        public List<string> SpareParts { get; set; }
    }

    public class QuotationSummaryDto
    {
        public string Reason { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime IssuedDate { get; set; }
    }
    public class RCASummaryDto
    {
        public string RootCauseSummary { get; set; }
        public string Outcome { get; set; }
        public string? ActionPlan { get; set; }
        public DateTime ReviewDate { get; set; }
    }
    public class ClosureSummaryDto
    {
        public string LiftRunningStatus { get; set; }
        public string ServiceReportSummary { get; set; }
        public bool InvoiceTriggered { get; set; }
        public bool RepeatedFaultFlagged { get; set; }
        public DateTime ClosureDateTime { get; set; }
    }

    public class UpdatePriorityRequest
    {
        public ComplaintPriority Priority { get; set; }
    }

    public class UpdateQuotationStatusRequest
    {
        public ComplaintQuotationStatus Status { get; set; }
    }

    public class UpdateJobStatusRequest
    {
        public BreakdownJobStatus Status { get; set; }
    }
}
