using FdkElevator.DTOS.SupplierDTO;
using FdkElevator.Models.Suppliers;

namespace FdkElevator.Services.IServices
{
    public interface ISupplier
    {

        string addSupplier(Supplier supplier);

        List<Supplier> getAllSuppliers();

        string updateSupplier(Supplier supplier);

        SupplierResponseDTO getSupplierById(Guid id);
        Supplier getSupplierById1(Guid id);
        string deleteSupplier(Supplier supplier);
    }
}
