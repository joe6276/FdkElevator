using FdkElevator.Models.Projects;

namespace FdkElevator.Services.IServices
{
    public interface IServicePartsRequest
    {

        Task<string> addPartsRequest(ServicePartsRequest spr);

        Task<ServicePartsRequest> GetServicePartsRequestById(Guid Id);
        Task<List<ServicePartsRequest>> getServicepartBasedOnJobId(Guid JobId);
        Task<string> updateServiceParts(ServicePartsRequest spr);

        Task<bool> updateServicePartStatus(ProjectMaintenancePartRequestStatus status, Guid Id);
    }
}
