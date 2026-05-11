using FdkElevator.Models.Tenants;
using System.ComponentModel.DataAnnotations.Schema;



namespace FdkElevator.Models.Auth
{

    public enum Role
    {
        Admin,
        Sales,
        Survey_Eng,
        Procurement,
        Warehouse,
        Project_Manager,
        Technician,
        QA,
        Client,
        SubContractor
    }
    public class User
    {

        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;


        public string PasswordResetToken { get; set; } = string.Empty;

        public DateTime PasswordResetExpires { get; set; } = DateTime.Now;

        public Role Role { get; set; }

        public bool FirstTimeLogin { get; set; } = false;

        [ForeignKey("TenantId")]
        public Tenant tenants { get; set; }
        public Guid  TenantId { get; set; }
}
}
