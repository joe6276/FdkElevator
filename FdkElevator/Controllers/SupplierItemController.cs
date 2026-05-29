using AutoMapper;
using FdkElevator.DTOS.SupplierDTO;
using FdkElevator.Models.Suppliers;
using FdkElevator.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FdkElevator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierItemController : ControllerBase
    {

        private readonly ISupplierItem _supplierItem;
        private readonly IMapper _mapper;

        public SupplierItemController(ISupplierItem supplierItem, IMapper mapper)
        {
            _supplierItem = supplierItem;
            _mapper = mapper;
        }
        [HttpPost("addSupplierItem")]
        public ActionResult<string> addSupplierItem(AddSupplierItemDTO supplierItemDTO)
        {
            try
            {
                var supplierItem = _mapper.Map<SupplierItem>(supplierItemDTO);

                var result = _supplierItem.addSupplierItem(supplierItem);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("items")]
        public ActionResult<string> addSupplierItem(List<AddSupplierItemDTO> itemsss)
        {
            try
            {
                var supplierItem = _mapper.Map<List<SupplierItem>>(itemsss);

                var result = _supplierItem.addSuppliersItems(supplierItem);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
