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
    public class JobAssignmentController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IJobAssignment _jobAssignment;

        public JobAssignmentController(IMapper mapper, IJobAssignment jobAssignment)
        {
            _mapper = mapper;
            _jobAssignment = jobAssignment;
        }
   

        [HttpPost]
        public async Task<ActionResult<string>> assignJobAssignment(CreateJobAssignmentRequest request)
        {
            try
            {
                var jobAssignment = _mapper.Map<JobAssignment>(request);
                var result= await  _jobAssignment.addJobAssignment(jobAssignment);

                return Ok(result);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("jobs/{userId}")]
        public async Task<ActionResult<List<JobAssignment>>> getUserJobAssignments(Guid userId)
        {
            try
            {
                var result= await _jobAssignment.getUserJobs(userId);
                return Ok(result);

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

   

        [HttpPut("jobs/{Id}")]
        public async Task<ActionResult<string>> updateJobAssignment(Guid Id, CreateJobAssignmentRequest request)
        {
            try
            {
                var existingJobs = await _jobAssignment.GetJobAssignmentById(Id);
                if(existingJobs == null)
                {
                    return NotFound("Job assignment updated!");
                }

                var updatedJob= _mapper.Map(request, existingJobs);
                var result = await  _jobAssignment.updateJobAssignment(updatedJob);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("jobs/{Id}")]
        public async Task<ActionResult<string>> deleteJobAssignment(Guid Id)
        {
            try
            {
                var existingJobs = await _jobAssignment.GetJobAssignmentById(Id);
                if (existingJobs == null)
                {
                    return NotFound("Job assignment updated!");
                }

              
                var result = await _jobAssignment.deleteJobAssignment(existingJobs);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
