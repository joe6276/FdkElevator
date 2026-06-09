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
    public class ProjectListTemplateController : ControllerBase
    {
        private readonly IProjectChecklistTemplate _projectChecklistTemplate;
        private readonly IMapper _mapper;

        public ProjectListTemplateController(IProjectChecklistTemplate projectChecklistTemplate, IMapper mapper)
        {
            _mapper = mapper;
            _projectChecklistTemplate = projectChecklistTemplate;
        }

        [HttpPost]
        public async Task<ActionResult<ChecklistTemplate>> Create(CreateChecklistTemplateRequest createChecklistTemplate)
        {
            try
            {
                var template = _mapper.Map<ChecklistTemplate>(createChecklistTemplate);
                var createdTemplate = await _projectChecklistTemplate.CreateAsync(template);
                return Ok(createdTemplate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChecklistTemplate>>> GetAll()  
        {
            try
            {
                var templates = await _projectChecklistTemplate.GetAllAsync();    
                return Ok(templates);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ChecklistTemplate>> GetById(Guid id)      
        {
            try
            {
                var template = await _projectChecklistTemplate.GetByIdAsync(id);  
                if (template == null)
                {
                    return NotFound();
                }
                return Ok(template);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("serviceType/{serviceType}")]
        public async Task<ActionResult<IEnumerable<ChecklistTemplate>>> GetByServiceType(ProjectMaintenanceServiceType serviceType)
        {
            try
            {
                var templates = await _projectChecklistTemplate.GetByServiceTypeAsync(serviceType);
                return Ok(templates);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("assetType/{assetType}")]
        public async Task<ActionResult<IEnumerable<ChecklistTemplate>>> GetByAssetType(ProjectMaintenanceAssetType assetType)
        {
            try
            {
                var templates = await _projectChecklistTemplate.GetByAssetTypeAsync(assetType);
                return Ok(templates);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ChecklistTemplate>> Update(Guid id, CreateChecklistTemplateRequest updateRequest)
        {
            try
            {
                var existingTemplate = await _projectChecklistTemplate.GetByIdAsync(id);
                if (existingTemplate == null)
                {
                    return NotFound();
                }

                var template = _mapper.Map(updateRequest, existingTemplate);
                var updatedTemplate = await _projectChecklistTemplate.UpdateAsync(id, template);
                return Ok(updatedTemplate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var success = await _projectChecklistTemplate.DeleteAsync(id);
                if (!success)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}