using FdkElevator.Models.Auth;
using FdkElevator.Models.Civil;
using FdkElevator.Models.Commissions;
using FdkElevator.Models.Installations;
using FdkElevator.Models.Selection;
using FdkElevator.Models.Warranty;
using System.ComponentModel.DataAnnotations.Schema;

namespace FdkElevator.Models.Projects
{

    public enum ProjectStatus
{
    NotStarted,
    InProgress,
    Completed,
    OnHold,
    Cancelled
}
public class Project
    {

        public Guid Id { get; set; }

        public string ProjectCode { get; set; } = string.Empty;

        public Guid ClientId { get; set; }

        public Guid TenantId { get; set; }

        [ForeignKey("ClientId")]
        public User user { get; set; }

        public ProjectStatus ProjectStatus { get; set; } = ProjectStatus.NotStarted;

        public ICollection<ProjectTeam> Teams { get; set; }

        public ICollection<Material> Materials { get; set; }

        public SelectedProduct SelectedProduct { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public CivilReadiness CivilReadiness { get; set; }

        public ICollection<Installation> Installations { get; set; }


        public ICollection<ProjectPhase> ProjectPhases { get; set; }
        public bool IsCivicReady { get; set; } = false;

        public ICollection<ProjectSignedDoc> projectSignedDocs { get; set; }

        public HandoverWarranty warranty { get; set; }
        public Commission Commission { get; set; }

        public ICollection<TechnicianReport> reports { get; set; }

        public ICollection<ProjectMaintenances> maintenances { get; set; }

    }
}
