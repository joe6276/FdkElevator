using AutoMapper;
using FdkElevator.DTOS.LeadDTOS;
using FdkElevator.Models.Leads;
using FdkElevator.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FdkElevator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActivityController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IActivity _activity;

        public ActivityController(IMapper mapper, IActivity activity)
        {
            _mapper = mapper;
            _activity = activity;
        }

    

        [HttpGet("activities/{leadId}")]
        public ActionResult<List<ResponseActivityDTO>> getActivity(Guid leadId)
        {
            try
            {
                var activity = _activity.getActivitiesList(leadId);

                if (activity == null)
                {
                    return NotFound("Activity not found");
                }

                return Ok(activity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpPost("addActivity")]
        public ActionResult<string> AddActivity(AddActivityDTO activityDTO)
        {
            try
            {
                var activity = _mapper.Map<Activity>(activityDTO);

                var result = _activity.addActivity(activity);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
