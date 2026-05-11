using FdkElevator.Models.Auth;
using FdkElevator.Models.Leads;
using FdkElevator.Models.Tenants;
using System.ComponentModel.DataAnnotations.Schema;

namespace FdkElevator.Models.Surveyors
{
    public class Survey
    {

        public Guid Id { get; set; }
        [ForeignKey("LeadId")]

        public Lead Lead { get; set; }

        public Guid LeadId { get; set; }

        [ForeignKey("SurveyorId")]
        public User User { get; set; }

        public Guid SurveyorId { get; set; }

        [ForeignKey("TenantId")]
        public Tenant tenant { get; set; }

        public Guid TenantId { get; set; }

        public int PitDepth { get; set; }

        public int numberofStops { get; set; }

        public int ShaftWidth { get; set; }

        public int ShaftDepth { get; set; }

        public int OverheadClearance { get; set; }

        public string PowerSupply { get; set; } = string.Empty;

        public bool CivicReady { get; set; }

        public bool MachineRoom { get; set; }

        public bool MLROption { get; set; }

        public bool ShaftAvailable { get; set; }

        public string CivicWorkRequired { get; set; } = string.Empty;

        public string AccessRoute { get; set; } = string.Empty;

        public string StorageArea { get; set; } = string.Empty;

        public string SafetyRisk { get; set; } = string.Empty;

        public string RecommendedLift { get; set; } = string.Empty;


        public string EngineerNotes { get; set; } = string.Empty;


        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
