using FdkElevator.Models.Auth;

namespace FdkElevator.Models.Suppliers
{
    public class Supplier
    {

        public Guid Id { get; set; }

        public string Name { get; set; } =string.Empty;

        public string ContactEmail { get; set; } = string.Empty;

        public string ContactPhone { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public string PostalCode { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<SupplierItem> Suppliers { get; set; } = new List<SupplierItem>();

        public string PasswordResetToken { get; set; } = string.Empty;

        public DateTime PasswordResetExpires { get; set; } = DateTime.Now;

        public Role Role { get; set; }

        public string Password { get; set; } = string.Empty;
    }
}
