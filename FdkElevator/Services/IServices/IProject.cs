using FdkElevator.DTOS.ProjectDTOS;
using FdkElevator.Models.Projects;

namespace FdkElevator.Services.IServices
{
    public interface IProject
    {

        string addProject(Project project);

        List<ProjectResponseDTO1> getAllProjects(Guid tenantId);

        List<ProjectResponseDTO> getProjectByClientId(Guid id);

        ProjectResponseDTO getProjectById(Guid id);

        Project getProjectByProjId(Guid id);
        string updateProjectStatus(Guid id, ProjectStatus status);


        Task<List<ProjectClientDto>?>  GetProjectClientAsync(Guid tenantid);
    }
}
