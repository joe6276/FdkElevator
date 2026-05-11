using FdkElevator.DTOS.TenantDTOS;
using FdkElevator.Models.Tenants;

namespace FdkElevator.Services.IServices
{
    public interface ITenantSub
    {

        PaymentResponseDTO addTenant(TenantSub sub);

        bool ValidatePayment(string stripeSessionId);
    }
}
