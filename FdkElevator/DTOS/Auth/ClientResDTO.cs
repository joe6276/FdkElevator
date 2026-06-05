namespace FdkElevator.DTOS.Auth
{
    public class ClientResDTO
    {
        public Guid ClientId { get; set; }
        public string ClientName { get; set; } = string.Empty;
    }
    public class ClientSummaryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? TenantName { get; set; }

        public List<ClientLeadResponse> Leads { get; set; } = new();
        public List<ClientProjectResponse> Projects { get; set; } = new();

        public int TotalLeads { get; set; }
        public int TotalProjects { get; set; }
    }

    public class ClientLeadResponse
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string ContactPerson { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string BuildingAddress { get; set; } = string.Empty;
        public int NumberOfFloors { get; set; }
        public int NumberOfElevators { get; set; }
        public string LeadStatus { get; set; } = string.Empty;
        public string LeadSource { get; set; } = string.Empty;
        public string LeadType { get; set; } = string.Empty;
        public string Urgency { get; set; } = string.Empty;
        public decimal? Budget { get; set; }
        public string DecisionMaker { get; set; } = string.Empty;
        public string? ReasonForLoss { get; set; }
        public string? AssignedSalesPerson { get; set; }   // populated by fix-up, not ThenInclude
        public DateTime CreatedAt { get; set; }

        public ClientQuotationResponse? Quotation { get; set; }
    }

    public class ClientQuotationResponse
    {
        public Guid Id { get; set; }
        public string QuotationNumber { get; set; } = string.Empty;
        public int Revision { get; set; }
        public float Amount { get; set; }
        public float SubTotal { get; set; }
        public float Discount { get; set; }
        public decimal InstallationCost { get; set; }
        public decimal FreightCost { get; set; }
        public decimal CustomsCost { get; set; }
        public decimal SubcontractorCost { get; set; }
        public string? Warranty { get; set; }
        public string? AmcOption { get; set; }
        public int ValidityDays { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }

    public class ClientProjectResponse
    {
        public Guid Id { get; set; }
        public string ProjectCode { get; set; } = string.Empty;
        public string ProjectStatus { get; set; } = string.Empty;
        public bool IsCivicReady { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool HasCommission { get; set; }
        public bool HasWarranty { get; set; }
    }
}
