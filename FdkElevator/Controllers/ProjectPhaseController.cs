using AutoMapper;
using FdkElevator.DTOS.ProjectDTOS;
using FdkElevator.Models.Projects;
using FdkElevator.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FdkElevator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectPhaseController : ControllerBase
    {

        private readonly IProjectPhase _projectPhase;
        private readonly IMapper _mapper;

        public ProjectPhaseController(IProjectPhase projectPhase, IMapper mapper)
        {
            _projectPhase = projectPhase;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<string> addProjectPhase(ProjectPhaseDTO projectPhaseDTO)
        {
            try
            {

                var projectPhase = _mapper.Map<ProjectPhase>(projectPhaseDTO);
                var result = _projectPhase.addProjectPhase(projectPhase);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{projectId}")]
        public ActionResult<List<ProjectPhase>> getProjectPhasesByProjectId(Guid projectId)
        {
            try
            {
                var result = _projectPhase.getProjectPhasesByProjectId(projectId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("phase/{projectPhaseId}")]
        public ActionResult<ProjectPhase> getProjectPhase(Guid projectPhaseId)
        {
            try
            {
                var result = _projectPhase.getProjectPhase(projectPhaseId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{projectId}")]
        public ActionResult<string> updateProjectPhase(ProjectPhaseDTO projectPhaseDTO, Guid projectId)
        {
            try
            {

                var existingProjectPhase = _projectPhase.getProjectPhase(projectId);
                if (existingProjectPhase == null)
                {
                    return NotFound("Project phase not found");
                }

                var projectPhase = _mapper.Map(projectPhaseDTO, existingProjectPhase);
                var result = _projectPhase.updateProjectPhase(projectPhase);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("updatePhaseStatus/{projectId}")]
        public ActionResult<string> updateProjectPhaseStatus(Guid projectId, PhaseStatus newStatus)
        {
            try
            {
                var existingProjectPhase = _projectPhase.getProjectPhase(projectId);
                if (existingProjectPhase == null)
                {
                    return NotFound("Project phase not found");
                }
                var result = _projectPhase.updateProjectPhaseStatus(projectId, newStatus);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpPost("markComplete/{projectId}")]
        public ActionResult<string> markProjectPhaseComplete(Guid projectId, [FromBody] string Notes)
        {
            try
            {
                var existingProjectPhase = _projectPhase.getProjectPhase(projectId);
                if (existingProjectPhase == null)
                {
                    return NotFound("Project phase not found");
                }
                var result = _projectPhase.markProjectPhaseAsCompleted(projectId, Notes);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
