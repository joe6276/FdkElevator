using FdkElevator.Models.Projects;

namespace FdkElevator.Services.IServices
{
    public interface IEvidenceUploadService
    {

        List<EvidenceUpload> GetByJobs(Guid jobId);


        EvidenceUpload GetById(Guid Id);

   
        string uploadEvidence(EvidenceUpload evidenceUpload);

        bool deleteEvidence(EvidenceUpload evidenceUpload);

        bool setClientVisibility(Guid id, bool isVisible);
    }
}
