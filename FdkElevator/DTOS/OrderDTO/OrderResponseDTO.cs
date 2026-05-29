using FdkElevator.Models.Orders;

namespace FdkElevator.DTOS.OrderDTO
{
    public class OrderResponseDTO
    {

        public Guid Id { get; set; }

        public float Total { get; set; }

        public ICollection<OrderItemResponseDTo> Items { get; set; }

        public OrderShippingDTO ShippingAddress { get; set; }
    }

    public class OrderItemResponseDTo
    {   

        public Guid Id { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string? ImageURL { get; set; }
        public float Price { get; set; }
        public Guid SupplierId { get; set; }
    }

    public class OrderShippingDTO
    {

        public string Street { get; set; } = string.Empty;

        public string City { get; set; }

        public string County { get; set; }
        public string PostalCode { get; set; }
        public Order Order { get; set; }
        public Guid OrderId { get; set; }
    }


    public class OrderPaymentDTO
    {
        public Guid OrderItemId { get; set; }

        public string PaymentImageURL { get; set; } = string.Empty;
    }
}
