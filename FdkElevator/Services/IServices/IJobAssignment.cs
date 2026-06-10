using FdkElevator.Models.Projects;

namespace FdkElevator.Services.IServices
{
    public interface IJobAssignment
    {

        Task<string> addJobAssignment(JobAssignment job);
        Task<List<JobAssignment>> getUserJobs(Guid userId);
        Task<string> updateJobAssignment(JobAssignment job);
        Task<string> deleteJobAssignment(JobAssignment job);
        Task<JobAssignment> GetJobAssignmentById(Guid Id);
    }
}
