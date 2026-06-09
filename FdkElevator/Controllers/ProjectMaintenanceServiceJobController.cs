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
    public class ProjectMaintenanceServiceJobController : ControllerBase
    {

        private readonly IJobService _jobService;
        private readonly IMapper _mapper;

        public ProjectMaintenanceServiceJobController(IMapper mapper, IJobService jobService)
        {
            _jobService = jobService;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult<string>> addServiceJob(CreateServiceJobRequest req)
        {
            try
            {
                var job = _mapper.Map<ServiceJob>(req);
                var serviceJob= await  _jobService.addJobService(job);

                return Ok(serviceJob);

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("scheduleId/{scheduleId}")]
        public async Task<ActionResult<List<ServiceJob>>> getServiceJobs( Guid scheduleId)
        {
            try
            {
                var result = await _jobService.GetJobs(scheduleId);
                return Ok(result);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<string>> updateServiceJob(Guid Id, CreateServiceJobRequest req)
        {
            try
            {
                var serviceJob = await _jobService.GetJobById(Id);
                if (serviceJob == null)
                {
                    return NotFound("Job Service not found");
                }


                var updatedServiceJob = _mapper.Map(req,serviceJob);


                var result = await _jobService.UpsertJob(updatedServiceJob);
                return Ok(result);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<string>> deleteServiceJob(Guid Id, CreateServiceJobRequest req)
        {
            try
            {
                var serviceJob = await _jobService.GetJobById(Id);
                if (serviceJob == null)
                {
                    return NotFound("Job Service not found");
                }
                var result = await _jobService.deleteJob(serviceJob);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
