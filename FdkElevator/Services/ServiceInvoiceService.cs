using FdkElevator.AppDbContext;
using FdkElevator.Models.Projects;
using FdkElevator.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace FdkElevator.Services
{
    public class ServiceInvoiceService : IServiceInvoice
    {
        private readonly ApplicationDbContext _context;
        public ServiceInvoiceService(ApplicationDbContext context)
        {
            _context=context;
        }
        public async Task<string> addServiceInvoice(ServiceInvoice serviceInvoice)
        {
            await _context.ServiceInvoices.AddAsync(serviceInvoice);
            await _context.SaveChangesAsync();
            return "Service Invoice added";
        }

        public async Task<ServiceInvoice> GetServiceInvoiceById(Guid Id)
        {
            return await _context.ServiceInvoices.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<ServiceInvoice> GetServiceInvoiceByJobId(Guid jobId)
        {
            return await _context.ServiceInvoices.Where(x => x.JobId == jobId).FirstOrDefaultAsync();
        }

        public async Task<string> updateServiceInvoice(Guid Id, ProjectMaintenanceInvoiceStatus status)
        {
           var serviceInvoice = await _context.ServiceInvoices.Where(x => x.Id == Id).FirstOrDefaultAsync();

            if (serviceInvoice == null)
            {
                throw new Exception("Service Invoice not found!");
            }

            serviceInvoice.Status = status;
            _context.ServiceInvoices.Update(serviceInvoice);
            await _context.SaveChangesAsync();

            return "Service Invoice Satstus updated!";
        }
    }
}
