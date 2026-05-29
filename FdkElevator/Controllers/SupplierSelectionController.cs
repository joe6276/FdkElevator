using AutoMapper;
using FdkElevator.DTOS.ProjectDTOS;
using FdkElevator.DTOS.SelectionDTO;
using FdkElevator.Models.Selection;
using FdkElevator.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FdkElevator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierSelectionController : ControllerBase
    {

        private readonly ISupplierSelection _supplierSelection;
        private readonly IMapper _mapper;

        public SupplierSelectionController(ISupplierSelection supplierSelection, IMapper mapper)
        {
            _supplierSelection = supplierSelection;
            _mapper = mapper;
        }

        [HttpGet("getSupplierSelection/{projectId}")]
        public List<SupplierSelectionDTO> getSupplierSelection(Guid projectId)
        {
            try
            {
                var result = _supplierSelection.getmaterials(projectId);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("selectedProducts")]

        public ActionResult<string> addSelectedProducts(SelectedProductDTO selectedProduct)
        {
            try
            {
                var products = _mapper.Map<SelectedProduct>(selectedProduct);
                products.Products = _mapper.Map<List<Product>>(selectedProduct.selectedProducts);

                var result = _supplierSelection.addSelectedProducts(products);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getSelectedProducts/{projectId}")]
        public async  Task<ActionResult<List<SelectedProduct>>> getSelectedProducts(Guid projectId)
        {
            try
            {
                var result = await _supplierSelection.GetSelectedProductsByProjectId(projectId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("approve")]
        public ActionResult<string> approvedSeletedProduct(ApproveSelectedProducts asp)
        {
            try
            {
                var result = _supplierSelection.approveSelectedProduct(asp.Id, asp.UserId);
                return Ok(result);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
