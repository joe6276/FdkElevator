using FdkElevator.Models.Auth;
using FdkElevator.Models.Civil;
using FdkElevator.Models.Installations;
using FdkElevator.Models.Leads;
using FdkElevator.Models.Orders;
using FdkElevator.Models.Organization;
using FdkElevator.Models.Projects;
using FdkElevator.Models.Quotations;
using FdkElevator.Models.Selection;
using FdkElevator.Models.Suppliers;
using FdkElevator.Models.Surveyors;
using FdkElevator.Models.Tenants;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

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

        public DbSet<AllSurvey> AllSurveys { get; set; }

        public DbSet<Quotation> Quotations { get; set; }

        public DbSet<QuoteItem> QuoteItems { get; set; }


        public DbSet<Activity> Activities { get; set; }


        public DbSet<LiftConfiguration> liftConfigurations { get; set; }

        public DbSet<QuotationPayment> quotationPayments { get; set; }

        public DbSet<LiftConfigurationRevision> liftConfigurationsRevision { get; set; }

        public DbSet<Revision> revisions { get; set; }
        public DbSet<QuoteItemRevision> quoteItemRevisions { get; set; }
        public DbSet<Project> projects { get; set; }

        public DbSet<ProjectTeam> projectTeams { get; set; }

        public DbSet<ProjectTask> projectTasks { get; set; }

        public DbSet<Supplier> suppliers { get; set; }

        public DbSet<SupplierItem> supplierItems { get; set; }

        public DbSet<ProjectInfo> projectInfos { get; set; }
        public DbSet<ShaftStructural> ShaftStructuralInfos { get; set; }
        public DbSet<EntranceDoor> EntranceDoorDetails { get; set; }
        public DbSet<PowerElectrical> PowerElectricalInfos { get; set; }
        public DbSet<UsageTraffic> UsageTrafficInfos { get; set; }
        public DbSet<FinishingDesign> FinishingDesignPreferences { get; set; }
        public DbSet<SafetyCompliance> SafetyComplianceInfos { get; set; }
        public DbSet<MaintenanceService> MaintenanceServiceInfos { get; set; }
        public DbSet<SiteMediaAttachment> SiteMediaAttachments { get; set; }
        public DbSet<AdditionalNote> AdditionalNotes { get; set; }

        public DbSet<Material> materials { get; set; }


        public DbSet<SelectedProduct> SelectedProducts { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<ShippingAddress> ShippingAddresses { get; set; }

        public DbSet<CivilReadiness> CivilReadinesses { get; set; }

        public DbSet<Installation> Installations { get; set; }

        public DbSet<MyContract> Contracts { get; set; }

        public DbSet<ProjectPhase> ProjectPhases { get; set; }

        public DbSet<ProjectDoc> projectDocs { get; set; }

        public DbSet<ProjectSignedDoc> projectSignedDocs { get; set; }

    }
}
