using FdkElevator.Models.Auth;
using FdkElevator.Models.Selection;
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


        public ICollection<ProjectTask> Tasks { get; set; }

        public ICollection<ProjectTeam> Teams { get; set; }

        public ICollection<Material> Materials { get; set; }

        public SelectedProduct SelectedProduct { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
