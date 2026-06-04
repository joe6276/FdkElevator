using FdkElevator.Models.Projects;

namespace FdkElevator.Services.IServices
{
    public interface IProjectStage
    {

        string addProjectStage(ProjectStage projectStage);

        List<ProjectStage> getProjectStagesByProjectId(Guid phaseId);

        List<ProjectStage> getProjectbasedOnUser(Guid userId);
    }
}
