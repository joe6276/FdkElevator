using FdkElevator.AppDbContext;
using FdkElevator.Models.Projects;
using FdkElevator.Services.IServices;

namespace FdkElevator.Services
{
    public class EvidenceUploadService : IEvidenceUploadService
    {

        private readonly ApplicationDbContext _context;

        public EvidenceUploadService(ApplicationDbContext context)
        {
            _context=context;
        }
        public bool deleteEvidence(EvidenceUpload evidenceUpload)
        {
           _context.EvidenceUploads.Remove(evidenceUpload);
            _context.SaveChanges();
            return true;
        }

        public EvidenceUpload GetById(Guid Id)
        {
           return _context.EvidenceUploads.FirstOrDefault(x => x.Id == Id);
        }

        public List<EvidenceUpload> GetByJobs(Guid jobId)
        {
            return _context.EvidenceUploads.Where(x => x.JobId == jobId).ToList();

        }

        public bool setClientVisibility(Guid id, bool isVisible)
        {
            var evidence = _context.EvidenceUploads.FirstOrDefault(x => x.Id == id);
            if (evidence != null)
            {
                evidence.IsClientVisible = isVisible;
                _context.EvidenceUploads.Update(evidence);
                _context.SaveChanges();
                return true;
            }

            return false;

        }

        public string uploadEvidence(EvidenceUpload evidenceUpload)
        {
            _context.EvidenceUploads.Add(evidenceUpload);
            _context.SaveChanges();
            return "Evidence uploaded successfully";
        }
    }
}
