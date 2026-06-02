using AutoMapper;
using FdkElevator.DTOS.TenantDTOS;
using FdkElevator.Models.Tenants;
using FdkElevator.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FdkElevator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {

        private readonly IContract _contract;
        private readonly IMapper _mapper;


        public ContractController(IContract contract, IMapper mapper)
        {
            _contract = contract;
            _mapper = mapper;
        }


        [HttpPost]
        public ActionResult<string> addContract(ContractDTO newContract)
        {
            try
            {
                var contract = _mapper.Map<MyContract>(newContract);
                var result = _contract.addContract(contract);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{tenantId}")]
        public ActionResult<List<MyContract>> getContractsByTenantId(Guid tenantId)
        {
            try
            {
                var result = _contract.getContractsByTenantId(tenantId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{contractId}")]
        public ActionResult<string> updateContract(Guid contractId, ContractDTO updatedContract)
        {
            try
            {
                var existingContract = _contract.getContract(contractId);
                if (existingContract == null)
                    return NotFound("Contract not found");
                existingContract = _mapper.Map(updatedContract, existingContract);
                var result = _contract.updateContract(existingContract);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{contractId}")]
        public ActionResult<string> deleteContract(Guid contractId)
        {
            try
            {
                var existingContract = _contract.getContract(contractId);
                if (existingContract == null)
                    return NotFound("Contract not found");

                var result = _contract.deleteContract(existingContract);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("sign")]
        public ActionResult<bool> signContract(SignContractDTO signContractDTO)
        {
            try
            {
                var result = _contract.signContract(signContractDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
