using FdkElevator.Models.Auth;

namespace FdkElevator.DTOS.Auth
{
    public class UserDTO
    {

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public Role Role { get; set; }


    }
}
