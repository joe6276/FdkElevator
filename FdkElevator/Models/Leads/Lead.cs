using FdkElevator.Models.Auth;
using FdkElevator.Models.Quotations;
using FdkElevator.Models.Surveyors;
using FdkElevator.Models.Tenants;
using System.ComponentModel.DataAnnotations.Schema;

namespace FdkElevator.Models.Leads
{   

    public enum ClientCategory
    {
        Residential,
        Commercial,
        Industrial,
        Hospital,
        Mall,
        Hotel,
        Contractor,
        Government_Institution,
        Property_Developer

    }

    public enum Status
    {
        New,
        Contacted,
        Being_Surveyed,
        Qualified,
        Lost,
        Converted
    }

    public enum LeadSource
    {
        Website,
        Phone,
        WhatsApp,
        Referral,
        Tender,
        Walk_In,
        Other
    }

    public enum LeadType
    {
        New_Installation,
        Modernization,
        AMC,
        Repair,
        Spare_Parts
    }

    public enum Urgency
    {
        Low,
        Medium,
        High
    }
    public class Lead
    {

        public Guid Id { get; set; }

        [ForeignKey("TenantId")]
        public Tenant Tenant { get; set; }

        public Guid TenantId { get; set; }

        public ClientCategory clientCategory { get; set; }

        public string CompanyName { get; set; } = string.Empty;

        public string ContactPerson { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public float Longitude { get; set; }

        public float Latitude { get; set; }
            
        public LeadSource source { get; set; } 

        public LeadType leadType { get; set; }

        public Urgency urgency { get; set; }

        public decimal?  budget { get; set; }

        public string decisionMaker { get; set; } = string.Empty;

        public string? ReasonForLoss { get; set; } = string.Empty;
        public string Building_Address { get; set; } = string.Empty;

        public int NumberofFloors { get; set; }

        public int NumberofElevators { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey("SalesPersonId")]
        public User User { get; set; }

        public Guid  SalesPersonId { get; set; }

        public Status leadStatus { get; set; } = Status.New;

        public Survey survey { get; set; }
      
        public Quotation quotation { get; set; }

        public ICollection<Activity> activities { get; set; }

     

    }
}
