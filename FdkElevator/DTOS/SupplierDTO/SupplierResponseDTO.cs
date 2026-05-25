namespace FdkElevator.DTOS.SupplierDTO
{
    public class SupplierResponseDTO
    {

        public string Name { get; set; } = string.Empty;

        public string ContactEmail { get; set; } = string.Empty;

        public string ContactPhone { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public string PostalCode { get; set; } = string.Empty;

        public List<SupItemResponseDTO> Items { get; set; }

    }

    public class SupItemResponseDTO

    {
        public string ItemName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string? ImageURL { get; set; }
        public float Price { get; set; }
     
    }
}
