using AutoMapper;
using FdkElevator.DTOS.InstallationsDTO;
using FdkElevator.Models.Installations;
using FdkElevator.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FdkElevator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstallationController : ControllerBase
    {

        private readonly IInstallation _installation;
        private readonly IMapper _mapper;
        public InstallationController(IInstallation installation, IMapper mapper)
        {
            _installation = installation;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<string> addInstallation(InstallationDTO installationDTO)
        {
            try
            {
                var installation = _mapper.Map<Installation>(installationDTO);
                var result = _installation.addInstallation(installation);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{projectId}")]
            public ActionResult<List<Installation>> getInstallationBYProjectId( Guid projectId)
            {
                try
                {
                    var response = _installation.getInstallationsByProjectId(projectId);
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);

                }

            }

        [HttpPost("{installationId}")]
        public ActionResult<string> addInstallation(Guid installationId, InstallationDTO installationDTO)
        {
            try
            {
                var installation = _installation.getInstallation(installationId);
                if (installation == null)
                {
                    return NotFound("Installation not found");
                }
                var updatedInstallation = _mapper.Map( installationDTO, installation);
                var result = _installation.updateInstallation(updatedInstallation);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }


        [HttpPut("{installationId}/mark-complete")]
        public ActionResult<string> markComplete(Guid installationId, CompletionNotesDTO completionNotesDTO)
        {
            try
            {
                var result = _installation.completeInstallation(installationId, completionNotesDTO.Notes);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("progress/{projectId}")]
        public ActionResult<ProjectInstallationResponseDto> installationProgress(Guid projectId)
        {
            try
            {
                var installation = _installation.GetTasksByProjectAsync(projectId);
                return Ok(installation);

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
    }
