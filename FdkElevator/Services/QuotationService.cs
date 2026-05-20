using FdkElevator.AppDbContext;
using FdkElevator.DTOS.QuotationDTOS;
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

 
public List<QuotationResponseDTO> getAllQuotations(Guid tenantId)
        {   
            var leadIds = _context.Leads.Where(l => l.TenantId == tenantId).Select(l => l.Id).ToList();
           
            return _context.Quotations.Where(q => leadIds.Contains(q.LeadId)).Select(q => new QuotationResponseDTO
            {
                SubTotal = q.SubTotal,
                Amount = q.Amount,
                ClientId = q.ClientId,
                Discount = q.Discount,
                LeadId = q.LeadId,
                Items = q.Items.Select(i => new QuotationItemDTO
                {
                    ItemName = i.ItemName,
                    Description = i.Description,
                    ImageURL = i.ImageURL,
                    Price = i.Price,
                    Quantity = i.Quantity
                }).ToList()
            }).ToList();
          
        }

        public List<QuotationResponseDTO> getQuotationByClientId(Guid id)
        {
            return _context.Quotations.Where(q => q.ClientId == id).Select(q => new QuotationResponseDTO
            {
                SubTotal = q.SubTotal,
                Amount = q.Amount,
                ClientId = q.ClientId,
                Discount = q.Discount,
                LeadId = q.LeadId,
                Items = q.Items.Select(i => new QuotationItemDTO
                {
                    ItemName = i.ItemName,
                    Description = i.Description,
                    ImageURL = i.ImageURL,
                    Price = i.Price,
                    Quantity = i.Quantity
                }).ToList()
            }).ToList();
        }

        public QuotationResponseDTO getQuotationById(Guid id)
        {
        
            return _context.Quotations.Where(q => q.Id == id).Select(q => new QuotationResponseDTO
            {
                SubTotal = q.SubTotal,
                Amount = q.Amount,
                ClientId = q.ClientId,
                Discount = q.Discount,
                LeadId = q.LeadId,
                Items = q.Items.Select(i => new QuotationItemDTO
                {
                    ItemName = i.ItemName,
                    Description = i.Description,
                    ImageURL = i.ImageURL,
                    Price = i.Price,
                    Quantity = i.Quantity
                }).ToList()
            }).FirstOrDefault();
        }

        public QuotationResponseDTO getQuotationByLeadId(Guid LeadId)
        {
          
            return _context.Quotations.Where(q => q.LeadId == LeadId).Select(q => new QuotationResponseDTO
            {
                SubTotal = q.SubTotal,
                Amount = q.Amount,
                ClientId = q.ClientId,
                Discount = q.Discount,
                LeadId = q.LeadId,
                Items = q.Items.Select(i => new QuotationItemDTO
                {
                    ItemName = i.ItemName,
                    Description = i.Description,
                    ImageURL = i.ImageURL,
                    Price = i.Price,
                    Quantity = i.Quantity
                }).ToList()
            }).FirstOrDefault();
        }

     
    }
}
