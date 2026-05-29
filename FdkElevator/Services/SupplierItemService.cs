using FdkElevator.AppDbContext;
using FdkElevator.Models.Suppliers;
using FdkElevator.Services.IServices;

namespace FdkElevator.Services
{
    public class SupplierItemService : ISupplierItem
    {
        private ApplicationDbContext _context;

        public SupplierItemService(ApplicationDbContext context)
        {
            _context= context;
        }
        public string addSupplierItem(SupplierItem supplierItem)
        {
            _context.supplierItems.Add(supplierItem);
            _context.SaveChanges();
            return "Supplier Item added successfully!";
        }

        public string addSuppliersItems(List<SupplierItem> items)
        {
            _context.supplierItems.AddRange(items);
            _context.SaveChanges();
            return "Items added";
        }

        public List<SupplierItem> getSuppliers(Guid Id)
        {
           return _context.supplierItems.Where(x => x.SupplierId == Id).ToList();
        }
    }
}
