using FdkElevator.Models.Projects;
using System.ComponentModel.DataAnnotations.Schema;

namespace FdkElevator.DTOS.InstallationsDTO
{
    public class InstallationDTO
    {
     public Guid ProjectId { get; set; }
    public string TaskName { get; set; } = string.Empty;

    public DateTime PlannedStart { get; set; }

    public DateTime PlannedEnd { get; set; }

}

    public class CompletionNotesDTO
    {
        public string? Notes { get; set; } = string.Empty;
    }

    public class ProjectInstallationResponseDto
    {
        public List<TaskInstallationDto> CompletedTasks { get; set; } = new();
        public List<TaskInstallationDto> PendingTasks { get; set; } = new();
    }

    public class TaskInstallationDto
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public string TaskName { get; set; } = string.Empty;
        public DateTime PlannedStart { get; set; }
        public DateTime PlannedEnd { get; set; }
        public bool IsCompleted { get; set; }
        public string? Notes { get; set; }
    }
}
