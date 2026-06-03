using FdkElevator.DTOS.Auth;
using FdkElevator.DTOS.SupplierDTO;
using FdkElevator.Models.Suppliers;

namespace FdkElevator.Services.IServices
{
    public interface ISupplier
    {

        Task<string> addSupplier(Supplier supplier);

        List<Supplier> getAllSuppliers();

        string updateSupplier(Supplier supplier);

        LoginResponse loginUser(string email, string password);

        SupplierResponseDTO getSupplierById(Guid id);
        Supplier getSupplierById1(Guid id);
        string deleteSupplier(Supplier supplier);
    }
}
