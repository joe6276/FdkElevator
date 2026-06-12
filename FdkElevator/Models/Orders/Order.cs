using FdkElevator.Models.Suppliers;
using FdkElevator.Models.Tenants;
using System.ComponentModel.DataAnnotations.Schema;

namespace FdkElevator.Models.Orders
{
   public enum OrderStatus
    {
        Draft,
        Issued,
        Supplier_Confirmed,
        Partially_Received,
        Closed
    
    }
    public class Order
    {

        public Guid Id { get; set; }

        public float Total { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

        public ShippingAddress ShippingAddress { get; set; }

        public OrderStatus Status { get; set; } = OrderStatus.Draft;
        public DateTime OrderDate { get; set; }

        [ForeignKey("TenantId")]
        public Tenant Tenant { get; set; }

        public Guid TenantId { get; set; }
    }


    public class OrderItem
    {
        public Guid Id { get; set; }
        public bool isPaid { get; set; } = false;

        [ForeignKey("SupplierItemId")]
        public SupplierItem SupplierItem { get; set; }

        public Guid SupplierItemId { get; set; }
        public Guid SupplierId { get; set; }
        public string? PaymentImageURL { get; set; }
        public Order Order { get; set; }
        public Guid OrderId { get; set; }
    }


    public class ShippingAddress
    {
        public Guid Id { get; set; }

        public string Street { get; set; } = string.Empty;

        public string City { get; set; }

        public string County { get; set; }
        public string PostalCode { get; set; }
        public Order Order { get; set; }
        public Guid OrderId { get; set; }

    }
}
