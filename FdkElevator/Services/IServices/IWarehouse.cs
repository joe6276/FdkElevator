using FdkElevator.DTOS.FinanceDTO;
using FdkElevator.Models.Orders;

namespace FdkElevator.Services.IServices
{
    public interface IWarehouse
    {
        Task<List<TenantOrderDto>> GetClosedOrdersByTenantAsync(Guid tenantId);
    }
}
