using FdkElevator.Models.Projects;

namespace FdkElevator.DTOS.ProjectDTOS
{
    public class AddTaskDTO
    {

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string?  Notes { get; set; }
        public string? ImageURL { get; set; }

        public Guid ProjectId { get; set; }
    }
}
