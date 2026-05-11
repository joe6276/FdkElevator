using System.ComponentModel.DataAnnotations;

namespace FdkElevator.DTOS.Auth
{
    public class ResetRequest
    {
        [Required]
        public string Email { get; set; } = string.Empty;
    }
}
