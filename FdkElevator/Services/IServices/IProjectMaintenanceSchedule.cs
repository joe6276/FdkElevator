using FdkElevator.Models.Projects;

namespace FdkElevator.Services.IServices
{
    public interface IProjectMaintenanceSchedule
    {

        Task<string> AddProjectMaintenanceScheduleAsync(MaintenanceSchedule pMS, CancellationToken cancellationToken = default);
        Task<List<MaintenanceSchedule>> GetMaintenanceSchedulesByProjectIdAsync(Guid projectId, CancellationToken cancellationToken = default);

        Task<MaintenanceSchedule> getProjectMaintenanceScheduleById(Guid Id, CancellationToken cancellationToken = default);

        Task<MaintenanceSchedule> UpdateProjectMaintenanceScheduleAsync(MaintenanceSchedule pMS, CancellationToken cancellationToken = default);
    }
}
