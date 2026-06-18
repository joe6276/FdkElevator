using FdkElevator.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static FdkElevator.DTOS.StatDTO.Stats;

namespace FdkElevator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatController : ControllerBase
    {

        private readonly IStat _stat;

        public StatController(IStat stat)
        {
            _stat = stat;
        }

        [HttpGet("projects/{tenantId}")]
        public async Task<ActionResult<List<ProjectStatusCountDto>>> getProjectStat(Guid tenantId)
        {
            try
            {
                var projects = await _stat.GetProjectStatusCountsAsync(tenantId);
                return Ok(projects);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("leads/{tenantId}")]
        public async Task<ActionResult<List<LeadStatusCountDto>>> getLeadsStat(Guid tenantId)
        {
            try
            {
                var leads = await _stat.GetLeadStatusCountsAsync(tenantId);
                return Ok(leads);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("leads/sources/{tenantId}")]
        public async Task<ActionResult<List<LeadSourceCountDto>>> getLeadSourcesStat(Guid tenantId)
        {
            try
            {
                var leads = await _stat.GetLeadSourceStatsAsync(tenantId);
                return Ok(leads);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("leads/conversion/{tenantId}")]
        public async Task<ActionResult<LeadConversionDto>> getLeadConversionsStat(Guid tenantId)
        {
            try
            {
                var leads = await _stat.GetLeadConversionAsync(tenantId);
                return Ok(leads);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("leads/monthly/{tenantId}")]
        public async Task<ActionResult<List<MonthlyLeadDto>>> getLeadsMonthlyStat(Guid tenantId)
        {
            try
            {
                var leads = await _stat.GetMonthlyLeadTrend(tenantId);
                return Ok(leads);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("leads/summary/{tenantId}")]
        public async Task<ActionResult<DashboardSummaryDto>> getDashboardStat(Guid tenantId)
        {
            try
            {
                var leads = await _stat.GetDashboard(tenantId);
                return Ok(leads);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    
        //Orders

        [HttpGet("orders/status/{tenantId}")]
        public async Task<ActionResult<List<OrderStatusCountDto>>> getOrdersStat(Guid tenantId)
        {
            try
            {
                var leads = await _stat.GetOrderStatusStatsAsync(tenantId);
                return Ok(leads);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //users
        [HttpGet("users/roles/{tenantId}")]
        public async Task<ActionResult<List<UserRoleCountDto>>> getUserRoles(Guid tenantId)
        {
            try
            {
                var users = await _stat.GetUserRoleStatsAsync(tenantId);
                return Ok(users);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        //Maintenance
        [HttpGet("maintanance/asset/{tenantId}")]
        public async Task<ActionResult<List<MaintenanceStatusCountDto>>> getMaintenanceAssetStatus(Guid tenantId)
        {
            try
            {
                var Maintenances = await _stat.GetUserRoleStatsAsync(tenantId);
                return Ok(Maintenances);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("maintanance/lifttypes/{tenantId}")]
        public async Task<ActionResult<List<MaintenanceStatusCountDto>>> getMaintenanceLiftType(Guid tenantId)
        {
            try
            {
                var Maintenances = await _stat.GetLiftTypeStats(tenantId);
                return Ok(Maintenances);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("maintanance/contractStats/{tenantId}")]
        public async Task<ActionResult<List<MaintenanceStatusCountDto>>> getMaintenanceAMCContact(Guid tenantId)
        {
            try
            {
                var Maintenances = await _stat.GetAMCContractStats(tenantId);
                return Ok(Maintenances);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("maintanance/tickets/{tenantId}")]
        public async Task<ActionResult<List<MaintenanceStatusCountDto>>> getTicketStats(Guid tenantId)
        {
            try
            {
                var Maintenances = await _stat.GetTicketStats(tenantId);
                return Ok(Maintenances);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("maintanance/warranty/{tenantId}")]
        public async Task<ActionResult<List<MaintenanceStatusCountDto>>> getWarranty(Guid tenantId)
        {
            try
            {
                var Maintenances = await _stat.GetWarrantyStats(tenantId);
                return Ok(Maintenances);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("maintanance/jobs/{tenantId}")]
        public async Task<ActionResult<List<MaintenanceStatusCountDto>>> getJobs(Guid tenantId)
        {
            try
            {
                var Maintenances = await _stat.GetJobStats(tenantId);
                return Ok(Maintenances);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpGet("maintanance/summary/{tenantId}")]
        public async Task<ActionResult<List<MaintenanceStatusCountDto>>> getSummaryMaintenance(Guid tenantId)
        {
            try
            {
                var Maintenances = await _stat.GetMaintenanceDashboard(tenantId);
                return Ok(Maintenances);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("quotation/payment/status/{tenantId}")]
        public async Task<ActionResult<List<PaymentStatusCountDto>>> getQuotationPaymentStatus(Guid tenantId)
        {
            try
            {
                var payments = await _stat.GetPaymentStatusStats(tenantId);
                return Ok(payments);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpGet("quotation/payment/monthly/{tenantId}")]
        public async Task<ActionResult<List<PaymentStatusCountDto>>> getQuotationPaymentMonthly(Guid tenantId)
        {
            try
            {
                var payments = await _stat.GetMonthlyRevenue(tenantId);
                return Ok(payments);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpGet("quotation/payment/summary/{tenantId}")]
        public async Task<ActionResult<object>> getQuotationPaymentSummary(Guid tenantId)
        {
            try
            {
                var payments = await _stat.GetPaymentSummary(tenantId);
                return Ok(payments);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

   
     
    }
}
