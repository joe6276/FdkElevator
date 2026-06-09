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
    public class projectMaintenanceJobChecklistController : ControllerBase
    {   

        private readonly IJobChecklistResponseService _jobChecklistResponseService;
        private readonly IMapper _mapper;
        public projectMaintenanceJobChecklistController(IMapper mapper, IJobChecklistResponseService jobChecklistResponse)
        {
            _mapper = mapper;
            _jobChecklistResponseService = jobChecklistResponse;
        }

        [HttpPost]
        public ActionResult<string> submitJobCheckList(CreateJobChecklistResponseRequest cjclr)
        {
            try
            {
                var jobChecklistResponse = _mapper.Map<JobChecklistResponse>(cjclr);
                var result = _jobChecklistResponseService.SubmitChecklistResponse(jobChecklistResponse);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("job/{JobId}")]
        public ActionResult<List<JobChecklistResponse>> GetByJob(Guid JobId)
        {
            try
            {
                var checklistResponses = _jobChecklistResponseService.GetByJob(JobId);
                return Ok(checklistResponses);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{Id}")]
        public ActionResult<JobChecklistResponse> GetById(Guid Id)
        {
            try
            {
                var checklistResponse = _jobChecklistResponseService.GetById(Id);
                if (checklistResponse == null)
                {
                    return NotFound("Checklist response not found");
                }
                return Ok(checklistResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("approve")]
        public ActionResult<string> approveChecklistResponse(ApproveChecklistResponseRequest acrr)
        {
            try
            {
                var result = _jobChecklistResponseService.approveChecklistResponse(acrr.Id, acrr.ApprovedByUserId, acrr.Remarks);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public class ApproveChecklistResponseRequest
        {

            public Guid Id { get; set; }
            public Guid ApprovedByUserId { get; set; }
            public string? Remarks { get; set; }
        }

        [HttpDelete("{Id}")]
        public ActionResult<string> deleteChecklistResponse(Guid Id)
        {
            try
            {
                var checklistResponse = _jobChecklistResponseService.GetById(Id);
                if (checklistResponse == null)
                {
                    return NotFound("Checklist response not found");
                }
                var result = _jobChecklistResponseService.deleteChecklistResponse(checklistResponse);
                if (result)
                {
                    return Ok("Checklist response deleted successfully");
                }
                else
                {
                    return BadRequest("Failed to delete checklist response");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
