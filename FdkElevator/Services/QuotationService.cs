using FdkElevator.AppDbContext;
using FdkElevator.Models.Leads;
using FdkElevator.Models.Quotations;
using FdkElevator.Services.IServices;

namespace FdkElevator.Services
{
    public class QuotationService : IQuotation
    {   

        private readonly ApplicationDbContext _context;

        public QuotationService(ApplicationDbContext context)
        {
            _context = context;
        }
        public string addQuotation(Quotation quotation)
        {
           _context.Quotations.Add(quotation);
            _context.SaveChanges();
            return "Quotation added successfully!";
        }

 
public List<Quotation> getAllQuotations(Guid tenantId)
        {
            throw new NotImplementedException();
        }

        public Quotation getQuotationByClientId(Guid id)
        {
            return _context.Quotations.FirstOrDefault(q => q.ClientId == id);
        }

        public Quotation getQuotationById(Guid id)
        {
            return _context.Quotations.FirstOrDefault(q => q.Id == id);
        }

        public Quotation getQuotationByLeadId(Guid LeadId)
        {
            return _context.Quotations.FirstOrDefault(q => q.LeadId == LeadId);
        }
    }
}
