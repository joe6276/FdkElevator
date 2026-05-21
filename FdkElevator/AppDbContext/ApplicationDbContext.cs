using FdkElevator.Models.Auth;
using FdkElevator.Models.Leads;
using FdkElevator.Models.Organization;
using FdkElevator.Models.Quotations;
using FdkElevator.Models.Surveyors;
using FdkElevator.Models.Tenants;
using Microsoft.EntityFrameworkCore;

namespace FdkElevator.AppDbContext
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options){ }

        public DbSet<Tenant> Tenants { get; set; }

        public DbSet<TenantSub> TenantSubs { get; set; }

        public DbSet<Organization> Organizations { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Lead> Leads { get; set; }

        public DbSet<Survey> Surveys { get; set; }

        public DbSet<Quotation> Quotations { get; set; }

        public DbSet<QuoteItem> QuoteItems { get; set; }


        public DbSet<Activity> Activities { get; set; }


        public DbSet<LiftConfiguration> liftConfigurations { get; set; }

    }
}
