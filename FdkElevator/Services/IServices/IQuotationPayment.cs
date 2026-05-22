using FdkElevator.DTOS.TenantDTOS;
using FdkElevator.Models.Quotations;

namespace FdkElevator.Services.IServices
{
    public interface IQuotationPayment
    {

        List<QuotationPayment> GetQuotations(Guid clientId);


        PaymentResponseDTO MakePayment(Guid Id);

        string validatePayment(string stripeSessionId);

    }
}
