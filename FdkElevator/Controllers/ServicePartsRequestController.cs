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
    public class ServicePartsRequestController : ControllerBase
    {
        private readonly IServicePartsRequest _partRequest;
        private readonly IMapper _mapper;

        public ServicePartsRequestController(IServicePartsRequest serviceParts, IMapper mapper )
        {
            _mapper = mapper;
            _partRequest = serviceParts;
        }
        [HttpPost]
        public async Task<ActionResult<string>> addServicePartRequest(CreateServicePartsRequestDto createServicePartsRequestDto)
        {
            try
            {
                var servicePart = _mapper.Map<ServicePartsRequest>(createServicePartsRequestDto);
                var result = await _partRequest.addPartsRequest(servicePart);
                return Ok(result);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("job/{jobId}")]
        public async Task<ActionResult<List<ServicePartsRequest>>> GetServiceByJobId(Guid jobId)
        {
            try
            {
                var result = await _partRequest.getServicepartBasedOnJobId(jobId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<string>> updateServicePartRequest( Guid Id, CreateServicePartsRequestDto createServicePartsRequestDto)
        {
            try
            {
                var existingPartRequest = await _partRequest.GetServicePartsRequestById(Id);
                if(existingPartRequest == null)
                {
                    return NotFound("Service part Request Not Found!");
                }

                var updatedServicePart= _mapper.Map(createServicePartsRequestDto, existingPartRequest);
                var result= await  _partRequest.updateServiceParts(updatedServicePart);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("status/{Id}")]
        public async Task<ActionResult<string>> updateServicePartRequestStatus(Guid Id, ProjectMaintenancePartRequestStatus status)
        {
            try
            {
                var existingPartRequest = await _partRequest.GetServicePartsRequestById(Id);
                if (existingPartRequest == null)
                {
                    return NotFound("Service part Request Not Found!");
                }
                var result = await _partRequest.updateServicePartStatus(status,Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
