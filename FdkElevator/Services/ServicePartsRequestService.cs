using FdkElevator.AppDbContext;
using FdkElevator.Models.Projects;
using FdkElevator.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace FdkElevator.Services
{
    public class ServicePartsRequestService : IServicePartsRequest
    {

        private readonly ApplicationDbContext _context;
        public ServicePartsRequestService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> addPartsRequest(ServicePartsRequest spr)
        {
           await  _context.ServicePartsRequests.AddAsync(spr);
            _context.SaveChanges();
            return "Part Request Added Successfully!";
        }

        public Task<List<ServicePartsRequest>> getServicepartBasedOnJobId(Guid JobId)
        {
            return _context.ServicePartsRequests.Where(x => x.JobId == JobId).ToListAsync();
        }

        public async Task<ServicePartsRequest> GetServicePartsRequestById(Guid Id)
        {
            return await _context.ServicePartsRequests.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<string> updateServiceParts(ServicePartsRequest spr)
        {

            _context.ServicePartsRequests.Update(spr);
            await _context.SaveChangesAsync();
            return "Service Parts updated! ";
        }

        public async Task<bool> updateServicePartStatus(ProjectMaintenancePartRequestStatus status, Guid Id)
        {
            var servicePart = await _context.ServicePartsRequests.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if(servicePart == null)
            {
                throw new Exception("Service Part Not Found");
            }

            servicePart.Status = status;

            _context.ServicePartsRequests.Update(servicePart);
            _context.SaveChanges();

            return true;
        }
    }
}
