using AutoMapper;
using FdkElevator.Migrations;
using FdkElevator.Models.Projects;
using FdkElevator.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static FdkElevator.DTOS.ProjectDTOS.ProjectMaintenanceDTO;
using static FdkElevator.DTOS.ProjectDTOS.ProjectMaintenanceResponses;

namespace FdkElevator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectContractController : ControllerBase
    {
        private readonly IprojectMaintenanceContract _projectContract;
        private readonly IMapper _mapper;
        public ProjectContractController(IprojectMaintenanceContract pMC, IMapper mapper)
        {
            _mapper = mapper;
            _projectContract = pMC;
        }


        [HttpPost]
        public ActionResult<string> addProjectContract(CreateAMCContractRequest aMC)
        {
            try
            {
                var projectContract = _mapper.Map<AMCContract>(aMC);
                var result = _projectContract.addProjectContract(projectContract);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{tenantID}")]
        public ActionResult<List<AMCContract>> GetAMCContracts(Guid tenantID)
        {
            try
            {
                var projectContract = _projectContract.GetAMCContracts(tenantID);
                return Ok(projectContract);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("project/{projectId}")]
        public ActionResult<AMCContract> GetAMCContractsByProject(Guid projectId)
        {
            try
            {
                var projectContract = _projectContract.GetAMCContractsByProject(projectId);
                return Ok(projectContract);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<string> updateContract(Guid id, UpdateAMCContractRequest aMC)
        {
            try
            {
                var existingContract = _projectContract.getContractById(id);
                if (existingContract == null)
                {
                    return NotFound($"Contract with ID {id} not found.");
                }
                var updatedContract = _mapper.Map(aMC, existingContract);
                var result = _projectContract.updateContract(updatedContract);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("contract/asset/new")]
        public ActionResult<string> addAMCContractAsset( CreateAMCContractAssetRequest aMCContractAssetRequest)
        {
            try
            {
                var amcContractReq = _mapper.Map<AMCContractAsset>(aMCContractAssetRequest);
                var result = _projectContract.addContractAsset(amcContractReq);
                return Ok(result);                    
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("contract/asset/{Id}")]
        public ActionResult<string> updateAMCContractAsset(Guid Id, CreateAMCContractAssetRequest aMCContractAssetRequest)
        {
            try
            {
                var existingAsset = _projectContract.getContractAssetById(Id);

                if(existingAsset == null)
                {
                    return NotFound("Contract Asset Not Found");
                }

                var contractAsset = _mapper.Map(aMCContractAssetRequest, existingAsset);

                var result = _projectContract.updateAMCContractAsset(contractAsset);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPost("warranty")]
        public ActionResult<string> addWarrantyRecord(CreateWarrantyRecordRequest wrr)
        {
            try
            {
                var warrantyRecord = _mapper.Map<WarrantyRecord>(wrr);
                var result = _projectContract.addWarrantyRecord(warrantyRecord);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpGet("warranty/{Id}")]
        //public ActionResult<string> getWarrantyRecord(Guid Id)
        //{
        //    try
        //    {

        //        var result = _projectContract.GetWarrantyRecord(Id);
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}


        [HttpPut("warranty/{Id}")]
        public ActionResult<string> getWarrantyRecord(Guid Id, CreateWarrantyRecordRequest wrr)
        {
            try
            {

                var existingWR = _projectContract.GetWarrantyRecord(Id);

                if(existingWR == null)
                {
                    return NotFound("Warranty Record Added");
                }

                var updatedWrr= _mapper.Map(wrr, existingWR);
                var result = _projectContract.updateWarrantyRecord(updatedWrr);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("summary/{clientId}")]
        public ActionResult<AMCContractDetailResponse> getAMCContractByClient(Guid clientId)
        {
            try
            {
                var liftAssets = _projectContract.GetAMCContractDetailByClientId(clientId);
                return Ok(liftAssets);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("summary/project/{projectId}")]
        public ActionResult<AMCContractDetailResponse> getAMCContractByProject(Guid projectId)
        {
            try
            {
                var liftAssets = _projectContract.GetAMCContractDetailByProjectId(projectId);
                return Ok(liftAssets);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

      
    }
}
