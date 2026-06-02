using FdkElevator.Models.Projects;
using System.ComponentModel.DataAnnotations.Schema;

namespace FdkElevator.Models.Installations
{
    public class Installation
    {

        public Guid Id { get; set; }

        public Guid ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public Project Project { get; set; } = null!;

        public string TaskName { get; set; } = string.Empty;

        public DateTime PlannedStart { get; set; }

        public DateTime PlannedEnd { get; set; }

        public bool IsCompleted { get; set; } = false;
        public string?  Notes { get; set; } = string.Empty;

    }
}
