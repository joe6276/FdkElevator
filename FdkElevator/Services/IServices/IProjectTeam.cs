using FdkElevator.Models.Projects;

namespace FdkElevator.Services.IServices
{
    public interface IProjectTeam
    {

        Task<string> addProjectTeam(List<ProjectTeam> projectTeam);
    }
}
