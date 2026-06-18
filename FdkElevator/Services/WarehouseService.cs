using FdkElevator.AppDbContext;
using FdkElevator.DTOS.FinanceDTO;
using FdkElevator.Models.Orders;
using FdkElevator.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace FdkElevator.Services
{
    public class WarehouseService : IWarehouse
    {
        private readonly ApplicationDbContext _context;

        public WarehouseService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<TenantOrderDto>> GetClosedOrdersByTenantAsync(Guid tenantId)
        {
            return await _context.Orders
                .Where(o => o.TenantId == tenantId &&
                            o.Status == OrderStatus.Closed)
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
