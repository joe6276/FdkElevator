using FdkElevator.Models.Projects;

namespace FdkElevator.Services.IServices
{
    public interface IJobService
    {

        Task<string> addJobService(ServiceJob jobService);

       Task<List<ServiceJob>> GetJobs( Guid ScheduleId);

        Task<ServiceJob> GetJobById( Guid JobId);
        Task<string> UpsertJob(ServiceJob job);

        Task<string> deleteJob(ServiceJob job);
    }
}
