using FdkElevator.Models.Auth;
using FdkElevator.Models.Leads;
using FdkElevator.Models.Tenants;
using System.ComponentModel.DataAnnotations.Schema;

namespace FdkElevator.Models.Surveyors
{

    public enum ProjectType
    {
        NewInstallation,
        Modernization,
        Replacement,
        Expansion
    }

    public enum LiftType
    {
        PassengerLift,
        CargoFreightLift,
        HospitalLift,
        HomeLift,
        PanoramicLift,
        ServiceLift
    }

    public enum ShaftType
    {
        ConcreteShaft,
        OpenSpaceShaft
    }

    public enum ShaftLocation
    {
        Indoors,
        Outdoors,
        BetweenStairs
    }

    public enum DoorOpeningType
    {
        CenterOpening,
        SideOpening
    }

    public enum PowerSupplyType
    {
        SinglePhase,
        ThreePhase
    }

    public enum BuildingUsage
    {
        Residential,
        Commercial,
        Hospital,
        Hotel,
        Industrial,
        MixedUse
    }
    public enum AccessibilityRequirement
    {
        None ,
        WheelchairAccess ,
        BrailleButtons ,
        VoiceAnnouncement,
        StretcherSize 
    }

    public class AllSurvey
    {      
        
        public Guid Id { get; set; }

        public decimal? Latitude { get; set; }

        public decimal? Longitude { get; set; }

        public ProjectInfo ProjectInfo { get; set; }

        public ShaftStructural ShaftStructuralInfo { get; set; } = null!;

        public EntranceDoor EntranceDoorDetails { get; set; } = null!;

        public PowerElectrical PowerElectricalInfo { get; set; } = null!;

        public UsageTraffic UsageTrafficInfo { get; set; } = null!;

        public FinishingDesign FinishingDesignPreferences { get; set; } = null!;

        public SafetyCompliance SafetyComplianceInfo { get; set; } = null!;

        public MaintenanceService MaintenanceServiceInfo { get; set; } = null!;

        public SiteMediaAttachment SiteMediaAttachments { get; set; } = null!;

        public AdditionalNote AdditionalNotes { get; set; } = null!;

        public Guid LeadId { get; set; }
        [ForeignKey("LeadId")]
        public Lead Lead { get; set; } = null!;
        [ForeignKey("SurveyorId")]
        public User User { get; set; } = null!;

        public Guid SurveyorId { get; set; } 

        [ForeignKey("TenantId")]
        public Tenant tenant { get; set; } = null!;

        public Guid TenantId { get; set; }

    }

    public class ProjectInfo
    {
        public Guid Id { get; set; }
        public ProjectType ProjectType { get; set; }
        public LiftType LiftTypeRequired { get; set; }
        public int NumberOfLiftsRequired { get; set; }
        public string ExpectedCapacity { get; set; } = string.Empty;
        public int NumberOfStopsFloors { get; set; }
        public double TravelHeightMeters { get; set; }
        public string EstimatedCompletionTimeline { get; set; } = string.Empty;
        public Guid SurveyId { get; set; }
        [ForeignKey("SurveyId")]
        public AllSurvey Survey { get; set; }
    }

    public class ShaftStructural
    {
        public Guid Id { get; set; }
        public ShaftType ShaftType { get; set; }
        public ShaftLocation ShaftLocation { get; set; }
        public bool CoreCuttingRequired { get; set; }
        public string ShaftSize { get; set; }
        public double ShaftHeight { get; set; }
        public double PitDepth { get; set; }
        public double OverheadHeightHeadroom { get; set; }
        public bool MachineRoomAvailability { get; set; }
        public string MachineRoomLocation { get; set; }
        public bool StructuralDrawingsAvailable { get; set; }
        public bool CivilWorksRequired { get; set; }
        public Guid SurveyId { get; set; }
        [ForeignKey("SurveyId")]
        public AllSurvey Survey { get; set; } = null!;

    }

    public class EntranceDoor
    {
        public Guid Id { get; set; }
        public int NumberOfEntrances { get; set; }
        public DoorOpeningType DoorOpeningType { get; set; }
        public string DoorSize { get; set; }
        public string LandingDoorFinishPreference { get; set; }

        public Guid SurveyId { get; set; }
        [ForeignKey("SurveyId")]
        public AllSurvey Survey { get; set; } = null!;
    }

    public class PowerElectrical
    {
        public Guid Id { get; set; }
        public PowerSupplyType PowerSupplyAvailable { get; set; }
        public string VoltageAvailable { get; set; }
        public bool BackupGeneratorAvailable { get; set; }
        public bool DedicatedLiftPowerLineAvailable { get; set; }
        public Guid SurveyId { get; set; }
        [ForeignKey("SurveyId")]
        public AllSurvey Survey { get; set; } = null!;
    }

    public class UsageTraffic
    {
        public Guid Id { get; set; }
        public BuildingUsage BuildingUsage { get; set; }
        public string EstimatedDailyTraffic { get; set; }
        public string PeakUsageHours { get; set; }
        public AccessibilityRequirement AccessibilityRequirements { get; set; }

        public Guid SurveyId { get; set; }
        [ForeignKey("SurveyId")]
        public AllSurvey Survey { get; set; } = null!;
    }
    public class FinishingDesign
    {   

        public Guid Id { get; set; }
        public string CabinFinishPreference { get; set; }
        public string FlooringPreference { get; set; }
        public string CeilingType { get; set; }
        public bool MirrorRequired { get; set; }
        public bool HandrailsRequired { get; set; }
        public string DisplayTypePreference { get; set; }
        public Guid SurveyId { get; set; }
        [ForeignKey("SurveyId")]
        public AllSurvey Survey { get; set; } = null!;
    }

    public class SafetyCompliance
    {   
        public Guid Id { get; set; }
        public bool FiremanOperationRequired { get; set; }
        public bool EmergencyRescueSystemRequired { get; set; }
        public bool CctvRequired { get; set; }
        public bool AccessControlRequired { get; set; }
        public string ComplianceStandardRequired { get; set; }
        public Guid SurveyId { get; set; }
        [ForeignKey("SurveyId")]
        public AllSurvey Survey { get; set; } = null!;

    }

    public class MaintenanceService
    {
        public Guid Id { get; set; }
        public bool MaintenanceContractRequired { get; set; }
        public bool ExistingLiftOnSite { get; set; }
        public string? CurrentLiftCondition { get; set; }
        public string? ServiceFrequencyPreference { get; set; }
        public Guid SurveyId { get; set; }
        [ForeignKey("SurveyId")]
        public AllSurvey Survey { get; set; } = null!;
    }

    public class SiteMediaAttachment
    {
        public Guid Id { get; set; }
        public List<string> SiteAttachments { get; set; } = [];
        public Guid SurveyId { get; set; }
        [ForeignKey("SurveyId")]
        public AllSurvey Survey { get; set; } = null!;
    }

    /// <summary>Section 11 — Additional Notes.</summary>
    public class AdditionalNote
    {
        public Guid Id { get; set; }
        public string? SpecialRequirements { get; set; }
        public string? SiteChallenges { get; set; }
        public string? CustomerComments { get; set; }
        public string? SurveyorRemarks { get; set; }

        public Guid SurveyId { get; set; }
        [ForeignKey("SurveyId")]
        public AllSurvey Survey { get; set; }
    }
}
