using FdkElevator.AppDbContext;
using FdkElevator.Models.Tenants;
using FdkElevator.Services.IServices;

namespace FdkElevator.Services
{
    public class TenantService : ITenant
    {

        private readonly ApplicationDbContext _context;
        public TenantService(ApplicationDbContext context)
        {
            _context = context;
        }
        public string Addtenant(Tenant tenant)
        {
           _context.Tenants.Add(tenant);
            _context.SaveChanges();
            return "Tenant added successfully";
        }

        public string DeleteTenant(Tenant tenant)
        {
           _context.Tenants.Remove(tenant);
            _context.SaveChanges();
            return "Tenant deleted successfully";
        }

        public List<Tenant> getAllActiveTenants()
        {
           return _context.Tenants.Where(t => t.isActive == true).ToList();
        }

        public List<Tenant> getAllInActiveTenants()
        {
           return _context.Tenants.Where(t => t.isActive ==false).ToList();
        }

        public Tenant getTenantById(Guid id)
        {
            return _context.Tenants.FirstOrDefault(t => t.Id == id);
        }

        public string UpdateTenant(Tenant tenant)
        {
          _context.Tenants.Update(tenant);
            _context.SaveChanges();
            return "Tenant updated successfully";
        }
    }
}
