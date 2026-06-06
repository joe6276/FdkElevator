using FdkElevator.Models.Auth;
using FdkElevator.Models.Projects;
using System.ComponentModel.DataAnnotations.Schema;

namespace FdkElevator.Models.Complaints
{
 
        public enum ComplaintSource
        {
            ClientPortal,
            Phone,
            WhatsApp,
            ManualEntry,
            QRScan,
            Email,
            InternalUser
        }

  
        public enum FaultType
        {
            TrappedPassenger,
            LiftStopped,
            DoorFault,
            LevelingProblem,
            NoiseVibration,
            AlarmIntercomIssue,
            PowerIssue,
            ControllerFault,
            MechanicalIssue,
            WaterIngress,
            Vandalism,
            Other
        }

       
        public enum ComplaintPriority
        {
            Emergency,  
            High,      
            Medium,     
            Low        
        }

        public enum SLAStatus
        {
            WithinSLA,
            AtRisk,
            Breached
        }

        public enum BreakdownJobStatus
        {
            Logged,
            Dispatched,
            TechnicianEnRoute,
            OnSite,
            DiagnosisInProgress,
            AwaitingParts,
            AwaitingApproval,
            RepairInProgress,
            Completed,
            Closed,
            Cancelled
        }

        public enum LiftRunningStatus
        {
            FullyOperational,
            PartiallyOperational,
            OutOfService
        }
        public enum SafetyStatus
        {
            Safe,
            RestrictedUse,
            UnsafeDoNotUse
        }

        public enum QuotationReason
        {
            NonAMC,
            OutOfScope,
            SpareReplacement,
            Modernization,
            MisuseOrVandalism
        }

        public enum ComplaintQuotationStatus
        {
            Draft,
            SentToClient,
            Approved,
            Rejected,
            Revised
        }

        public enum RCAOutcome
        {
            MonitoringRequired,
            ComponentReplacementPlanned,
            ModernizationProposed,
            Resolved
        }

        public class BreakdownComplaint
        {
            public Guid Id { get; set; }
            public Guid ProjectId { get; set; }
            [ForeignKey("ProjectId")]
            public Project Project { get; set; }
            public ComplaintSource Source { get; set; }
            public string? QRCodeReference { get; set; }
            public string? WhatsAppMessageRef { get; set; }
            public string? EmailReference { get; set; }
            public Guid? ReportedByUserId { get; set; }
            [ForeignKey("ReportedByUserId")]
            public User? ReportedBy { get; set; }
            public string? ReportedByExternal { get; set; }
            public string? ReportedByPhone { get; set; }
            public DateTime ComplaintDateTime { get; set; } = DateTime.UtcNow;
            public FaultType FaultType { get; set; }
            public string? FaultDescription { get; set; }
            public bool PassengerTrapped { get; set; } = false;
            public ComplaintPriority Priority { get; set; }
            public bool IsAMCClient { get; set; } = false;
            public Guid? SLAConfigId { get; set; }
            [ForeignKey("SLAConfigId")]
            public SLAConfiguration? SLAConfig { get; set; }
            public DateTime SLAResponseDeadline { get; set; }
            public DateTime SLAResolutionDeadline { get; set; }
            public SLAStatus SLAStatus { get; set; } = SLAStatus.WithinSLA;
            public BreakdownJobStatus Status { get; set; } = BreakdownJobStatus.Logged;
            public bool IsRepeatedFault { get; set; } = false;
            public int RepeatCount { get; set; } = 0;          
            public BreakdownDispatch? Dispatch { get; set; }
            public TechnicianDiagnosis? Diagnosis { get; set; }
            public RepairQuotation? Quotation { get; set; }
            public JobClosure? JobClosure { get; set; }
            public RootCauseAnalysis? RootCauseAnalysis { get; set; }
        }

        public class BreakdownDispatch
        {
            public Guid Id { get; set; }
            public Guid BreakdownComplaintId { get; set; }
            [ForeignKey("BreakdownComplaintId")]
            public BreakdownComplaint BreakdownComplaint { get; set; }
            public Guid TechnicianId { get; set; }
            [ForeignKey("TechnicianId")]
            public User Technician { get; set; }
            public Guid? DispatchedById { get; set; }           
            [ForeignKey("DispatchedById")]
            public User? DispatchedBy { get; set; }
            public DateTime DispatchTime { get; set; }=DateTime.UtcNow;
        public string? DispatchNotes { get; set; }
        }



        public class SLAConfiguration
        {
            public Guid Id { get; set; }
            public string Name { get; set; }                   
            public ComplaintPriority Priority { get; set; }
            public bool IsAMC { get; set; }
            public int ResponseTimeMinutes { get; set; }        
            public int ArrivalTimeMinutes { get; set; }         
            public int ResolutionTimeHours { get; set; }        
            public string? PenaltyTerms { get; set; }
        }

