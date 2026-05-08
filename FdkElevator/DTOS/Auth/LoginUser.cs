using System.ComponentModel.DataAnnotations;

namespace FdkElevator.DTOS.Auth
{
    public class LoginUser
    {

        [EmailAddress]
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
