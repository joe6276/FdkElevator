using FdkElevator.Models.Auth;
using FdkElevator.Models.Leads;
using FdkElevator.Models.Orders;
using FdkElevator.Models.Surveyors;
using FdkElevator.Models.Tenants;
using System.Diagnostics.Contracts;

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


        public string? Warranty { get; set; }

        public string? TermsOfPayments { get; set; }

        public string? SpecialNotes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Subscription_Plan? Subscription_Plan { get; set; }

        public Subscription_Status? Subscription_Status { get; set; }

        public DateTime SubscriptionExpiresAt { get; set; }

        public TenantSub TenantSub { get; set; }

        public ICollection<User> users { get; set; }

        public ICollection<Tenant> tenants { get; set; }

        public ICollection<AllSurvey> surveys { get; set; }

        public ICollection<Activity> activities { get; set; }

        public ICollection<Order> orders { get; set; }

        public ICollection<MyContract> contracts { get; set; }

    }
}
