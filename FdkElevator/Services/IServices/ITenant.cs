using FdkElevator.Models.Tenants;

namespace FdkElevator.Services.IServices
{
    public interface ITenant
    {

        string Addtenant(Tenant tenant);

        List<Tenant> getAllActiveTenants();

        List<Tenant> getAllInActiveTenants();
        Tenant getTenantById(Guid id);

        string UpdateTenant(Tenant tenant);

        string DeleteTenant(Tenant tenant);
    }
}
