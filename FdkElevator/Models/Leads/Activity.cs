using FdkElevator.Models.Auth;
using FdkElevator.Models.Tenants;
using System.ComponentModel.DataAnnotations.Schema;

namespace FdkElevator.Models.Leads
{   

    public enum ActivityType
    {
        Call,
        Email,
        Meeting,
        Note
    }
    public class Activity
    {

        public Guid Id { get; set; }
        public Guid LeadId { get; set; }

        public Guid TenantId { get; set; }
        public ActivityType type { get; set; }
        public Guid UserId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

       
        [ForeignKey("LeadId")]
        public Lead Lead { get; set; }
        [ForeignKey("TenantId")]
        public Tenant Tenant { get; set; }

        [ForeignKey("UserId")]
        public User user { get; set; }
    }
}
