using FdkElevator.DTOS.FinanceDTO;
using FdkElevator.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FdkElevator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouse _warehouse;
        public WarehouseController(IWarehouse warehouse)
        {
            _warehouse = warehouse;
        }

        [HttpGet("received/{tenantId}")]
        public async Task<ActionResult<List<TenantOrderDto>>> GetReceivedGoods(Guid tenantId)
        {
            try
            {
                var result = await _warehouse.GetClosedOrdersByTenantAsync(tenantId);
                return Ok(result);

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
