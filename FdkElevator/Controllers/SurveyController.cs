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


        [HttpPost("addSurvey")]
        public async  Task<ActionResult<string>> AddSurvey(SurveyDTO newSurvey)
        {
            try
            {

                var survey = _mapper.Map<Survey>(newSurvey);

                var result =  await _survey.addSurvey(survey);

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
