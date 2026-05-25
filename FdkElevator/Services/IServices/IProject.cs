using FdkElevator.DTOS.ProjectDTOS;
using FdkElevator.Models.Projects;

namespace FdkElevator.Services.IServices
{
    public interface IProject
    {

        string addProject(Project project);

        List<Project> getAllProjects(Guid tenantId);

        List<ProjectResponseDTO> getProjectByClientId(Guid id);

        ProjectResponseDTO getProjectById(Guid id);

        Project getProjectByProjId(Guid id);
        string updateProjectStatus(Guid id, ProjectStatus status);
    }
}
