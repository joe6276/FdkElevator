using FdkElevator.Models.Projects;
using System.ComponentModel.DataAnnotations.Schema;

namespace FdkElevator.DTOS.ProjectDTOS
{
    public class ProjectPhaseDTO
    {
        public string PhaseName { get; set; } = string.Empty;
        public DateTime PlannedStartedDate { get; set; }
        public DateTime PlannedEndDate { get; set; }
        public Guid ProjectId { get; set; }

    }
}
