using FdkElevator.Models.Commissions;
using FdkElevator.Models.Complaints;
using FdkElevator.Models.Leads;
using FdkElevator.Models.Projects;
using FdkElevator.Models.Quotations;
using FdkElevator.Models.Selection;
using FdkElevator.Models.Surveyors;
using FdkElevator.Models.Tenants;
using System.ComponentModel.DataAnnotations.Schema;



namespace FdkElevator.Models.Auth
{

    public enum Role
    {
        Admin,
        Sales,
        Survey_Eng,
        Procurement,
        Warehouse,
        Project_Manager,
        Technician,
        QA,
        Client,
        SubContractor,
        SuPer_Admin,
        Supplier

        }
    public class User
    {

        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public decimal? Latitude { get; set; }

        public decimal? Longitude { get; set; }

        public DateTime LastUpdatedTime { get; set; } = DateTime.UtcNow;

        public string PasswordResetToken { get; set; } = string.Empty;

        public DateTime PasswordResetExpires { get; set; } = DateTime.Now;

        public Role Role { get; set; }

        public bool FirstTimeLogin { get; set; } = false;

        [ForeignKey("TenantId")]
        public Tenant ten { get; set; }
        public Guid  TenantId { get; set; }


        public ICollection<Project> projects { get; set; }
        public ICollection<Lead> leads { get; set; }

        public ICollection<AllSurvey> surveyors { get; set; }


        public List<Quotation> quotations { get; set; }

        public ICollection<Activity> activities { get; set; }

        public ICollection<ProjectTeam> users { get; set; }


        public ICollection<SelectedProduct> selectedProducts { get; set; }

        public ICollection<ProjectStage> Stages { get; set; }

        public Commission Commission { get; set; }

        public ICollection<Certificate> Certificates { get; set; }


        public AMCContract AMCContract { get; set; }

        public ICollection<MaintenanceSchedule> maintenanceSchedules { get; set; }

     

    }
}
