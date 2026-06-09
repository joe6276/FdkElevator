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
    public class CheckListItemController : ControllerBase
    {

        private readonly IChecklistItemService _checklistItem;
        private readonly IMapper _mapper;

        public CheckListItemController(IChecklistItemService checklist, IMapper mappper)
        {
            _checklistItem = checklist;
            _mapper = mappper;
        }

        [HttpPost]
        public ActionResult<string> createCheckListItem(CreateChecklistItemRequest clir)
        {
            try
            {
                var checklistItem = _mapper.Map<ChecklistItem>(clir);
                var result = _checklistItem.CreateCheckList(checklistItem);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("template/{templateId}")]
        public ActionResult<List<ChecklistItem>> GetAll(Guid templateId)
        {
            try
            {
                var checklistItems = _checklistItem.GetByTemplate(templateId);
                return Ok(checklistItems);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ChecklistItem> GetById(Guid id)
        {
            try
            {
                var checklistItem = _checklistItem.GetById(id);
                if (checklistItem == null)
                {
                    return NotFound();
                }
                return Ok(checklistItem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{Id}")]   
        public ActionResult<string> updateCheckListItem(Guid Id,  CreateChecklistItemRequest request)
        {
            try
            {
                var existingItem = _checklistItem.GetById(Id);
                if (existingItem == null)
                {
                    return NotFound("CheckList Item Found! ");
                }

                var cliupdated= _mapper.Map(request, existingItem);
                var result = _checklistItem.updateCheckList(cliupdated);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpDelete("{Id}")]
        public ActionResult<string> deleteCheckListItem(Guid Id)
        {
            try
            {
                var existingItem = _checklistItem.GetById(Id);
                if (existingItem == null)
                {
                    return NotFound("CheckList Item Found! ");
                }
                var result = _checklistItem.deleteCheckListItem(existingItem);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
