using AutoMapper;
using FdkElevator.Models.Projects;
using FdkElevator.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static FdkElevator.DTOS.ProjectDTOS.ProjectMaintenanceDTO;

namespace FdkElevator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectMaintenanceEvidenceUploadController : ControllerBase
    {

        private readonly IEvidenceUploadService _evidenceUploadService;
        private readonly IMapper _mapper;

        public ProjectMaintenanceEvidenceUploadController(IEvidenceUploadService evidenceUpload, IMapper mapper)
        {
            _evidenceUploadService = evidenceUpload;
            _mapper = mapper;
        }


        //bool deleteEvidence(EvidenceUpload evidenceUpload);
        //bool setClientVisibility(Guid id, bool isVisible);

        [HttpGet]
        public ActionResult<List<EvidenceUpload>> GetByJob(Guid jobId)
        {
            try
            {
                var evidenceUploads = _evidenceUploadService.GetByJobs(jobId);
                return Ok(evidenceUploads);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<string> uploadEvidence(CreateEvidenceUploadRequest ceur)
        {
            try
            {
                var evidenceUpload = _mapper.Map<EvidenceUpload>(ceur);
                var result = _evidenceUploadService.uploadEvidence(evidenceUpload);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Id")]
        public ActionResult<EvidenceUpload> GetById(Guid Id)
        {
            try
            {
                var evidenceUpload = _evidenceUploadService.GetById(Id);
                if (evidenceUpload == null)
                {
                    return NotFound("Evidence upload not found");
                }
                return Ok(evidenceUpload);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("visibility/{Id}")]
        public ActionResult<string> steClientVisibility(Guid Id, bool uploadRequest)
        {
            try
            {
                var result= _evidenceUploadService.setClientVisibility(Id, uploadRequest);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{Id}")]
        public ActionResult<bool> DeleteById(Guid Id)
        {
            try
            {   
                var existingEvidence = _evidenceUploadService.GetById(Id);
                if (existingEvidence == null)
                {
                    return NotFound("Evidence upload not found");
                }
                var result = _evidenceUploadService.deleteEvidence(existingEvidence);
                if (!result)
                {
                    return NotFound("Evidence upload not found");
                }
                return Ok("Evidence upload deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
