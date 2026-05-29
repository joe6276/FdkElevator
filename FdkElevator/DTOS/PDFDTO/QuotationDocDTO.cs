using FdkElevator.Models.Surveyors;

namespace FdkElevator.DTOS.PDFDTO
{

    public class QuotationRequest
    {
        public string QuotationNumber { get; set; } = string.Empty;
        public string QuotationDate { get; set; } = string.Empty;
        public string ProjectName { get; set; } = string.Empty;
        public string ClientName { get; set; } = string.Empty;
        public string ValidityDate { get; set; } = string.Empty;

        public QuotationCalculations QuotationCalculations { get; set; } = new();
        public QuotationLiftConfig QuotationLiftConfig { get; set; } = new();
        public QuotationSpecification QuotationSpec { get; set; } = new();
    }

    // ─── Financials ──────────────────────────────────────────────────────────────

    public class QuotationCalculations
    {
        public decimal Amount { get; set; }
        public decimal Discount { get; set; }
        public decimal SubTotal { get; set; }
        public decimal InstallationCost { get; set; }
        public decimal FreightCost { get; set; }
        public decimal CustomsCost { get; set; }
        public decimal SubcontractorCost { get; set; }

        public decimal GrandTotal =>
            SubTotal + InstallationCost + FreightCost + CustomsCost + SubcontractorCost;
    }

    // ─── Lift Configuration ───────────────────────────────────────────────────────

    public class QuotationLiftConfig
    {
        public string LiftType { get; set; } = string.Empty;
        public string DriveType { get; set; } = string.Empty;
        public string Capacity { get; set; } = string.Empty;
        public string Speed { get; set; } = string.Empty;
        public string Stops { get; set; } = string.Empty;
        public string DoorType { get; set; } = string.Empty;
        public string ControllerType { get; set; } = string.Empty;
        public string CabinFinish { get; set; } = string.Empty;
    }

    // ─── Survey Spec ─────────────────────────────────────────────────────────────

    public class QuotationSpecification
    {
        public ProjectInfo ProjectInfo { get; set; } = new();
        public ShaftStructuralInfo ShaftStructuralInfo { get; set; } = new();
        public EntranceDoorDetails EntranceDoorDetails { get; set; } = new();
        public PowerElectricalInfo PowerElectricalInfo { get; set; } = new();
        public UsageTrafficInfo UsageTrafficInfo { get; set; } = new();
        public FinishingDesignPrefs FinishingDesignPreferences { get; set; } = new();
        public SafetyComplianceInfo SafetyComplianceInfo { get; set; } = new();
        public MaintenanceServiceInfo MaintenanceServiceInfo { get; set; } = new();
        public AdditionalNotes AdditionalNotes { get; set; } = new();
    }

    public class ProjectInfo1
    {
        public int? ProjectType { get; set; }
        public int LiftTypeRequired { get; set; }
        public int NumberOfLiftsRequired { get; set; }
        public string ExpectedCapacity { get; set; } = string.Empty;
        public int NumberOfStopsFloors { get; set; }
        public double TravelHeightMeters { get; set; }
        public string EstimatedCompletionTimeline { get; set; } = string.Empty;
    }

    public class ShaftStructuralInfo
    {
        public int ShaftType { get; set; }
        public int ShaftLocation { get; set; }
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

    public class EntranceDoorDetails
    {
        public int NumberOfEntrances { get; set; }
        public int DoorOpeningType { get; set; }
        public string DoorSize { get; set; } = string.Empty;
        public string LandingDoorFinishPreference { get; set; } = string.Empty;
    }

    public class PowerElectricalInfo
    {
        public int PowerSupplyAvailable { get; set; }
        public string VoltageAvailable { get; set; } = string.Empty;
        public bool BackupGeneratorAvailable { get; set; }
        public bool DedicatedLiftPowerLineAvailable { get; set; }
    }

    public class UsageTrafficInfo
    {
        public int BuildingUsage { get; set; }
        public string EstimatedDailyTraffic { get; set; } = string.Empty;
        public string PeakUsageHours { get; set; } = string.Empty;
        public int AccessibilityRequirements { get; set; }
    }

    public class FinishingDesignPrefs
    {
        public string CabinFinishPreference { get; set; } = string.Empty;
        public string FlooringPreference { get; set; } = string.Empty;
        public string CeilingType { get; set; } = string.Empty;
        public bool MirrorRequired { get; set; }
        public bool HandrailsRequired { get; set; }
        public string DisplayTypePreference { get; set; } = string.Empty;
    }

    public class SafetyComplianceInfo
    {
        public bool FiremanOperationRequired { get; set; }
        public bool EmergencyRescueSystemRequired { get; set; }
        public bool CctvRequired { get; set; }
        public bool AccessControlRequired { get; set; }
        public string ComplianceStandardRequired { get; set; } = string.Empty;
    }

    public class MaintenanceServiceInfo
    {
        public bool MaintenanceContractRequired { get; set; }
        public bool ExistingLiftOnSite { get; set; }
        public string CurrentLiftCondition { get; set; } = string.Empty;
        public string ServiceFrequencyPreference { get; set; } = string.Empty;
    }

    public class AdditionalNotes
    {
        public string SpecialRequirements { get; set; } = string.Empty;
        public string SiteChallenges { get; set; } = string.Empty;
        public string CustomerComments { get; set; } = string.Empty;
        public string SurveyorRemarks { get; set; } = string.Empty;
    }


}
