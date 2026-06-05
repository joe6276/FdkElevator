using FdkElevator.Models.Projects;
using Microsoft.EntityFrameworkCore.Update.Internal;
using static FdkElevator.DTOS.ProjectDTOS.ProjectMaintenanceDTO;

namespace FdkElevator.Services.IServices
{
    public interface IProjectMaintenance
    {
        string addProjectMaintenance(ProjectMaintenances projectMaintenance);
        ProjectWithContractDto getProjectMaintenancesByProjectId(Guid projectId);

        AMCContract getContractById(Guid Id);
        string updateContract(AMCContract contract);
        string addpayment(List<ProjectMaintenancePayment> payments);

        string markPaymentAsPaid(Guid paymentId, string paymentReceiptImage);

        string addMaintenanceSchedule(List<MaintenanceSchedule> schedule);

        string updateMaintenanceSchedule(MaintenanceSchedule schedule);

        List<MaintenanceSchedule> getMaintenanceSchedulesByProjectId(Guid projectId);

        string addTechnicianReport(TechnicianReport report);

        TechnicianReport getTechnicianReportsByProjectId(Guid projectId);

        Task<ProjectMaintenanceSummaryDto?> GetProjectSummaryAsync(Guid projectId);
    }
}
