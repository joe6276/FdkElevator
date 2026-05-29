namespace FdkElevator.DTOS.TenantDTOS
{
    public class TenantInformation
    {

        public string Name { get; set; } = string.Empty;

        public string Logo_URL { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        public bool isActive { get; set; } = false;


        public string? Warranty { get; set; }

        public string? TermsOfPayments { get; set; }

        public string? SpecialNotes { get; set; }
    }
}
