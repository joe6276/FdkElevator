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
    public class ProjectTeamController : ControllerBase
    {

        private readonly IProjectTeam _projectTeam;
        private readonly IMapper _mapper;

        public ProjectTeamController(IMapper mapper, IProjectTeam projectTeam)
        {
            _mapper = mapper;
            _projectTeam = projectTeam;
        }

        [HttpPost("addProjectTeam")]
        public async Task<ActionResult<string>> addProjectTeam(List<AddProjectTeamDTO> newprojectTeam)
        {
            try
            {

                var projectTeam = _mapper.Map<List<ProjectTeam>>(newprojectTeam);
                var result = await _projectTeam.addProjectTeam(projectTeam);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
