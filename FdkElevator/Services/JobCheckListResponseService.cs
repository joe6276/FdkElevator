using FdkElevator.AppDbContext;
using FdkElevator.Models.Projects;
using FdkElevator.Services.IServices;

namespace FdkElevator.Services
{
    public class JobCheckListResponseService : IJobChecklistResponseService
    {

        private readonly ApplicationDbContext _context;

        public JobCheckListResponseService(ApplicationDbContext context)
        {
            _context = context;
        }
        public string approveChecklistResponse(Guid Id, Guid approvedByUserId, string? remarks = null)
        {
            var response = _context.JobChecklistResponses.FirstOrDefault(x => x.Id == Id);
            if (response == null)
            {
                throw new Exception("Checklist response not found");
            }

            response.Remarks = remarks;
            response.ApprovedByUserId = approvedByUserId;

            _context.JobChecklistResponses.Update(response);
            _context.SaveChanges();
            return "Checklist response approved successfully";
        }

        public bool deleteChecklistResponse(JobChecklistResponse jcr)
        {
          _context.JobChecklistResponses.Remove(jcr);
            _context.SaveChanges();
            return true;
        }

        public JobChecklistResponse GetById(Guid Id)
        {
           return _context.JobChecklistResponses.FirstOrDefault(x => x.Id == Id);
        }

       
        public List<JobChecklistResponse> GetByJob(Guid JobId)
        {
           return _context.JobChecklistResponses.Where(x => x.JobId == JobId).ToList();
        }

        public string SubmitChecklistResponse(JobChecklistResponse jcr)
        {
            _context.JobChecklistResponses.Add(jcr);
            _context.SaveChanges();
            return "Checklist response submitted successfully";
        }
    }
}
