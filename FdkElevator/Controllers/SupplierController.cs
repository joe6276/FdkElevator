using AutoMapper;
using FdkElevator.DTOS.Auth;
using FdkElevator.DTOS.SupplierDTO;
using FdkElevator.Models.Auth;
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
        public async Task<ActionResult<string>> addSupplier(AddSupplierDTO newSupplier)
        {
            try
            {
                var supplier = _mapper.Map<Supplier>(newSupplier);
                var result = await _supplier.addSupplier(supplier);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("login")]
        public ActionResult<LoginResponse> Login(LoginUser loginUser)
        {
            try
            {

                var result = _supplier.loginUser(loginUser.Email, loginUser.Password);

                if (result == null)
                {
                    return Unauthorized("Invalid email or password");
                }

                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
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

        [HttpGet("getAllSuppliersitems")]
        public ActionResult<List<SupplierResponseDTO>> getAllSuppliersItems()
        {
            try
            {
                var result = _supplier.getSupplierItems();
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
