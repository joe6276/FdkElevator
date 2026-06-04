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
    public class ProjectSignedDocController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProjectSignedDoc _projectSignedDoc;

        public ProjectSignedDocController(IMapper mapper, IProjectSignedDoc projectSignedDoc)
        {
            _mapper = mapper;
            _projectSignedDoc = projectSignedDoc;
        }

        [HttpPost]
        public ActionResult<string> addProjectSignedDoc(ProjectSignedDocDTO psdd)
        {
            try
            {   
                var projectSignedDoc = _mapper.Map<ProjectSignedDoc>(psdd);
                var result = _projectSignedDoc.addProjectSignedDocs(projectSignedDoc);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<ProjectDoc> getUnsignedDoc(Guid projectId)
        {
            try
            {
                var result = _projectSignedDoc.GetUnsignedDocumentsAsync(projectId);
                return Ok(result);


            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
  
    }
}
