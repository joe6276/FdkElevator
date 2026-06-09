using FdkElevator.AppDbContext;
using FdkElevator.Models.Projects;
using FdkElevator.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace FdkElevator.Services
{
    public class TicketService : IServiceTicket
    {
        private readonly ApplicationDbContext _context;
        public TicketService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> addServiceTicket(ServiceTicket st)
        {
            await _context.ServiceTickets.AddAsync(st);
            _context.SaveChanges();
            return "Ticket Added Successfully!";
        }

        public async Task<string> deleteServiceTicket(ServiceTicket st)
        {
            _context.ServiceTickets.Remove(st);
            await _context.SaveChangesAsync();
            return "Service Ticket deleted!";
        }

        public async Task<ServiceTicket> getServiceTickerById(Guid Id)
        {
            return await _context.ServiceTickets.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public Task<List<ServiceTicket>> getServiceTicketByClientId(Guid clientId)
        {
            return _context.ServiceTickets.Where(X => X.ClientId == clientId).ToListAsync();
        }

        public Task<List<ServiceTicket>> getServiceTicketByLiftAssetId(Guid liftassetId)
        {
            return _context.ServiceTickets.Where(X => X.LiftAssetId == liftassetId).ToListAsync();
        }

        public Task<List<ServiceTicket>> getServiceTicketByProjectId(Guid projectId)
        {
            return _context.ServiceTickets.Where(X => X.ProjectId == projectId).ToListAsync();
        }

        public async Task<string> updateServiceTicket(ServiceTicket st)
        {
            _context.ServiceTickets.Update(st);
            await _context.SaveChangesAsync();
            return "Service Ticket updated!";
        }
    }
}