        public class TechnicianDiagnosis
        {
            public Guid Id { get; set; }
            public Guid BreakdownComplaintId { get; set; }
            [ForeignKey("BreakdownComplaintId")]
            public BreakdownComplaint BreakdownComplaint { get; set; }
            public Guid TechnicianId { get; set; }
            [ForeignKey("TechnicianId")]
            public User Technician { get; set; }
            public string? FaultCode { get; set; }
            public string SuspectedRootCause { get; set; }
            public string ComponentAffected { get; set; }
            public string? TemporaryFixApplied { get; set; }
            public bool PermanentFixRequired { get; set; } = false;
            public string? PermanentFixDescription { get; set; }
            public SafetyStatus SafetyStatus { get; set; }
            public DateTime DiagnosisDateTime { get; set; }

            public ICollection<DiagnosisMedia>? Media { get; set; }
            public ICollection<SparePartRequest>? SparePartsNeeded { get; set; }

        }

        public class DiagnosisMedia
        {
            public Guid Id { get; set; }
            public Guid TechnicianDiagnosisId { get; set; }
            [ForeignKey("TechnicianDiagnosisId")]
            public TechnicianDiagnosis TechnicianDiagnosis { get; set; }
            public string MediaURL { get; set; }
       
            public DateTime UploadedAt { get; set; }= DateTime.Now;
        }

        public class SparePartRequest
        {
            public Guid Id { get; set; }
            public Guid TechnicianDiagnosisId { get; set; }
            [ForeignKey("TechnicianDiagnosisId")]
            public TechnicianDiagnosis TechnicianDiagnosis { get; set; }
            public string PartName { get; set; }
            public string? PartCode { get; set; }
            public int QuantityNeeded { get; set; }
        }
        public class JobClosure
        {
            public Guid Id { get; set; }
            public Guid BreakdownComplaintId { get; set; }
            [ForeignKey("BreakdownComplaintId")]
            public BreakdownComplaint BreakdownComplaint { get; set; }

            public Guid ClosedByTechnicianId { get; set; }
            [ForeignKey("ClosedByTechnicianId")]
            public User ClosedByTechnician { get; set; }

            public DateTime ClosureDateTime { get; set; }
            public LiftRunningStatus LiftRunningStatus { get; set; }
            public string ServiceReportSummary { get; set; }
            public string? Recommendations { get; set; }
            public bool ClientSignatureObtained { get; set; } = false;
            public bool InvoiceTriggered { get; set; } = false;
            public string? InvoiceURL { get; set; }               
            public bool RepeatedFaultFlagged { get; set; } = false;
        }

        public class RepairQuotation
        {
            public Guid Id { get; set; }
            public Guid BreakdownComplaintId { get; set; }
            [ForeignKey("BreakdownComplaintId")]
            public BreakdownComplaint BreakdownComplaint { get; set; }
            public QuotationReason Reason { get; set; }
            public ComplaintQuotationStatus Status { get; set; } = ComplaintQuotationStatus.Draft;
            public decimal LaborCost { get; set; }
            public decimal PartsCost { get; set; }
            public decimal TotalAmount { get; set; }
            public string? Notes { get; set; }
            public DateTime IssuedDate { get; set; } = DateTime.UtcNow;
            public DateTime? ApprovedDate { get; set; }
            public Guid? ApprovedByClientId { get; set; }
            [ForeignKey("ApprovedByClientId")]
            public User? ApprovedByClient { get; set; }
            public string? QuotationDocumentURL { get; set; }

            public ICollection<QuotationLineItem> LineItems { get; set; }
        }

        public class QuotationLineItem
        {
            public Guid Id { get; set; }
            public Guid RepairQuotationId { get; set; }
            [ForeignKey("RepairQuotationId")]
            public RepairQuotation RepairQuotation { get; set; }
            public string Description { get; set; }
            public int Quantity { get; set; }
            public decimal UnitPrice { get; set; }
            public decimal TotalPrice { get; set; }
        }

        public class RootCauseAnalysis
        {
            public Guid Id { get; set; }
            public Guid BreakdownComplaintId { get; set; }
            [ForeignKey("BreakdownComplaintId")]
            public BreakdownComplaint BreakdownComplaint { get; set; }

            public Guid ProjectId { get; set; }
            [ForeignKey("ProjectId")]
            public Project Project { get; set; }

            public Guid ReviewedByManagerId { get; set; }
            [ForeignKey("ReviewedByManagerId")]
            public User ReviewedByManager { get; set; }

            public string RootCauseSummary { get; set; }
            public string ComponentHistory { get; set; }       
            public int BreakdownCountLast90Days { get; set; }   
            public RCAOutcome Outcome { get; set; }
            public string? ActionPlan { get; set; }
            public DateTime ReviewDate { get; set; }
            public DateTime? PlannedActionDate { get; set; }
            public bool ModernizationProposalSent { get; set; } = false;
        }


    
}
