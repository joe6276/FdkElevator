using System.Threading.Tasks;
using static FdkElevator.DTOS.StatDTO.Stats;

namespace FdkElevator.Services.IServices
{
    public interface IStat
    {
        Task<List<ProjectStatusCountDto>> GetProjectStatusCountsAsync(Guid tenantId);
        Task<List<LeadStatusCountDto>> GetLeadStatusCountsAsync(Guid tenantId);

        Task<List<LeadSourceCountDto>> GetLeadSourceStatsAsync(Guid tenantId);
        Task<LeadConversionDto> GetLeadConversionAsync(Guid tenantId);
        Task<List<MonthlyLeadDto>> GetMonthlyLeadTrend(Guid tenantId);
        Task<List<OrderStatusCountDto>> GetOrderStatusStatsAsync(Guid tenantId);

        Task<DashboardSummaryDto> GetDashboard(Guid tenantId);

        Task<List<UserRoleCountDto>> GetUserRoleStatsAsync(Guid tenantId);


        Task<List<MaintenanceStatusCountDto>> GetAssetStatusStats(Guid tenantId);
        Task<List<MaintenanceStatusCountDto>> GetLiftTypeStats(Guid tenantId);

        Task<List<MaintenanceStatusCountDto>> GetAMCContractStats(Guid tenantId);
        Task<List<MaintenanceStatusCountDto>> GetTicketStats(Guid tenantId);
        Task<List<MaintenanceStatusCountDto>> GetWarrantyStats(Guid tenantId);
        Task<MaintenanceDashboardDto> GetMaintenanceDashboard(Guid tenantId);
        Task<List<MaintenanceStatusCountDto>> GetJobStats(Guid tenantId);


        Task<List<PaymentStatusCountDto>> GetPaymentStatusStats(Guid tenantId);
        Task<List<MonthlyRevenueDto>> GetMonthlyRevenue(Guid tenantId);
        Task<object> GetPaymentSummary(Guid tenantId);

    }
}
