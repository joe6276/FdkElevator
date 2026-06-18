using FdkElevator.AppDbContext;
using FdkElevator.Models.Leads;
using FdkElevator.Models.Quotations;
using FdkElevator.Services.IServices;
using Microsoft.EntityFrameworkCore;
using static FdkElevator.DTOS.StatDTO.Stats;

namespace FdkElevator.Services
{

 
    public class StatService: IStat
    {
        private readonly ApplicationDbContext _context;

        public StatService(ApplicationDbContext context)
        {
            _context=context;
        }
        public async Task<List<ProjectStatusCountDto>> GetProjectStatusCountsAsync(Guid tenantId)
        {
            return await _context.projects
                .Where(p => p.TenantId == tenantId)
                .GroupBy(p => p.ProjectStatus)
                .Select(g => new ProjectStatusCountDto
                {
                    Status = g.Key.ToString(),
                    Count = g.Count()
                })
                .ToListAsync();
        }


        public async Task<List<LeadStatusCountDto>> GetLeadStatusCountsAsync(Guid tenantId)
        {
            return await _context.Leads
                .Where(l => l.TenantId == tenantId)
                .GroupBy(l => l.leadStatus)
                .Select(g => new LeadStatusCountDto
                {
                    Status = g.Key.ToString(),
                    Count = g.Count()
                })
                .ToListAsync();
        }

        public async Task<List<LeadSourceCountDto>> GetLeadSourceStatsAsync(Guid tenantId)
        {
            return await _context.Leads
                .Where(x => x.TenantId == tenantId)
                .GroupBy(x => x.source)
                .Select(x => new LeadSourceCountDto
                {
                    Source = x.Key.ToString(),
                    Count = x.Count()
                })
                .ToListAsync();
        }

        public async Task<LeadConversionDto> GetLeadConversionAsync(Guid tenantId)
        {
            var total = await _context.Leads
                .CountAsync(x => x.TenantId == tenantId);


            var won = await _context.Leads
                .CountAsync(x =>
                    x.TenantId == tenantId &&
                    x.leadStatus == Status.Won);


            var lost = await _context.Leads
                .CountAsync(x =>
                    x.TenantId == tenantId &&
                    x.leadStatus == Status.Lost);


            return new LeadConversionDto
            {
                TotalLeads = total,
                WonLeads = won,
                LostLeads = lost,
                ConversionRate = total == 0
                    ? 0
                    : Math.Round((decimal)won / total * 100, 2)
            };
        }

        public async Task<List<MonthlyLeadDto>> GetMonthlyLeadTrend(Guid tenantId)
        {
            return await _context.Leads
                .Where(x => x.TenantId == tenantId)
                .GroupBy(x => new
                {
                    x.CreatedAt.Year,
                    x.CreatedAt.Month
                })
                .Select(x => new MonthlyLeadDto
                {
                    Year = x.Key.Year,
                    Month = x.Key.Month,
                    Count = x.Count()
                })
                .OrderBy(x => x.Year)
                .ThenBy(x => x.Month)
                .ToListAsync();
        }

        public async Task<List<OrderStatusCountDto>> GetOrderStatusStatsAsync(Guid tenantId)
        {
            return await _context.Orders
                .Where(x => x.TenantId == tenantId)
                .GroupBy(x => x.Status)
                .Select(x => new OrderStatusCountDto
                {
                    Status = x.Key.ToString(),
                    Count = x.Count()
                })
                .ToListAsync();
        }

        public async Task<DashboardSummaryDto> GetDashboard(Guid tenantId)
        {
            return new DashboardSummaryDto
            {
                LeadStatuses = await GetLeadStatusCountsAsync(tenantId),
                Conversion = await GetLeadConversionAsync(tenantId),
                ProjectStatuses = await GetProjectStatusCountsAsync(tenantId),
                OrderStatuses = await GetOrderStatusStatsAsync(tenantId)
            };
        }

        public async Task<List<UserRoleCountDto>> GetUserRoleStatsAsync(Guid tenantId)
        {
            return await _context.Users
                .Where(u => u.TenantId == tenantId)
                .GroupBy(u => u.Role)
                .Select(g => new UserRoleCountDto
                {
                    Role = g.Key.ToString(),
                    Count = g.Count()
                })
                .ToListAsync();
        }

        public async Task<List<MaintenanceStatusCountDto>> GetAssetStatusStats(Guid tenantId)
        {
            return await _context.LiftAssets
                .Where(x => x.Project.TenantId == tenantId)
                .GroupBy(x => x.CurrentStatus)
                .Select(x => new MaintenanceStatusCountDto
                {
                    Status = x.Key.ToString(),
                    Count = x.Count()
                })
                .ToListAsync();
        }

