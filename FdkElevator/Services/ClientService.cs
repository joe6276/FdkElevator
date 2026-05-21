using FdkElevator.AppDbContext;
using FdkElevator.Models.Quotations;
using FdkElevator.Services.IServices;

namespace FdkElevator.Services
{
    public class ClientService : IClient
    {
        private readonly ApplicationDbContext _context;
        public ClientService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Quotation> GetQuotations(Guid clientId)
        {
           return _context.Quotations.Where(x=>x.ClientId == clientId).ToList();
        }
    }
}
