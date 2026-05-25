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
    public class SupplierController : ControllerBase
    {

        private readonly ISupplier _supplier;
        private readonly IMapper _mapper;
        public SupplierController(ISupplier supplier, IMapper mapper)
        {
            _mapper = mapper;
            _supplier = supplier;
        }

        [HttpPost("addSupplier")]
        public ActionResult<string> addSupplier(AddSupplierDTO newSupplier)
        {
            try
            {
                var supplier = _mapper.Map<Supplier>(newSupplier);
                var result = _supplier.addSupplier(supplier);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getAllSuppliers")]
        public ActionResult<List<Supplier>> getAllSuppliers()
        {
            try
            {
                var result = _supplier.getAllSuppliers();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getSupplierById/{id}")]
        public ActionResult<SupplierResponseDTO> getSupplierById(Guid id)
        {
            try
            {
                var result = _supplier.getSupplierById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("updateSupplier/{Id}")]
        public ActionResult<string> updateSupplier(Guid Id, AddSupplierDTO updateSupplier)
        {
            try
            {
                var existingSupplier = _supplier.getSupplierById1(Id);
                if (existingSupplier == null)
                {
                    return NotFound("Supplier not found");
                }

                var supplier = _mapper.Map(updateSupplier, existingSupplier);
                var result = _supplier.updateSupplier(supplier);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("deleteSupplier/{id}")]
        public ActionResult<string> deleteSupplier(Guid id)
        {
            try
            {
                var existingSupplier = _supplier.getSupplierById1(id);
                if (existingSupplier == null)
                {
                    return NotFound("Supplier not found");
                }
                var result = _supplier.deleteSupplier(existingSupplier);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
