using FdkElevator.DTOS.ProjectDTOS;

namespace FdkElevator.DTOS.SelectionDTO
{
 
    public class SelectedProductResponseDTO
    {
        public Guid SelectedProductId { get; set; }
        public Guid ProjectId { get; set; }
        public bool IsApproved { get; set; }

        public List<ProductResponseDTO> Products { get; set; }
    }

    public class ProductResponseDTO
    {
        public Guid ProductId { get; set; }
        public Guid SupplierItemId { get; set; }

        public string ItemName { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }

        public string SupplierName { get; set; }
    }
}
