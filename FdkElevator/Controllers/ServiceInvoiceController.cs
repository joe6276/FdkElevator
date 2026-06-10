using AutoMapper;
using FdkElevator.Models.Projects;
using FdkElevator.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static FdkElevator.DTOS.ProjectDTOS.ProjectMaintenanceDTO;

namespace FdkElevator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceInvoiceController : ControllerBase
    {

        private readonly IServiceInvoice _serviceInvoice;
        private readonly IMapper _mapper;

        public ServiceInvoiceController(IServiceInvoice service, IMapper mapper)
        {
            _mapper = mapper;
            _serviceInvoice = service;
        }

        [HttpPost]
        public async Task<ActionResult<string>> addServicePartRequest(CreateServiceInvoiceRequest serviceInvoiceRequest)
        {
            try
            {
                var serviceQuote = _mapper.Map<ServiceInvoice>(serviceInvoiceRequest);
                var result = await _serviceInvoice.addServiceInvoice(serviceQuote);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("job/{jobId}")]
        public async Task<ActionResult<List<ServiceQuote>>> GetServiceByJobId(Guid jobId)
        {
            try
            {
                var result = await _serviceInvoice.GetServiceInvoiceByJobId(jobId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("status/{Id}")]
        public async Task<ActionResult<string>> updateServicePartRequestStatus(Guid Id, ProjectMaintenanceInvoiceStatus status)
        {
            try
            {
                var existingserviceQuote = await _serviceInvoice.GetServiceInvoiceById(Id);
                if (existingserviceQuote == null)
                {
                    return NotFound("Service part Request Not Found!");
                }
                var result = await _serviceInvoice.updateServiceInvoice(Id, status);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
