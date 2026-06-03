using System.ComponentModel.DataAnnotations.Schema;

namespace FdkElevator.Models.Projects
{

    public enum PhaseStatus
    {
        NotStarted,
        InProgress,
        Closed
    }
    public class ProjectPhase
    {
        public Guid Id { get; set; }

        public string PhaseCode { get; set; } = string.Empty;

        public string PhaseName { get; set; } = string.Empty;


        public PhaseStatus Status { get; set; } = PhaseStatus.NotStarted;

        public DateTime PlannedStartedDate { get; set; }
        public DateTime PlannedEndDate { get; set; }

        public DateTime?  ActualStartDate { get; set; }
        public DateTime?  ActualEndDate { get; set; }

        [ForeignKey("ProjectId")]
        public Project project { get; set; }

        public Guid ProjectId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string? notes { get; set; } = string.Empty;

        public ICollection<ProjectTask> Tasks { get; set; }
    }
}
