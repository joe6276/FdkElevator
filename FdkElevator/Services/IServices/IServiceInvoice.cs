using FdkElevator.Models.Projects;

namespace FdkElevator.Services.IServices
{
    public interface IServiceInvoice
    {

        Task<string> addServiceInvoice(ServiceInvoice serviceInvoice);

        Task<ServiceInvoice> GetServiceInvoiceById(Guid Id);

        Task<ServiceInvoice> GetServiceInvoiceByJobId(Guid jobId);

        Task<string> updateServiceInvoice(Guid Id, ProjectMaintenanceInvoiceStatus status);

    }
}
