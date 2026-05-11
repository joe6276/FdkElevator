using FdkElevator.Models.Auth;
using FdkElevator.Models.Leads;
using System.ComponentModel.DataAnnotations.Schema;

namespace FdkElevator.DTOS.SurveyDTOS
{
    public class SurveyDTO
    {

        public Guid LeadId { get; set; }

        public Guid SurveyorId { get; set; }

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
    }
}
