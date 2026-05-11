using System.ComponentModel.DataAnnotations.Schema;

namespace FdkElevator.Models.Tenants
{
    public class TenantSub
    {

        public Guid Id { get; set; }

        public string StripeSessionId { get; set; } = string.Empty;


        public string? StripePaymentIntent { get; set; }

        public decimal Amount { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [ForeignKey("TenantId")]
        public Tenant Tenant { get; set; }
        public Guid TenantId { get; set; }
    }
}
