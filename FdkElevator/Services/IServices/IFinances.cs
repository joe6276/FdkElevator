using FdkElevator.DTOS.FinanceDTO;

namespace FdkElevator.Services.IServices
{
    public interface IFinances
    {

        Task<FinanceClass> getClientPayments(Guid clientId);

        Task<List<TenantOrderDto>> GetOrdersByTenantAsync(Guid tenantId);

    }
}
