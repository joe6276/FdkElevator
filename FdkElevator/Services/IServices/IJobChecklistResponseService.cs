using FdkElevator.Models.Projects;

namespace FdkElevator.Services.IServices
{
    public interface IJobChecklistResponseService
    {

        List<JobChecklistResponse> GetByJob(Guid JobId);

        JobChecklistResponse GetById(Guid Id);

        string SubmitChecklistResponse(JobChecklistResponse jcr);

        string approveChecklistResponse(Guid Id, Guid approvedByUserId, string? remarks= null);

        bool deleteChecklistResponse(JobChecklistResponse jcr);
    }
}
