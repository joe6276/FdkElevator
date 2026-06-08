using AutoMapper;
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
    public class ProjectMaintenanceController : ControllerBase
    {
        private readonly IProjectMaintenance _projectMaintenance;
        private readonly IMapper _mapper;
        public ProjectMaintenanceController(IProjectMaintenance projectMaintenance, IMapper mapper)
        {
            _mapper = mapper;
            _projectMaintenance = projectMaintenance;
        }

        [HttpPost]
        public ActionResult<string> addLiftAsset(CreateLiftAssetRequest clR)
        {
            try
            {
                var liftAsset = _mapper.Map<LiftAsset>(clR);
                var result = _projectMaintenance.addLiftAsset(liftAsset);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet    ]
        public ActionResult<List<LiftAssetDetailResponse>> GetLiftAssets()
        {
            try
            {
                var liftAssets = _projectMaintenance.GetLiftAssets();
                return Ok(liftAssets);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<string> updateLiftAsset(Guid id, UpdateLiftAssetRequest ulR)
        {
            try
            {
               var existingLiftAsset= _projectMaintenance.GetLiftAssetById(id);
                if (existingLiftAsset == null)
                {
                    return NotFound($"Lift asset with ID {id} not found.");
                }
                var liftAsset = _mapper.Map(ulR, existingLiftAsset);

                var result = _projectMaintenance.updateLiftAsset(liftAsset);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("new/component")]
        public ActionResult<string> addLiftAsset(CreateAssetComponentRequest clR)
        {
            try
            {
                var component = _mapper.Map<AssetComponent>(clR);
                var result = _projectMaintenance.addNewComponent(component);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("component/{id}")]
        public ActionResult<string> updatetAssetComponent(Guid id, CreateAssetComponentRequest ulR)
        {
            try
            {
                var existingComponent = _projectMaintenance.getAssetComponentById(id);
                if (existingComponent == null)
                {
                    return NotFound($"Asset Component with ID {id} not found.");
                }
                var component = _mapper.Map(ulR, existingComponent);

                var result = _projectMaintenance.updateAssetComponent(component);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("component/{id}")]
        public ActionResult<string> updatetAssetComponent(Guid id)
        {
            try
            {
                var existingComponent = _projectMaintenance.getAssetComponentById(id);
                if (existingComponent == null)
                {
                    return NotFound($"Asset Component with ID {id} not found.");
                }
                var result = _projectMaintenance.deleteAssetComponent(existingComponent);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


    }
}
