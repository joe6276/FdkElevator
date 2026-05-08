using FdkElevator.Models.Tenant;

namespace FdkElevator.DTOS.TenantDTOS
{
    public class TenantDTO
    {

        public string Name { get; set; } = string.Empty;

        public string Logo_URL { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

    }
}
