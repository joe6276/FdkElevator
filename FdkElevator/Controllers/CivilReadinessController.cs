using AutoMapper;
using FdkElevator.DTOS.CivilDTO;
using FdkElevator.Models.Civil;
using FdkElevator.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FdkElevator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CivilReadinessController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly ICivilReadiness _civilReadiness;
        public CivilReadinessController(IMapper mapper, ICivilReadiness civilReadiness)
        {
            _mapper = mapper;
            _civilReadiness = civilReadiness;
        }

        [HttpPost]
        public ActionResult<string> addCivilReadiness(CivilReadinessDTO civilReadinessDTO)
        {
            try
            {
                var civilReadiness = _mapper.Map<CivilReadiness>(civilReadinessDTO);
                var result = _civilReadiness.addCivilReadiness(civilReadiness);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{projectId}")]
        public ActionResult<CivilReadiness> getCivilReadinessByProjectId(Guid projectId)
        {
            try
            {
                var result = _civilReadiness.getCivilReadinessByProjectId(projectId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{Id}")]
        public ActionResult<string> updateCivilReadiness(CivilReadinessDTO civilReadinessDTO, Guid Id)
        {
            try
            {
                var cr = _civilReadiness.getCivilReadinessById(Id);

                if (cr == null)
                {
                    return NotFound("Civil Readiness not found");
                }

                var civilReadiness = _mapper.Map(civilReadinessDTO, cr);

                var result = _civilReadiness.updateCivilReadiness(civilReadiness);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("markCivicReadiness/{projectId}")]
        public ActionResult<string> markCivicReadiness(Guid projectId)
        {
            try
            {
                var result = _civilReadiness.markCivicReadiness(projectId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
