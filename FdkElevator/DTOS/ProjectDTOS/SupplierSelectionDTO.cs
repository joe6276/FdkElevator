using FdkElevator.Models.Projects;
using FdkElevator.Models.Suppliers;

namespace FdkElevator.DTOS.ProjectDTOS
{
    public class SupplierSelectionDTO
    {
        public string MaterialName { get; set; }
        public List<SupplierItemDTO> Materials { get; set; }
    }
    public class SupplierItemDTO
    {   

        public Guid Id { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }

        public string SupplierName { get; set; }
    }

}
