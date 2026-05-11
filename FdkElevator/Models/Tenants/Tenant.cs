using FdkElevator.Models.Auth;
using FdkElevator.Models.Tenants;

namespace FdkElevator.Models.Tenants
{
    public enum Subscription_Plan
    {
        Free,
        Basic,
        Premium
    }

    public enum Subscription_Status
    {
        Active,
        Inactive,
        Expired
    }
    public class Tenant
    {

        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Logo_URL { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        public bool isActive { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Subscription_Plan? Subscription_Plan { get; set; }

        public Subscription_Status? Subscription_Status { get; set; }

        public DateTime SubscriptionExpiresAt { get; set; }

        public TenantSub TenantSub { get; set; }

        public ICollection<User> users { get; set; }

    }
}
