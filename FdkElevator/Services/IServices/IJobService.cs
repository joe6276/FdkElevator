using FdkElevator.Models.Projects;

namespace FdkElevator.Services.IServices
{
    public interface IJobService
    {

        Task<string> addJobService(ServiceJob jobService);

       Task<ServiceJob> GetJobs( Guid ScheduleId);

        Task<ServiceJob> GetJobById( Guid JobId);
        Task<string> UpsertJob(ServiceJob job);

        Task<string> deleteJob(ServiceJob job);

        Task<ServiceJob> GetJobsBYid(Guid jobId);
    }
}
