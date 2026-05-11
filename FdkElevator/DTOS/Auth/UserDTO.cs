using FdkElevator.Models.Auth;
using System.ComponentModel.DataAnnotations;

namespace FdkElevator.DTOS.Auth
{
    public class UserDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        public Role Role { get; set; }

        [Required]
        public Guid TenantId { get; set; }

    }

    public class ResponseUserDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public Role Role { get; set; }


    }
}
