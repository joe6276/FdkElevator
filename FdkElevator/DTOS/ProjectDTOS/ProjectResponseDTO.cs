using FdkElevator.Models.Auth;
using FdkElevator.Models.Projects;

namespace FdkElevator.DTOS.ProjectDTOS
{
    public class ProjectResponseDTO
    {
        public string ProjectCode { get; set; } = string.Empty;

        public Guid ProjectId { get; set; }
        public Guid ClientId { get; set; }

        public ClientDetailsDTO ClientDetails { get; set; }
        public List<ProjectResponseTeamDTO> Team { get; set; } = new List<ProjectResponseTeamDTO>();

        public List<ProjectResponseTasksDTO> Phases { get; set; } = new List<ProjectResponseTasksDTO>();
        public DateTime CreatedAt { get; set; }
    }


    public class ClientDetailsDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
        public class ProjectResponseTeamDTO
    {
        public string Name { get; set; }
        public Role Role { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class ProjectResponseTasksDTO 
    {
        public string PhaseCode { get; set; } = string.Empty;

        public string PhaseName { get; set; } = string.Empty;

        public PhaseStatus Status { get; set; } = PhaseStatus.NotStarted;

        public DateTime PlannedStartedDate { get; set; }
        public DateTime PlannedEndDate { get; set; }
    }
}
