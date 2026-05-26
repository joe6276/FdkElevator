using AutoMapper;
using FdkElevator.DTOS.SurveyDTOS;
using FdkElevator.Models.Surveyors;
using FdkElevator.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FdkElevator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly ISurvey _survey;
        private readonly IMapper _mapper;


        public SurveyController(ISurvey survey, IMapper mapper)
        {
            _survey = survey;
            _mapper = mapper;
        }


        [HttpPost("assignSurveyor")]
        public ActionResult<string> AddSurvey(AssignSurveyDTO surveyDTO)
        {
            try
            {
                var survey = _mapper.Map<AllSurvey>(surveyDTO);
                var result = _survey.addSurvey(survey);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("updateSurvey/{surveyId}")]
        public async Task<ActionResult<string>> UpdateSurvey(Guid surveyId, SurveyDTO request)
        {
            try
            {
                var updatedSurvey = await _survey.GetSurveyByIdAsync(surveyId);
                if (updatedSurvey == null)
                    return NotFound("Survey not found");

                updatedSurvey.ProjectInfo= _mapper.Map<ProjectInfo>(request.ProjectInfo);
                updatedSurvey.ShaftStructuralInfo = _mapper.Map<ShaftStructural>(request.ShaftStructural);
                updatedSurvey.EntranceDoorDetails = _mapper.Map<EntranceDoor>(request.EntranceDoor);
                updatedSurvey.PowerElectricalInfo = _mapper.Map<PowerElectrical>(request.PowerElectrical);
                updatedSurvey.UsageTrafficInfo = _mapper.Map<UsageTraffic>(request.UsageTraffic);
                updatedSurvey.FinishingDesignPreferences = _mapper.Map<FinishingDesign>(request.FinishingDesign);
                updatedSurvey.SafetyComplianceInfo = _mapper.Map<SafetyCompliance>(request.SafetyCompliance);
                updatedSurvey.MaintenanceServiceInfo = _mapper.Map<MaintenanceService>(request.MaintenanceService);
                updatedSurvey.SiteMediaAttachments = _mapper.Map<SiteMediaAttachment>(request.SiteMediaAttachments);
                updatedSurvey.AdditionalNotes = _mapper.Map<AdditionalNote>(request.AdditionalNotes);

                var result = await _survey.UpdateSurveyAsync(updatedSurvey);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("surveys/tenant/{tenantId}")]
        public async Task<ActionResult<List<AllSurvey>> > GetSurveys(Guid tenantId)
        {
            try
            {
                var surveys = await  _survey.GetSurveysByTenantAsync(tenantId);
                return Ok(surveys);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("survey/{Id}")]
        public async Task<ActionResult<AllSurvey>> getSurvey(Guid Id)
        {
            try
            {
                var survey = await  _survey.GetSurveyByIdAsync(Id);
                if (survey == null)
                {
                    return NotFound("Survey not found");
                }
                return Ok(survey);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

        
    }
}
