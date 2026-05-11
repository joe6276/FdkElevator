using AutoMapper;
using FdkElevator.DTOS.TenantDTOS;
using FdkElevator.Models.Tenants;
using FdkElevator.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FdkElevator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class tenantController : ControllerBase
    {
        private readonly ITenant _tenant;
        private readonly IMapper _mapper;
        public tenantController(IMapper mapper, ITenant tenant)
        {
            _tenant = tenant;
            _mapper = mapper;
        }

        [HttpPost("addtenant")]
        public ActionResult<string> addTenantt(TenantDTO tenantDTO)
        {
            try
            {
                var tenant = _mapper.Map<Tenant>(tenantDTO);
                var result = _tenant.Addtenant(tenant);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("activetenants")]
        public ActionResult<List<Tenant>> getActiveTenants()
        {
            try
            {
                var tenants = _tenant.getAllActiveTenants();
                return Ok(tenants);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("inactivetenants")]
        public ActionResult<List<Tenant>> getInActiveTenants()
        {
            try
            {
                var tenants = _tenant.getAllInActiveTenants();
                return Ok(tenants);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("tenants/{Id}")]
        public ActionResult<List<Tenant>> GetTenant(Guid Id)
        {
            try
            {
                var tenant = _tenant.getTenantById(Id);

                if (tenant == null)
                {
                    return NotFound("Tenant Not Found");
                }

                return Ok(tenant);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpPut("updatetenant/{Id}")]
        public ActionResult<string> updateTenant(TenantDTO tenantDTO, Guid Id)
        {
            try
            {
                var tenant = _tenant.getTenantById(Id);

                if (tenant == null)
                {
                    return NotFound("Tenant Not Found");
                }

                var updatedTenant = _mapper.Map(tenantDTO, tenant);
                var result = _tenant.UpdateTenant(updatedTenant);

                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("deletetenant/{Id}")]
        public ActionResult<string> deleteTenant( Guid Id)
        {
            try
            {
                var tenant = _tenant.getTenantById(Id);

                if (tenant == null)
                {
                    return NotFound("Tenant Not Found");
                }
                var result = _tenant.DeleteTenant(tenant);

                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }

}
