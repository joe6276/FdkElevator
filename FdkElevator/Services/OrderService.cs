using FdkElevator.AppDbContext;
using FdkElevator.DTOS.OrderDTO;
using FdkElevator.Models.Orders;
using FdkElevator.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace FdkElevator.Services
{
    public class OrderService : IOrder
    {

        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }
        public string addOrder(Order order)
        {
        
            float total = 0;

            foreach( var ord in order.OrderItems)
            {
                var supItem = _context.supplierItems.Where(x => x.Id == ord.SupplierItemId).FirstOrDefault();
                total += supItem.Price;
            }
            order.Total = total;
            _context.Orders.Add(order);
            _context.SaveChanges();
            return "Order added successfully!";
        }


        public string updatePayment(Guid orderItemId, string PaymentUrl)
        {
            var orderItem = _context.OrderItems.Where(x => x.Id == orderItemId).FirstOrDefault();

            if(orderItem == null)
            {
                throw new Exception("Order Item not Found!");
            }
            else
            {
                orderItem.isPaid = true;
                orderItem.PaymentImageURL = PaymentUrl;
                _context.OrderItems.Update(orderItem);
                _context.SaveChanges();

                return "Payment Is updated";
            }
        }

public async Task<List<OrderResponseDTO>> GetOrdersBySupplierId(Guid supplierId)
    {
        var orders = await _context.Orders
            .Where(o => o.OrderItems.Any(oi => oi.SupplierId == supplierId))
            .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.SupplierItem)
            .Include(o => o.ShippingAddress)
            .OrderByDescending(o => o.OrderDate)
            .ToListAsync();

        return orders.Select(order => new OrderResponseDTO
        {
            Id = order.Id,
            Total = order.Total,

            // only supplier items belonging to this supplier
            Items = order.OrderItems
                .Where(item => item.SupplierId == supplierId)
                .Select(item => new OrderItemResponseDTo
                {
                    Id = item.Id,
                    ItemName = item.SupplierItem.ItemName,
                    Description = item.SupplierItem.Description,
                    Quantity = item.SupplierItem.Quantity,
                    ImageURL = item.SupplierItem.ImageURL,
                    Price = item.SupplierItem.Price,
                    SupplierId = item.SupplierId

                }).ToList(),

            ShippingAddress = new OrderShippingDTO
            {
                Street = order.ShippingAddress.Street,
                City = order.ShippingAddress.City,
                County = order.ShippingAddress.County,
                PostalCode = order.ShippingAddress.PostalCode,
                OrderId = order.ShippingAddress.OrderId
            }

        }).ToList();
    }

    public async Task<List<OrderResponseDTO>> GetOrdersByTenantId(Guid tenantId)
    {
        var orders = await _context.Orders
            .Where(o => o.TenantId == tenantId)
            .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.SupplierItem)
            .Include(o => o.ShippingAddress)
            .OrderByDescending(o => o.OrderDate)
            .ToListAsync();

        return orders.Select(order => new OrderResponseDTO
        {
            Id = order.Id,
            Total = order.Total,

            Items = order.OrderItems.Select(item => new OrderItemResponseDTo
            {   
                Id=item.Id,
                ItemName = item.SupplierItem.ItemName,
                Description = item.SupplierItem.Description,
                Quantity = item.SupplierItem.Quantity,
                ImageURL = item.SupplierItem.ImageURL,
                Price = item.SupplierItem.Price,
                SupplierId = item.SupplierId

            }).ToList(),

            ShippingAddress = new OrderShippingDTO
            {
                Street = order.ShippingAddress.Street,
                City = order.ShippingAddress.City,
                County = order.ShippingAddress.County,
                PostalCode = order.ShippingAddress.PostalCode,
                OrderId = order.ShippingAddress.OrderId
            }

        }).ToList();
    }
    public async Task<OrderResponseDTO?> GetOrderById(Guid orderId)
    {
        var order = await _context.Orders
            .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.SupplierItem)
            .Include(o => o.ShippingAddress)
            .FirstOrDefaultAsync(o => o.Id == orderId);

        if (order == null)
        {
            return null;
        }

        return new OrderResponseDTO
        {
            Id = order.Id,
            Total = order.Total,

            Items = order.OrderItems.Select(item => new OrderItemResponseDTo
            {
                Id = item.Id,
                ItemName = item.SupplierItem.ItemName,
                Description = item.SupplierItem.Description,
                Quantity = item.SupplierItem.Quantity,
                ImageURL = item.SupplierItem.ImageURL,
                Price = item.SupplierItem.Price,
                SupplierId = item.SupplierId

            }).ToList(),

            ShippingAddress = new OrderShippingDTO
            {
                Street = order.ShippingAddress.Street,
                City = order.ShippingAddress.City,
                County = order.ShippingAddress.County,
                PostalCode = order.ShippingAddress.PostalCode,
                OrderId = order.ShippingAddress.OrderId
            }
        };
    }
}
}
