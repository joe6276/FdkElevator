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
    public class ProjectDocController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IProjectDocs _projectDocs;

        public ProjectDocController(IMapper mapper, IProjectDocs projectDocs)
        {

            _mapper = mapper;
            _projectDocs = projectDocs;
        }

        [HttpPost]
        public ActionResult<string> addProjectDocs(AddProjectDocs addProjectDocs)
        {
            try
            {   
                var projectDocs=_mapper.Map<ProjectDoc>(addProjectDocs);

                var result = _projectDocs.addProjectDocs(projectDocs);

                return Ok(result);

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<ProjectDocumentGroupDTO> getDocumentByCategory()
        {
            try
            {
                var result = _projectDocs.GetDocumentsGroupedByCategory();
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
