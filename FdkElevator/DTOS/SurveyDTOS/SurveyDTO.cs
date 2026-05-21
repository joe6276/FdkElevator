using FdkElevator.Models.Auth;
using FdkElevator.Models.Leads;
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
        [Required]
        public string Notes { get; set; } = string.Empty;

    }
    public class SurveyDTO
    {
        [Required]
        public int PitDepth { get; set; }
        [Required]
        public int numberofStops { get; set; }
        [Required]
        public int ShaftWidth { get; set; }
        [Required]
        public int ShaftDepth { get; set; }
        [Required]
        public int OverheadClearance { get; set; }
        [Required]
        public string PowerSupply { get; set; } = string.Empty;
        [Required]
        public bool CivicReady { get; set; }
        [Required]
        public bool MachineRoom { get; set; }
        [Required]
        public bool MLROption { get; set; }
        [Required]
        public bool ShaftAvailable { get; set; }
        [Required]
        public string CivicWorkRequired { get; set; } = string.Empty;
        [Required]
        public string AccessRoute { get; set; } = string.Empty;
        [Required]
        public string StorageArea { get; set; } = string.Empty;
        [Required]
        public string SafetyRisk { get; set; } = string.Empty;
        [Required]
        public string RecommendedLift { get; set; } = string.Empty;
        [Required]
        public string EngineerNotes { get; set; } = string.Empty;
    }
}
