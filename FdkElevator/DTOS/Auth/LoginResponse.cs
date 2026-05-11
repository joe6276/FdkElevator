using FdkElevator.Models.Auth;

namespace FdkElevator.DTOS.Auth
{
    public class LoginResponse
    {
        public string Token { get; set; } = string.Empty;

        public Guid TenantId { get; set; }
        public Guid UserId { get; set; }

        public Role Role { get; set; }

        public bool firstTimeLogin { get; set; }
    }
}
