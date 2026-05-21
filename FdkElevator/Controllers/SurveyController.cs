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
                var survey = _mapper.Map<Survey>(surveyDTO);
                var result = _survey.addSurvey(survey);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("updateSurvey/{surveyId}")]
        public async  Task<ActionResult<string>> AddSurvey(Guid surveyId, SurveyDTO newSurvey)
        {
            try
            {   


                var survey = _survey.GetSurveyById(surveyId);

                if(survey == null)
                {
                    return NotFound("Survey not found");
                }

                var updatedSurvey = _mapper.Map(newSurvey, survey);

                var result =  await _survey.update(updatedSurvey);

                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("surveys/tenant/{tenantId}")]
        public ActionResult<List<Survey>> GetSurveys(Guid tenantId)
        {
            try
            {
                var surveys = _survey.GetSurveys(tenantId);
                return Ok(surveys);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("survey/{Id}")]
        public ActionResult<Survey> getSurvey(Guid Id)
        {
            try
            {
                var survey = _survey.GetSurveyById(Id);
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


        [HttpPut("updateSurvey/{Id}")]
        public ActionResult<string> UpdateSurvey(Guid Id, SurveyDTO surveyDTO)
        {
            try
            {

                var existingSurvey = _survey.GetSurveyById(Id);

                if (existingSurvey == null)
                {
                    return NotFound("Survey not found");
                }
                var survey = _mapper.Map(surveyDTO, existingSurvey);

                var result = _survey.updateSurvey(survey);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }
    }
}
