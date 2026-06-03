using FdkElevator.Models.Projects;

namespace FdkElevator.Services.IServices
{
    public interface IProjectPhase
    {

        string addProjectPhase(ProjectPhase projectPhase);

        List<ProjectPhase> getProjectPhasesByProjectId(Guid projectId);

        ProjectPhase getProjectPhase(Guid projectPhaseId);

        string updateProjectPhase(ProjectPhase projectPhase);

        string updateProjectPhaseStatus(Guid projectPhaseId, PhaseStatus status);

        string markProjectPhaseAsCompleted(Guid projectPhaseId, string? notes);
    }
}
