using FdkElevator.Models.Auth;
using FdkElevator.Models.Projects;
using System.ComponentModel.DataAnnotations.Schema;

namespace FdkElevator.DTOS.SelectionDTO
{
    public class SelectedProductDTO
    {
            public Guid ProjectId { get; set; }
           
            public ICollection<ProductDTO> selectedProducts { get; set; }

        }

        public class ProductDTO
        {
            public Guid SupplierItemId { get; set; }

        }


    public class ApproveSelectedProducts
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
    }
    
}
