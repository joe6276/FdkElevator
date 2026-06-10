using FdkElevator.Models.Projects;

namespace FdkElevator.Services.IServices
{
    public interface IServiceQuote
    {


        Task<string> addServiceQuote(ServiceQuote sq);

        Task<ServiceQuote> getServiceQuoteByJobId(Guid jobId);

        Task<string> updateServiceQuote(ServiceQuote sq);

        Task<ServiceQuote> GetServiceQuoteById(Guid Id);

        Task<string> updateStatus(Guid Id, ProjectMaintenanceQuoteStatus status);
    }
}
