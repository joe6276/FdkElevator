using FdkElevator.AppDbContext;
using FdkElevator.Models.Projects;
using FdkElevator.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace FdkElevator.Services
{
    public class JobService : IJobService
    {

        private readonly ApplicationDbContext _context;

        public JobService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> addJobService(ServiceJob jobService)
        {
            await _context.ServiceJobs.AddAsync(jobService);
            _context.SaveChanges();
            return "Job Service Added!";
        }

        public async Task<string> deleteJob(ServiceJob job)
        {
            _context.ServiceJobs.Remove(job);
            await _context.SaveChangesAsync();
            return "Job Service Added!";
        }

        public async Task<ServiceJob> GetJobById(Guid JobId)
        {
            return await _context.ServiceJobs.FirstOrDefaultAsync(x => x.Id == JobId);
        }

        public async Task<List<ServiceJob>> GetJobs(Guid ScheduleId)
        {
            return  await  _context.ServiceJobs.Where(x=>x.ScheduleId == ScheduleId).ToListAsync();
        }

        public async Task<string> UpsertJob(ServiceJob job)
        {
            _context.ServiceJobs.Update(job);
            await _context.SaveChangesAsync();
            return "Job Service Added!";
        }
    }
}
