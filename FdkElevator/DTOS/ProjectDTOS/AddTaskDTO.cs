using FdkElevator.Models.Auth;
using FdkElevator.Models.Projects;
using System.ComponentModel.DataAnnotations.Schema;

namespace FdkElevator.DTOS.ProjectDTOS
{
    public class AddTaskDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public AllTaskStatus Status { get; set; } = AllTaskStatus.NotStarted;
        public Criticality Criticality { get; set; }
        public string? ImageURL { get; set; }
        public DateTime PlannedStart { get; set; }
        public DateTime PlannedEnd { get; set; }
        public Guid UserId { get; set; }
        public Guid ProjectStageId { get; set; }
   
    }
}
