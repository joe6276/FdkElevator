using FdkElevator.AppDbContext;
using FdkElevator.DTOS.FinanceDTO;
using FdkElevator.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace FdkElevator.Services
{
    public class FinanceService : IFinances
    {
        private readonly ApplicationDbContext _context;
        public FinanceService(ApplicationDbContext context)
        {
            _context =context;
        }
        public async Task<FinanceClass> getClientPayments(Guid clientId)
        {
            var allFinances = new FinanceClass();

            var quotationPayments = await _context.quotationPayments.Where(x=>x.ClientId == clientId).ToListAsync();

            var quotes = await _context.ServiceQuotes
            .Where(q => q.ServiceJob.LiftAsset.ClientId == clientId)
            .Select(q => new ServiceQuoteDto
            {
               Id= q.Id,
               JobId= q.JobId,
               QuoteCode= q.QuoteCode,
               Status= q.Status,
               TotalAmount= q.TotalAmount,
               CurrencyCode=  q.CurrencyCode,
               ClientApprovedAt=  q.ClientApprovedAt,
               CreatedAt= q.CreatedAt
            })
            .ToListAsync();


            var repairQuotation = await _context.RepairQuotations.Where(x => x.ApprovedByClientId == clientId).ToListAsync();

            allFinances.quotationPayments = quotationPayments;
            allFinances.serviceQuotes = quotes;
            allFinances.repairQuotes = repairQuotation;


            return allFinances;
        }

        public async Task<List<TenantOrderDto>> GetOrdersByTenantAsync(Guid tenantId)
        {
            return await _context.Orders
                .Where(o => o.TenantId == tenantId)
                .Include(o => o.ShippingAddress)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.SupplierItem)
                        .ThenInclude(si => si.Supplier)
                .Select(o => new TenantOrderDto
                {
                    OrderId = o.Id,
                    Total = o.Total,
                    Status = o.Status,
                    OrderDate = o.OrderDate,

                    ShippingAddress = new ShippingAddressDto
                    {
                        Street = o.ShippingAddress.Street,
                        City = o.ShippingAddress.City,
                        County = o.ShippingAddress.County,
                        PostalCode = o.ShippingAddress.PostalCode
                    },

                    Items = o.OrderItems.Select(oi => new OrderItemDto
                    {
                        OrderItemId = oi.Id,
                        SupplierItemId = oi.SupplierItemId,
                        SupplierId = oi.SupplierId,
                        SupplierName = oi.SupplierItem.Supplier.Name,
                        IsPaid = oi.isPaid,
                        PaymentImageUrl = oi.PaymentImageURL
                    }).ToList()
                })
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();
        }
    }
}
