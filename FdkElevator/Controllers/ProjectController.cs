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
    public class ProjectController : ControllerBase
    {

        private readonly IProject _project;
        private readonly IMapper _mapper;

        public ProjectController(IProject project, IMapper mapper)
        {
            _mapper = mapper;
            _project = project;
        }

        [HttpPost]
        public ActionResult<string> addProject(AddProjectDTO apd)
        {
            try
            {
                var project = _mapper.Map<Project>(apd);
                var result = _project.addProject(project);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllProjects/{tenantId}")]
        public ActionResult<List<Project>> GetAll(Guid tenantId)
        {
            try
            {
                var projects = _project.getAllProjects(tenantId);
                return Ok(projects);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("GetProjectByClientId/{id}")]
        public ActionResult<List<ProjectResponseDTO>> GetProjectByClientId(Guid id)
        {
            try
            {
                var projects = _project.getProjectByClientId(id);
                return Ok(projects);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetProjectById/{id}")]
        public ActionResult<ProjectResponseDTO> GetProjectById(Guid id)
        {
            try
            {
                var project = _project.getProjectById(id);
                return Ok(project);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("UpdateProjectStatus/{id}")]
        public ActionResult<string> UpdateProjectStatus(Guid id, ProjectStatus status)
        {
            try
            {
                var result = _project.updateProjectStatus(id, status);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        }
}
