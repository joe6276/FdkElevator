using FdkElevator.Models.Suppliers;

namespace FdkElevator.Services.IServices
{
    public interface ISupplierItem
    {

        string addSupplierItem(SupplierItem supplierItem);

        List<SupplierItem> getSuppliers( Guid Id);


    }
}
