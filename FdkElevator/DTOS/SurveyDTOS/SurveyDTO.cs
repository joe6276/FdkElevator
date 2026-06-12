using FdkElevator.Models.Auth;
using FdkElevator.Models.Leads;
using FdkElevator.Models.Surveyors;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FdkElevator.DTOS.SurveyDTOS
{


    public class AssignSurveyDTO
    {
        [Required]
        public Guid LeadId { get; set; }
        [Required]
        public Guid SurveyorId { get; set; }
        [Required]
        public Guid TenantId { get; set; }
    }
    public class SurveyDTO
    {
        [Required]
        public decimal? Latitude { get; set; }
        [Required]
        public decimal? Longitude { get; set; }

        [Required]
        public ProjectInfoRequest ProjectInfo { get; set; } = new();
        [Required]
        public ShaftStructuralRequest ShaftStructural { get; set; } = new();
        [Required]
        public EntranceDoorRequest EntranceDoor { get; set; } = new();
        [Required]
        public PowerElectricalRequest PowerElectrical { get; set; } = new();
        [Required]
        public UsageTrafficRequest UsageTraffic { get; set; } = new();
        [Required]
        public FinishingDesignRequest FinishingDesign { get; set; } = new();
        [Required]
        public SafetyComplianceRequest SafetyCompliance { get; set; } = new();
        [Required]
        public MaintenanceServiceRequest MaintenanceService { get; set; } = new();
        [Required]
        public SiteMediaAttachmentRequest SiteMediaAttachments { get; set; } = new();
        [Required]
        public AdditionalNoteRequest AdditionalNotes { get; set; } = new();
    }

    public class ProjectInfoRequest
    {
        [Required]
        public ProjectType ProjectType { get; set; }
        [Required]
        public LiftType LiftTypeRequired { get; set; }
        [Required]
        public int NumberOfLiftsRequired { get; set; }
        [Required]
        public string ExpectedCapacity { get; set; } = string.Empty;
        [Required]
        public int NumberOfStopsFloors { get; set; }
        [Required]
        public double TravelHeightMeters { get; set; }
        [Required]
        public string EstimatedCompletionTimeline { get; set; } = string.Empty;
    }

    public class ShaftStructuralRequest
    {
        [Required]
        public ShaftType ShaftType { get; set; }
        [Required]
        public ShaftLocation ShaftLocation { get; set; }
        [Required]
        public bool CoreCuttingRequired { get; set; }
        [Required]
        public string ShaftSize { get; set; } = string.Empty;
        [Required]
        public double ShaftHeight { get; set; }
        [Required]
        public double PitDepth { get; set; }
        [Required]
        public double OverheadHeightHeadroom { get; set; }
        [Required]
        public bool MachineRoomAvailability { get; set; }
        [Required]
        public string MachineRoomLocation { get; set; } = string.Empty;
        [Required]
        public bool StructuralDrawingsAvailable { get; set; }
        [Required]
        public bool CivilWorksRequired { get; set; }
    }

    public class EntranceDoorRequest
    {
        [Required]
        public int NumberOfEntrances { get; set; }
        [Required]
        public DoorOpeningType DoorOpeningType { get; set; }
        [Required]
        public string DoorSize { get; set; } = string.Empty;
        [Required]
        public string LandingDoorFinishPreference { get; set; } = string.Empty;
    }

    public class PowerElectricalRequest
    {
        [Required]
        public PowerSupplyType PowerSupplyAvailable { get; set; }
        [Required]
        public string VoltageAvailable { get; set; } = string.Empty;
        [Required]
        public bool BackupGeneratorAvailable { get; set; }
        [Required]
        public bool DedicatedLiftPowerLineAvailable { get; set; }
    }

    public class UsageTrafficRequest
    {
        [Required]
        public BuildingUsage BuildingUsage { get; set; }
        [Required]
        public string EstimatedDailyTraffic { get; set; } = string.Empty;
        [Required]
        public string PeakUsageHours { get; set; } = string.Empty;
        [Required]
        public AccessibilityRequirement AccessibilityRequirements { get; set; }
    }

    public class FinishingDesignRequest
    {
        [Required]
        public string CabinFinishPreference { get; set; } = string.Empty;
        [Required]
        public string FlooringPreference { get; set; } = string.Empty;
        [Required]
        public string CeilingType { get; set; } = string.Empty;
        [Required]
        public bool MirrorRequired { get; set; }
        [Required]
        public bool HandrailsRequired { get; set; }
        [Required]
        public string DisplayTypePreference { get; set; } = string.Empty;
    }

    public class SafetyComplianceRequest
    {
        [Required]
        public bool FiremanOperationRequired { get; set; }
        [Required]
        public bool EmergencyRescueSystemRequired { get; set; }
        [Required]
        public bool CctvRequired { get; set; }
        [Required]
        public bool AccessControlRequired { get; set; }
        [Required]
        public string ComplianceStandardRequired { get; set; } = string.Empty;
    }

    public class MaintenanceServiceRequest
    {
        [Required]
        public bool MaintenanceContractRequired { get; set; }
        [Required]
        public bool ExistingLiftOnSite { get; set; }
        public string? CurrentLiftCondition { get; set; }
        public string? ServiceFrequencyPreference { get; set; }
    }

    public class SiteMediaAttachmentRequest
    {
        [Required]
        public List<string> SiteAttachments { get; set; } = [];
    }

    public class AdditionalNoteRequest
    {
        public string? SpecialRequirements { get; set; }
        public string? SiteChallenges { get; set; }
        public string? CustomerComments { get; set; }
        public string? SurveyorRemarks { get; set; }
    }



    public class SurveyResponse
    {
        public Guid Id { get; set; }
        public Guid LeadId { get; set; }
        public Guid SurveyorId { get; set; }
        public Guid TenantId { get; set; }

        public ProjectInfoResponse ProjectInfo { get; set; } = new();
        public ShaftStructuralResponse ShaftStructural { get; set; } = new();
        public EntranceDoorResponse EntranceDoor { get; set; } = new();
        public PowerElectricalResponse PowerElectrical { get; set; } = new();
        public UsageTrafficResponse UsageTraffic { get; set; } = new();
        public FinishingDesignResponse FinishingDesign { get; set; } = new();
        public SafetyComplianceResponse SafetyCompliance { get; set; } = new();
        public MaintenanceServiceResponse MaintenanceService { get; set; } = new();
        public SiteMediaAttachmentResponse SiteMediaAttachments { get; set; } = new();
        public AdditionalNoteResponse AdditionalNotes { get; set; } = new();
    }

    public class ProjectInfoResponse
    {
        public Guid Id { get; set; }
        public ProjectType ProjectType { get; set; }
        public LiftType LiftTypeRequired { get; set; }
        public int NumberOfLiftsRequired { get; set; }
        public string ExpectedCapacity { get; set; } = string.Empty;
        public int NumberOfStopsFloors { get; set; }
        public double TravelHeightMeters { get; set; }
        public string EstimatedCompletionTimeline { get; set; } = string.Empty;
    }

    public class ShaftStructuralResponse
    {
        public Guid Id { get; set; }
        public ShaftType ShaftType { get; set; }
        public ShaftLocation ShaftLocation { get; set; }
        public bool CoreCuttingRequired { get; set; }
        public string ShaftSize { get; set; } = string.Empty;
        public double ShaftHeight { get; set; }
        public double PitDepth { get; set; }
        public double OverheadHeightHeadroom { get; set; }
        public bool MachineRoomAvailability { get; set; }
        public string MachineRoomLocation { get; set; } = string.Empty;
        public bool StructuralDrawingsAvailable { get; set; }
        public bool CivilWorksRequired { get; set; }
    }

    public class EntranceDoorResponse
    {
        public Guid Id { get; set; }
        public int NumberOfEntrances { get; set; }
        public DoorOpeningType DoorOpeningType { get; set; }
        public string DoorSize { get; set; } = string.Empty;
        public string LandingDoorFinishPreference { get; set; } = string.Empty;
    }

    public class PowerElectricalResponse
    {
        public Guid Id { get; set; }
        public PowerSupplyType PowerSupplyAvailable { get; set; }
        public string VoltageAvailable { get; set; } = string.Empty;
        public bool BackupGeneratorAvailable { get; set; }
        public bool DedicatedLiftPowerLineAvailable { get; set; }
    }

    public class UsageTrafficResponse
    {
        public Guid Id { get; set; }
        public BuildingUsage BuildingUsage { get; set; }
        public string EstimatedDailyTraffic { get; set; } = string.Empty;
        public string PeakUsageHours { get; set; } = string.Empty;
        public AccessibilityRequirement AccessibilityRequirements { get; set; }
    }

    public class FinishingDesignResponse
    {
        public Guid Id { get; set; }
        public string CabinFinishPreference { get; set; } = string.Empty;
        public string FlooringPreference { get; set; } = string.Empty;
        public string CeilingType { get; set; } = string.Empty;
        public bool MirrorRequired { get; set; }
        public bool HandrailsRequired { get; set; }
        public string DisplayTypePreference { get; set; } = string.Empty;
    }

    public class SafetyComplianceResponse
    {
        public Guid Id { get; set; }
        public bool FiremanOperationRequired { get; set; }
        public bool EmergencyRescueSystemRequired { get; set; }
        public bool CctvRequired { get; set; }
        public bool AccessControlRequired { get; set; }
        public string ComplianceStandardRequired { get; set; } = string.Empty;
    }

    public class MaintenanceServiceResponse
    {
        public Guid Id { get; set; }
        public bool MaintenanceContractRequired { get; set; }
        public bool ExistingLiftOnSite { get; set; }
        public string? CurrentLiftCondition { get; set; }
        public string? ServiceFrequencyPreference { get; set; }
    }

    public class SiteMediaAttachmentResponse
    {
        public Guid Id { get; set; }
        public List<string> SiteAttachments { get; set; } = [];
    }

    public class AdditionalNoteResponse
    {
        public Guid Id { get; set; }
        public string? SpecialRequirements { get; set; }
        public string? SiteChallenges { get; set; }
        public string? CustomerComments { get; set; }
        public string? SurveyorRemarks { get; set; }
    }
}
