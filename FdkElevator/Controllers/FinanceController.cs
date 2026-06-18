using FdkElevator.DTOS.FinanceDTO;
using FdkElevator.DTOS.SupplierDTO;
using FdkElevator.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FdkElevator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinanceController : ControllerBase
    {

        private readonly IFinances _finance;
        private readonly ISupplier _supplier;

        public FinanceController(IFinances finance, ISupplier supplier)
        {
            _finance = finance;
            _supplier = supplier;
        }

        [HttpGet("client/{clientId}")]
        public async Task<ActionResult<FinanceClass>> getClientFinances(Guid clientId)
        {
            try
            {
                var finance = await _finance.getClientPayments(clientId);
                return Ok(finance);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("supplier/payments/{supplierId}")]
        public async Task<ActionResult<List<SupplierResponseDTO>>> getAllSuppliersPaymentStatus(Guid supplierId)
        {
            try
            {
                var result = await _supplier.GetSupplierPaymentProgressAsync(supplierId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("tenants/orderpayments/{tenantId}")]
        public async Task<ActionResult<List<SupplierResponseDTO>>> GetAllTenantsById(Guid tenantId)
        {
            try
            {
                var result = await _finance.GetOrdersByTenantAsync(tenantId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    
    }
}
