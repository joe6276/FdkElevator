using FdkElevator.Models.Auth;

namespace FdkElevator.DTOS.ProjectDTOS
{
    public class AddProjectTeamDTO
    {
        public Guid UserId { get; set; }
        public Guid ProjectId { get; set; }
    }
}
