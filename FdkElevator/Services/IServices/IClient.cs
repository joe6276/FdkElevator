using FdkElevator.Models.Quotations;

namespace FdkElevator.Services.IServices
{
    public interface IClient
    {

        List<Quotation> GetQuotations(Guid clientId);
    }
}
