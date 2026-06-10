using FdkElevator.AppDbContext;
using FdkElevator.Models.Projects;
using FdkElevator.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace FdkElevator.Services
{
    public class ServiceQuoteService : IServiceQuote
    {

        private readonly ApplicationDbContext _context;
        public ServiceQuoteService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> addServiceQuote(ServiceQuote sq)
        {
           await _context.ServiceQuotes.AddAsync(sq);
            await _context.SaveChangesAsync();
            return "Service Quote added Successfully!";
        }

        public async Task<ServiceQuote> GetServiceQuoteById(Guid Id)
        {
           return await _context.ServiceQuotes.Where(x=>x.Id ==Id).FirstOrDefaultAsync();
        }

        public async Task<ServiceQuote> getServiceQuoteByJobId(Guid jobId)
        {
            return await _context.ServiceQuotes.Where(x => x.JobId == jobId).FirstOrDefaultAsync();
        }

        public async Task<string> updateServiceQuote(ServiceQuote sq)
        {
            _context.ServiceQuotes.Update(sq);
            await _context.SaveChangesAsync();
            return "Service Quote updated Successfully!";
        }

        public async Task<string> updateStatus(Guid Id, ProjectMaintenanceQuoteStatus status)
        {
            var serviceQuote= await _context.ServiceQuotes.Where(x => x.Id == Id).FirstOrDefaultAsync();

            if(serviceQuote == null)
            {
                throw new Exception("service Quote not Found");
            }
            serviceQuote.Status = status;
            _context.ServiceQuotes.Update(serviceQuote);
            await _context.SaveChangesAsync();
            return "Service Quote Status Updated!";
        }
    }
}
