using FdkElevator.Models.Orders;

namespace FdkElevator.DTOS.OrderDTO
{
  

    public class CreateOrderDTO
    {
        public Guid TenantId { get; set; }

        public Guid ProjectId { get; set; }

        public List<CreateOrderItemDTO> OrderItems { get; set; }

        public CreateShippingAddressDTO ShippingAddress { get; set; }
    }

    public class CreateOrderItemDTO
    {
        public Guid SupplierItemId { get; set; }
        public Guid SupplierId { get; set; }
    }

    public class CreateShippingAddressDTO
    {
        public string Street { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string County { get; set; } = string.Empty;

        public string PostalCode { get; set; } = string.Empty;
    }

    public class SupplierPaymentProgressDto
    {
        public Guid SupplierId { get; set; }

        public int TotalItems { get; set; }

        public int PaidItems { get; set; }

        public int PendingItems { get; set; }

        public decimal PaymentProgressPercentage { get; set; }

        public List<SupplierPaymentItemDto> Items { get; set; } = new();
    }

    public class SupplierPaymentItemDto
    {
        public Guid OrderId { get; set; }

        public Guid OrderItemId { get; set; }

        public DateTime OrderDate { get; set; }

        public string ItemName { get; set; } = string.Empty;

        public float Price { get; set; }

        public int Quantity { get; set; }

        public bool IsPaid { get; set; }

        public string Status => IsPaid ? "Paid" : "Pending";

        public string? PaymentImageUrl { get; set; }

        public OrderStatus OrderStatus { get; set; }
    }
}
