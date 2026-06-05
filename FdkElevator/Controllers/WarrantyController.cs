using AutoMapper;
using FdkElevator.DTOS.WarrantyDTO;
using FdkElevator.Models.Warranty;
using FdkElevator.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FdkElevator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarrantyController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IWarranty _warranty;

        public WarrantyController(IMapper mapper, IWarranty warranty)
        {
            _mapper = mapper;
            _warranty = warranty;
        }

        [HttpPost("warranty")]
        public ActionResult<string> addWarranty(AddWarrantyDTO warrantyDTO)
        {
            try
            {
                var warranty = _mapper.Map<HandoverWarranty>(warrantyDTO);
                var result = _warranty.addWarranty(warranty);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("warranty/{projectId}")]
        public ActionResult<HandoverWarranty> getWarrantyByProjectId(Guid projectId)
        {
            try
            {
                var result = _warranty.getWarrantyByProjectId(projectId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("warranty/{warrantyId}")]
        public ActionResult<HandoverWarranty> getWarrantyByWarrantyId(Guid warrantyId)
        {
            try
            {
                var result = _warranty.getWarrantyById(warrantyId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("warranty/{Id}")]
        public ActionResult<string> updateWarranty(AddWarrantyDTO warrantyDTO, Guid Id)
        {
            try
            {
                var warranty = _warranty.getWarrantyById(Id);
                if (warranty == null)
                    return NotFound("Warranty not found");
                var updatedWarranty = _mapper.Map(warrantyDTO, warranty);
                var result = _warranty.updateWarranty(updatedWarranty);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
