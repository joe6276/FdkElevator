using FdkElevator.Models.Auth;
using FdkElevator.Models.Projects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FdkElevator.Models.Commissions
{

    public class Commission
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Project project { get; set; }
        public Guid CommissionedBy { get; set; }
        [ForeignKey("CommissionedBy")]
        public User user { get; set; }

        public SafetyCheck safetyCheck { get; set; }

        public FunctionalTest functionalTest { get; set; }

        public PunchList punchList { get; set; }

        public ClientTraining clientTraining { get; set; }

        public GeneratedDocumentsCertificate generatedDocumentsCertificate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
    public class SafetyCheck
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
        public string Phaseprotection { get; set; }
        public string Grounding { get; set; }
        public string ControllerFaultHistory { get; set; }
        public Commission Commission { get; set; }
        public Guid CommissionId { get; set; }

    }

    public class FunctionalTest
    {
        public Guid Id { get; set; }
        public string CallButtons { get; set; }
        public string LandingIndicators { get; set; }
        public string CabinOperatingPanel { get; set; }
        public string DoorOpening { get; set; }
        public string DoorClosing { get; set; }
        public string RideQuality { get; set; }
        public string Speed { get; set; }
        public string Deceleration { get; set; }
        public string Acceleration { get; set; }
        public string FloorLevelling { get; set; }
        public string RescueOperation { get; set; }
        public string FiremanOperation { get; set; }
        public string ARDBehaviour { get; set; }
        public string UPSBehaviour { get; set; }
        public string PowerFailureResponse { get; set; }
        public Commission Commission { get; set; }
        public Guid CommissionId { get; set; }
    }

    public class PunchList
    {
        public Guid Id { get; set; }
        public Commission Commission { get; set; }
        public Guid CommissionId { get; set; }

        public ICollection<Punch> Punches { get; set; }

    }

    public class Punch
    {
        public Guid Id { get; set; }

        public string PunchDescription { get; set; }

        public string CorrectionRequired { get; set; }

        public string Severity { get; set; }

        public string Photo { get; set; }

        public string ResponsibleParty { get; set; }

        public DateTime DueDate { get; set; }

        public bool Closed { get; set; } = false;

        public Guid PunchListId { get; set; }
        public PunchList PunchList { get; set; }
    }


    public class ClientTraining
    {
        public Guid Id { get; set; }

        public string Attendees { get; set; }

        public string TrainingTopics { get; set; }

        public string EmergencyRescueBasics { get; set; }

        public string OperatingPrecautions { get; set; }


        public string MaintenanceSchedule { get; set; }

        public string WarrantyTerms { get; set; }

        public string DocumentReceived { get; set; }

        public Commission Commission { get; set; }
        public Guid CommissionId { get; set; }

    }

    public class GeneratedDocumentsCertificate
    {
        public Guid Id { get; set; }
        public Commission Commission { get; set; }
        public Guid CommissionId { get; set; }

        public ICollection<Certificate> Certificates { get; set; }
    }

    public class Certificate
    {
        public Guid Id { get; set; }
        public string CertificateName { get; set; }
        public string CertificateURL { get; set; }

        [ForeignKey("IssuedBy")]
        public User user { get; set; }
        public Guid IssuedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Guid GeneratedDocumentsCertificateId { get; set; }
        [ForeignKey("GeneratedDocumentsCertificateId")]
        public GeneratedDocumentsCertificate GetGeneratedDocumentsCertificate { get; set; }
    }
}
