namespace FdkElevator.Models.Suppliers
{
    public class SupplierItem
    {
        public Guid Id { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string? ImageURL { get; set; }
        public float Price { get; set; }
        public Guid SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
