using FdkElevator.Models.Auth;
using FdkElevator.Models.Leads;
using FdkElevator.Models.Tenants;
using System.ComponentModel.DataAnnotations.Schema;

namespace FdkElevator.DTOS.LeadDTOS
{
    public class LeadDTO
    {
     

        public Guid TenantId { get; set; }

        public ClientCategory clientCategory { get; set; }

        public string CompanyName { get; set; } = string.Empty;

        public string ContactPerson { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public float Longitude { get; set; }

        public float Latitude { get; set; }

        public string Building_Address { get; set; } = string.Empty;

        public int NumberofFloors { get; set; }

        public int NumberofElevators { get; set; }

        public Guid SalesPersonId { get; set; }

        public LeadSource source { get; set; }

        public LeadType leadType { get; set; }

        public Urgency urgency { get; set; }

        public decimal? budget { get; set; }

        public string decisionMaker { get; set; } = string.Empty;

    }

    public class LeadResDTO
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public ClientCategory clientCategory { get; set; }

        public string CompanyName { get; set; } = string.Empty;

        public string ContactPerson { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public float Longitude { get; set; }

        public float Latitude { get; set; }

        public string Building_Address { get; set; } = string.Empty;

        public int NumberofFloors { get; set; }

        public int NumberofElevators { get; set; }

        public Guid SalesPersonId { get; set; }

        public Status leadStatus { get; set; }

        public LeadSource source { get; set; }

        public LeadType leadType { get; set; }

        public Urgency urgency { get; set; }

        public decimal? budget { get; set; }

        public string decisionMaker { get; set; } = string.Empty;

    }

    public class LeadResponseDTO
    {

        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public ClientCategory clientCategory { get; set; }

        public string CompanyName { get; set; } = string.Empty;

        public string ContactPerson { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public float Longitude { get; set; }

        public float Latitude { get; set; }

        public string Building_Address { get; set; } = string.Empty;

        public int NumberofFloors { get; set; }

        public int NumberofElevators { get; set; }

        public Guid SalesPersonId { get; set; }

        public Status leadStatus { get; set; }

        public SurveyResposeDTO? survey { get; set; }


        public LeadSource source { get; set; }

        public LeadType leadType { get; set; }

        public Urgency urgency { get; set; }

        public decimal? budget { get; set; }

        public string decisionMaker { get; set; } = string.Empty;

    }


    public class LeadGroupedDictionaryDto
    {
        public Dictionary<string, List<LeadResDTO>> Data { get; set; }
    }

    public class SurveyResposeDTO
    {
        public Guid Id { get; set; }
        public Guid SurveyorId { get; set; }
        public Guid LeadId { get; set; }
        public int? PitDepth { get; set; }

        public int? numberofStops { get; set; }

        public int? ShaftWidth { get; set; }

        public int? ShaftDepth { get; set; }

        public int? OverheadClearance { get; set; }

        public string? PowerSupply { get; set; } = string.Empty;

        public bool? CivicReady { get; set; }

        public bool? MachineRoom { get; set; }

        public bool? MLROption { get; set; }

        public bool? ShaftAvailable { get; set; }

        public string? CivicWorkRequired { get; set; } = string.Empty;

        public string? AccessRoute { get; set; } = string.Empty;

        public string? StorageArea { get; set; } = string.Empty;

        public string? SafetyRisk { get; set; } = string.Empty;

        public string? RecommendedLift { get; set; } = string.Empty;


        public string? EngineerNotes { get; set; } = string.Empty;
    }
}
