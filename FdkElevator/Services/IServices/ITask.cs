using FdkElevator.Models.Projects;

namespace FdkElevator.Services.IServices
{
    public interface ITask
    {
        string addTask(ProjectTask task);


        string updateTask(ProjectTask task);

        ProjectTask getProjectTaskById(Guid guid);

        List<ProjectTask> getUserTasks(Guid userId);

        List<ProjectTask> getTasksByStage(Guid StageId);

        bool updateTaskStatus(Guid guid, AllTaskStatus newStatus);
        string removeTask(ProjectTask task);


    }
}
