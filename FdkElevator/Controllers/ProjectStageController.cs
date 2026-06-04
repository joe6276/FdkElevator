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
    public class ProjectStageController : ControllerBase
    {

        private readonly IProjectStage _projectStage;
        private readonly IMapper _mapper;

        public ProjectStageController(IProjectStage projectStage, IMapper mapper)
        {
            _mapper = mapper;
            _projectStage = projectStage;
        }

        [HttpPost]
        public ActionResult<string> addProjectStage(ProjectStageDTO projectStageDTO)
        {
            try
            {
                var projectStage = _mapper.Map<ProjectStage>(projectStageDTO);
                var result = _projectStage.addProjectStage(projectStage);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{phaseId}")]
        public ActionResult<List<ProjectStage>> getProjectStagesByPhaseId(Guid phaseId)
        {
            try
            {
                var result = _projectStage.getProjectStagesByProjectId(phaseId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("user/{userId}")]
        public ActionResult<List<ProjectStage>> getProjectByUserId(Guid userId)
        {
            try
            {
                var result = _projectStage.getProjectbasedOnUser(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
