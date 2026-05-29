namespace FdkElevator.DTOS.OrderDTO
{
  

    public class CreateOrderDTO
    {
        public Guid TenantId { get; set; }

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
}
