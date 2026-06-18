namespace FdkElevator.DTOS.StatDTO
{
    public class Stats
    {

        public class ProjectStatusCountDto
        {
            public string Status { get; set; }
            public int Count { get; set; }
        }

        public class LeadStatusCountDto
        {
            public string Status { get; set; }
            public int Count { get; set; }
        }

        public class LeadSourceCountDto
        {
            public string Source { get; set; }
            public int Count { get; set; }
        }

        public class LeadConversionDto
        {
            public int TotalLeads { get; set; }
            public int WonLeads { get; set; }
            public int LostLeads { get; set; }
            public decimal ConversionRate { get; set; }
        }
        public class MonthlyLeadDto
        {
            public int Year { get; set; }
            public int Month { get; set; }
            public int Count { get; set; }
        }
        public class OrderStatusCountDto
        {
            public string Status { get; set; }
            public int Count { get; set; }
        }

        public class DashboardSummaryDto
        {
            public List<LeadStatusCountDto> LeadStatuses { get; set; }
            public LeadConversionDto Conversion { get; set; }
            public List<ProjectStatusCountDto> ProjectStatuses { get; set; }
            public List<OrderStatusCountDto> OrderStatuses { get; set; }
        }

        public class UserRoleCountDto
        {
            public string Role { get; set; }
            public int Count { get; set; }
        }

        public class MaintenanceStatusCountDto
        {
            public string Status { get; set; }
            public int Count { get; set; }
        }

        public class PaymentStatusCountDto
        {
            public string Status { get; set; }
            public int Count { get; set; }
        }

        public class MonthlyRevenueDto
        {
            public int Year { get; set; }
            public int Month { get; set; }
            public decimal Amount { get; set; }
        }


        public class MaintenanceDashboardDto
        {
            public List<MaintenanceStatusCountDto> Assets { get; set; }
            public List<MaintenanceStatusCountDto> Tickets { get; set; }
            public List<MaintenanceStatusCountDto> Jobs { get; set; }
            public List<MaintenanceStatusCountDto> AMCContracts { get; set; }
            public List<MaintenanceStatusCountDto> Warranty { get; set; }
            public List<MaintenanceStatusCountDto> Parts { get; set; }
        }
    }
}
