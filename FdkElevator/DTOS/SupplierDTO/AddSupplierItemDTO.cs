namespace FdkElevator.DTOS.SupplierDTO
{
    public class AddSupplierItemDTO
    {
        public string ItemName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string? ImageURL { get; set; }
        public float Price { get; set; }
        public Guid SupplierId { get; set; }
    }
}
