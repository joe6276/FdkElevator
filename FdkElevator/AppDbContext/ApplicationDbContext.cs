using FdkElevator.Models.Organization;
using FdkElevator.Models.Tenant;
using Microsoft.EntityFrameworkCore;

namespace FdkElevator.AppDbContext
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options){ }

        public DbSet<Tenant> Tenants { get; set; }

        public DbSet<TenantSub> TenantSubs { get; set; }

        public DbSet<Organization> Organizations { get; set; }
    }
}
