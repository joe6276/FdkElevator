using System.ComponentModel.DataAnnotations;

namespace FdkElevator.DTOS.CommissionDTO
{


    public class CreateCommissionRequest
    {
        [Required]
        public Guid ProjectId { get; set; }
        [Required]
        public Guid CommissionedBy { get; set; }

        [Required]
        public SafetyCheckRequest SafetyCheck { get; set; }

        [Required]
        public FunctionalTestRequest FunctionalTest { get; set; }

        public PunchListRequest PunchList { get; set; }

        [Required]
        public ClientTrainingRequest ClientTraining { get; set; }

        [Required]
        public GeneratedDocumentsCertificateRequest generatedDocumentsCertificate { get; set; }
    }

    public class SafetyCheckRequest
    {
        [Required] public string EmergencyStop { get; set; }
        [Required] public string DoorLocks { get; set; }
        [Required] public string Alarm { get; set; }
        [Required] public string Intercom { get; set; }
        [Required] public string OverloadProtection { get; set; }
        [Required] public string OverspeedGovernor { get; set; }
        [Required] public string SafetyGear { get; set; }
        [Required] public string Buffers { get; set; }
        [Required] public string LimitSwitches { get; set; }
        [Required] public string BrakeFunction { get; set; }
        [Required] public string LevellingAccuracy { get; set; }
        [Required] public string PhaseProtection { get; set; }
        [Required] public string Grounding { get; set; }
        [Required] public string ControllerFaultHistory { get; set; }
    }

    public class FunctionalTestRequest
    {
        [Required] public string CallButtons { get; set; }
        [Required] public string LandingIndicators { get; set; }
        [Required] public string CabinOperatingPanel { get; set; }
        [Required] public string DoorOpening { get; set; }
        [Required] public string DoorClosing { get; set; }
        [Required] public string RideQuality { get; set; }
        [Required] public string Speed { get; set; }
        [Required] public string Acceleration { get; set; }
        [Required] public string Deceleration { get; set; }
        [Required] public string FloorLevelling { get; set; }
        [Required] public string RescueOperation { get; set; }
        public string FiremanOperation { get; set; }   
        public string ARDBehaviour { get; set; }        
        public string UPSBehaviour { get; set; }       
        [Required] public string PowerFailureResponse { get; set; }
    }

    public class PunchListRequest
    {
        public List<PunchRequest> Punches { get; set; } = new();
    }

    public class PunchRequest
    {
        [Required] public string PunchDescription { get; set; }
        [Required] public string CorrectionRequired { get; set; }
        [Required] public string Severity { get; set; }
        [Required] public string ResponsibleParty { get; set; }
        [Required] public DateTime DueDate { get; set; }
        [Required] public string Photo { get; set; }
    }

    public class ClientTrainingRequest
    {
        [Required] public string Attendees { get; set; }
        [Required] public string TrainingTopics { get; set; }
        [Required] public string EmergencyRescueBasics { get; set; }
        [Required] public string OperatingPrecautions { get; set; }
        [Required] public string MaintenanceSchedule { get; set; }
        [Required] public string WarrantyTerms { get; set; }
        [Required] public string DocumentReceived { get; set; }
    }

 
    public class GeneratedDocumentsCertificateRequest
    {
        public List<CertificateRequest> Certificates { get; set; } = new();
    }

    public class CertificateRequest
    {
        [Required] public string CertificateName { get; set; }
        [Required] public string CertificateURL { get; set; }   
        [Required] public Guid IssuedBy { get; set; }
    }


    public class CommissionResponse
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; }
        public Guid UserId { get; set; }
        public string CommissionedBy { get; set; }     
        public DateTime CreatedAt { get; set; }

        public SafetyCheckResponse SafetyCheck { get; set; }
        public FunctionalTestResponse FunctionalTest { get; set; }
        public PunchListResponse PunchList { get; set; }
        public ClientTrainingResponse ClientTraining { get; set; }
        public GeneratedDocumentsCertificateResponse generatedDocumentsCertificate { get; set; }
    }

    public class SafetyCheckResponse
    {
        public Guid Id { get; set; }
        public string EmergencyStop { get; set; }
        public string DoorLocks { get; set; }
        public string Alarm { get; set; }
        public string Intercom { get; set; }
        public string OverloadProtection { get; set; }
        public string OverspeedGovernor { get; set; }
        public string SafetyGear { get; set; }
        public string Buffers { get; set; }
        public string LimitSwitches { get; set; }
        public string BrakeFunction { get; set; }
        public string LevellingAccuracy { get; set; }
        public string PhaseProtection { get; set; }
        public string Grounding { get; set; }
        public string ControllerFaultHistory { get; set; }
    }

    public class FunctionalTestResponse
    {
        public Guid Id { get; set; }
        public string CallButtons { get; set; }
        public string LandingIndicators { get; set; }
        public string CabinOperatingPanel { get; set; }
        public string DoorOpening { get; set; }
        public string DoorClosing { get; set; }
        public string RideQuality { get; set; }
        public string Speed { get; set; }
        public string Acceleration { get; set; }
        public string Deceleration { get; set; }
        public string FloorLevelling { get; set; }
        public string RescueOperation { get; set; }
        public string FiremanOperation { get; set; }
        public string ARDBehaviour { get; set; }
        public string UPSBehaviour { get; set; }
        public string PowerFailureResponse { get; set; }
    }

    public class PunchListResponse
    {
        public Guid Id { get; set; }
        public List<PunchResponse> Punches { get; set; } = new();
        public int TotalPunches { get; set; }
        public int OpenPunches { get; set; }
        public int ClosedPunches { get; set; }
    }

    public class PunchResponse
    {
        public Guid Id { get; set; }
        public string PunchDescription { get; set; }
        public string CorrectionRequired { get; set; }
        public string Severity { get; set; }
        public string ResponsibleParty { get; set; }
        public string Photo { get; set; }
        public DateTime DueDate { get; set; }
        public bool Closed { get; set; }
    }

    public class ClientTrainingResponse
    {
        public Guid Id { get; set; }
        public string Attendees { get; set; }
        public string TrainingTopics { get; set; }
        public string EmergencyRescueBasics { get; set; }
        public string OperatingPrecautions { get; set; }
        public string MaintenanceSchedule { get; set; }
        public string WarrantyTerms { get; set; }
        public string DocumentReceived { get; set; }
    }

    public class GeneratedDocumentsCertificateResponse
    {
        public Guid Id { get; set; }
        public List<CertificateResponse> Certificates { get; set; } = new();
    }

    public class CertificateResponse
    {
        public Guid Id { get; set; }
        public string CertificateName { get; set; }
        public string CertificateURL { get; set; }
        public string IssuedByName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
