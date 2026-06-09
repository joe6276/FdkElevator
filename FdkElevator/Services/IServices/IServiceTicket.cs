using FdkElevator.Models.Projects;

namespace FdkElevator.Services.IServices
{
    public interface IServiceTicket
    {
        Task<string> addServiceTicket(ServiceTicket st);

        Task<List<ServiceTicket>> getServiceTicketByClientId(Guid clientId);

        Task<List<ServiceTicket>> getServiceTicketByProjectId(Guid projectId);


        Task<List<ServiceTicket>> getServiceTicketByLiftAssetId(Guid liftassetId);

        Task<string> updateServiceTicket(ServiceTicket st);

        Task<ServiceTicket> getServiceTickerById(Guid Id);

        Task<string> deleteServiceTicket(ServiceTicket st);


    }
}
