using FdkElevator.DTOS.ProjectDTOS;
using FdkElevator.DTOS.SelectionDTO;
using FdkElevator.Models.Selection;

namespace FdkElevator.Services.IServices
{
    public interface ISupplierSelection
    {

        List<SupplierSelectionDTO> getmaterials(Guid projectId);

        string addSelectedProducts(SelectedProduct selectedProduct);

        List<SelectedProduct> getSelectedProducts(Guid projectId);
        Task<SelectedProductResponseDTO> GetSelectedProductsByProjectId(Guid projectId);


        string approveSelectedProduct(Guid Id, Guid userid);

    }
}