        public async Task<List<MaintenanceStatusCountDto>> GetLiftTypeStats(Guid tenantId)
        {
            return await _context.LiftAssets
                .Where(x => x.Project.TenantId == tenantId)
                .GroupBy(x => x.LiftAssetType)
                .Select(x => new MaintenanceStatusCountDto
                {
                    Status = x.Key.ToString(),
                    Count = x.Count()
                })
                .ToListAsync();
        }

        public async Task<List<MaintenanceStatusCountDto>> GetAMCContractStats(Guid tenantId)
        {
            return await _context.AMCContracts
                .Where(x => x.Project.TenantId == tenantId)
                .GroupBy(x => x.ContractStatus)
                .Select(x => new MaintenanceStatusCountDto
                {
                    Status = x.Key.ToString(),
                    Count = x.Count()
                })
                .ToListAsync();
        }

        public async Task<List<MaintenanceStatusCountDto>> GetWarrantyStats(Guid tenantId)
        {
            return await _context.WarrantyRecords
                .Where(x => x.LiftAsset.Project.TenantId == tenantId)
                .GroupBy(x => x.WarrantyStatus)
                .Select(x => new MaintenanceStatusCountDto
                {
                    Status = x.Key.ToString(),
                    Count = x.Count()
                })
                .ToListAsync();
        }

        public async Task<List<MaintenanceStatusCountDto>> GetTicketStats(Guid tenantId)
        {
            return await _context.ServiceTickets
                .Where(x => x.Project.TenantId == tenantId)
                .GroupBy(x => x.CurrentStatus)
                .Select(x => new MaintenanceStatusCountDto
                {
                    Status = x.Key.ToString(),
                    Count = x.Count()
                })
                .ToListAsync();
        }
        public async Task<List<MaintenanceStatusCountDto>> GetJobStats(Guid tenantId)
        {
            return await _context.ServiceJobs
                .Where(x => x.LiftAsset.Project.TenantId == tenantId)
                .GroupBy(x => x.CurrentStatus)
                .Select(x => new MaintenanceStatusCountDto
                {
                    Status = x.Key.ToString(),
                    Count = x.Count()
                })
                .ToListAsync();
        }
        public async Task<List<MaintenanceStatusCountDto>> GetPartsRequestStats(Guid tenantId)
        {
            return await _context.ServicePartsRequests
                .Where(x => x.ServiceJob.LiftAsset.Project.TenantId == tenantId)
                .GroupBy(x => x.Status)
                .Select(x => new MaintenanceStatusCountDto
                {
                    Status = x.Key.ToString(),
                    Count = x.Count()
                })
                .ToListAsync();
        }
        public async Task<MaintenanceDashboardDto> GetMaintenanceDashboard(Guid tenantId)
        {
            return new MaintenanceDashboardDto
            {
                Assets = await GetAssetStatusStats(tenantId),
                Tickets = await GetTicketStats(tenantId),
                Jobs = await GetJobStats(tenantId),
                AMCContracts = await GetAMCContractStats(tenantId),
                Warranty = await GetWarrantyStats(tenantId),
                Parts = await GetPartsRequestStats(tenantId)
            };
        }

        public async Task<List<PaymentStatusCountDto>> GetPaymentStatusStats(Guid tenantId)
        {
            return await _context.quotationPayments
                .Where(x => x.user.TenantId == tenantId)
                .GroupBy(x => x.Status)
                .Select(x => new PaymentStatusCountDto
                {
                    Status = x.Key.ToString(),
                    Count = x.Count()
                })
                .ToListAsync();
        }

        public async Task<object> GetPaymentSummary(Guid tenantId)
        {
            var payments = await _context.quotationPayments
                .Where(x => x.user.TenantId == tenantId)
                .ToListAsync();


            return new
            {
                TotalPayments = payments.Count,

                Completed = payments
                    .Count(x => x.Status == PaymentStatus.Completed),

                Pending = payments
                    .Count(x => x.Status == PaymentStatus.Pending),

                Failed = payments
                    .Count(x => x.Status == PaymentStatus.Failed),

                TotalAmount = payments.Sum(x => x.Amount),

                CollectedAmount = payments
                    .Where(x => x.Status == PaymentStatus.Completed)
                    .Sum(x => x.Amount)
            };
        }
        public async Task<List<MonthlyRevenueDto>> GetMonthlyRevenue(Guid tenantId)
        {
            return await _context.quotationPayments
                .Where(x =>
                    x.user.TenantId == tenantId &&
                    x.Status == PaymentStatus.Completed)
                .GroupBy(x => new
                {
                    x.CreatedAt.Year,
                    x.CreatedAt.Month
                })
                .Select(x => new MonthlyRevenueDto
                {
                    Year = x.Key.Year,
                    Month = x.Key.Month,
                    Amount = x.Sum(p => p.Amount)
                })
                .OrderBy(x => x.Year)
                .ThenBy(x => x.Month)
                .ToListAsync();
        }

    }
}
