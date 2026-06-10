using FdkElevator.AppDbContext;
using FdkElevator.Models.Projects;
using FdkElevator.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace FdkElevator.Services
{
    public class JobAssignmentService : IJobAssignment
    {

        private readonly ApplicationDbContext _context;

        public JobAssignmentService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> addJobAssignment(JobAssignment job)
        {
            await _context.JobAssignments.AddAsync(job);
            _context.SaveChanges();
            return "Job Assigned!";

        }

        public async Task<string> deleteJobAssignment(JobAssignment job)
        {
            _context.JobAssignments.Remove(job);
            await _context.SaveChangesAsync();
            return "Job Assigned!";
        }

        public async Task<JobAssignment> GetJobAssignmentById(Guid Id)
        {
            return await _context.JobAssignments.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public Task<List<JobAssignment>> getUserJobs(Guid userId)
        {
            return _context.JobAssignments.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<string> updateJobAssignment(JobAssignment job)
        {
            _context.JobAssignments.Update(job);
           await  _context.SaveChangesAsync();

            return "Job assignment Updated!";
        }
    }
}
