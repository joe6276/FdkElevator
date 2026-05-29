


using FdkElevator.DTOS.OrderDTO;
using FdkElevator.Models.Orders;

namespace FdkElevator.Services.IServices
{
    public interface IOrder
    {

        string addOrder(Order order);

        Task<OrderResponseDTO?> GetOrderById(Guid orderId);

        Task<List<OrderResponseDTO>> GetOrdersBySupplierId(Guid supplierId);

        Task<List<OrderResponseDTO>> GetOrdersByTenantId(Guid tenantId);

        string updatePayment(Guid orderItemId, string PaymentUrl);

    }
}
