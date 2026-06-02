using System.ComponentModel.DataAnnotations.Schema;

namespace FdkElevator.Models.Tenants
{
    public class MyContract
    {

        public Guid Id { get; set; }

        public Guid TenantId { get; set; }

        [ForeignKey("TenantId")]
        public Tenant Tenant { get; set; } = null!;

        public string ContractName { get; set; } = string.Empty;

        public string ContractLink { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
