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

    }
}
