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
    public class ServiceQuoteController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IServiceQuote _serviceQuote;

        public ServiceQuoteController(IMapper mapper, IServiceQuote serviceQuote)
        {
            _mapper = mapper;
            _serviceQuote = serviceQuote;
        }

        [HttpPost]
        public async Task<ActionResult<string>> addServicePartRequest(CreateServiceQuoteRequest createServiceQuote)
        {
            try
            {
                var serviceQuote = _mapper.Map<ServiceQuote>(createServiceQuote);
                var result = await _serviceQuote.addServiceQuote(serviceQuote);
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
                var result = await _serviceQuote.getServiceQuoteByJobId(jobId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("status/{Id}")]
        public async Task<ActionResult<string>> updateServicePartRequestStatus(Guid Id, ProjectMaintenanceQuoteStatus status)
        {
            try
            {
                var existingserviceQuote = await _serviceQuote.GetServiceQuoteById(Id);
                if (existingserviceQuote == null)
                {
                    return NotFound("Service part Request Not Found!");
                }
                var result = await _serviceQuote.updateStatus(Id,status);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
