using FdkElevator.Models.Auth;
using System.ComponentModel.DataAnnotations.Schema;

namespace FdkElevator.Models.Projects
{   

    public enum AllTaskStatus
    {
        NotStarted,
        InProgress,
        Completed,
        OnHold,
        Cancelled
    }

    public enum Criticality
    {
        Low,
        Medium,
        High,
        Critical
    }
    public class ProjectTask
    {

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public AllTaskStatus Status { get; set; } = AllTaskStatus.NotStarted;

        public Criticality Criticality { get; set; } 
        public string?  Notes { get; set; }

        public string? ImageURL { get; set; }
        public DateTime PlannedStart { get; set; }
        public DateTime PlannedEnd { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("UserId")]
        public User user { get; set; }

        public Guid  UserId { get; set; }
        public Guid ProjectPhaseId { get; set; }
        [ForeignKey("ProjectPhaseId")]
        public ProjectPhase Project { get; set; }
    }
}
