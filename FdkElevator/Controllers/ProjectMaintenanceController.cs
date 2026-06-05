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
    public class ProjectMaintenanceController : ControllerBase
    {

        private readonly IProjectMaintenance _projectMaintenance;
        private readonly IMapper _mapper;

        public ProjectMaintenanceController(IProjectMaintenance projectMaintenance, IMapper mapper)
        {
            _projectMaintenance = projectMaintenance;
            _mapper = mapper;
        }

        [HttpPost("add")]
        public ActionResult<string> AddProjectMaintenance([FromBody] ProjectMaintenanceRequest request)
        {
            try
            {
                var mapped = _mapper.Map<ProjectMaintenances>(request);
                var result = _projectMaintenance.addProjectMaintenance(mapped);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("project/{projectId}")]
        public ActionResult<ProjectWithContractDto> GetProjectMaintenancesByProjectId(Guid projectId)
        {
            try
            {
                var result = _projectMaintenance.getProjectMaintenancesByProjectId(projectId);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("contract/{id}")]
        public ActionResult<AMCContract> GetContractById(Guid id)
        {
            try
            {
                var result = _projectMaintenance.getContractById(id);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("contract/update/{contractId}")]
        public ActionResult<string> UpdateContract(Guid contractId, [FromBody] AMCContractRequest request)
        {
            try
            {

                var existingContract = _projectMaintenance.getContractById(contractId);

                if(existingContract == null)
                {
                    return NotFound("Contract Not Found");
                }
                var mapped = _mapper.Map(request, existingContract);

                var result = _projectMaintenance.updateContract(mapped);

                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("payment/add")]
        public ActionResult<string> AddPayment([FromBody] List<ProjectMaintenancePaymentRequest> requests)
        {
            try
            {
                var mapped = _mapper.Map<List<ProjectMaintenancePayment>>(requests);
                var result = _projectMaintenance.addpayment(mapped);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("payment/mark-paid/{paymentId}")]
        public ActionResult<string> MarkPaymentAsPaid(Guid paymentId, [FromBody] string paymentReceiptImage)
        {
            try
            {
                var result = _projectMaintenance.markPaymentAsPaid(paymentId, paymentReceiptImage);
                return Ok(result);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("schedule/add")]
        public ActionResult<string> AddMaintenanceSchedule([FromBody] List<MaintenanceScheduleRequest> requests)
        {
            try
            {
                var mapped = _mapper.Map<List<MaintenanceSchedule>>(requests);
                var result = _projectMaintenance.addMaintenanceSchedule(mapped);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("schedule/update")]
        public ActionResult<string> UpdateMaintenanceSchedule([FromBody] MaintenanceScheduleRequest request)
        {
            try
            {
                var mapped = _mapper.Map<MaintenanceSchedule>(request);
                var result = _projectMaintenance.updateMaintenanceSchedule(mapped);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("schedule/project/{projectId}")]
        public ActionResult<List<MaintenanceSchedule>> GetMaintenanceSchedulesByProjectId(Guid projectId)
        {
            try
            {
                var result = _projectMaintenance.getMaintenanceSchedulesByProjectId(projectId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPost("report/add")]
        public ActionResult<string> AddTechnicianReport([FromBody] TechnicianReportRequest request)
        {
            try
            {
                var mapped = _mapper.Map<TechnicianReport>(request);
                var result = _projectMaintenance.addTechnicianReport(mapped);
                return Ok(result);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("report/project/{projectId}")]
        public ActionResult<TechnicianReport> GetTechnicianReportsByProjectId(Guid projectId)
        {
            try
            {
                var result = _projectMaintenance.getTechnicianReportsByProjectId(projectId);
                return Ok(result);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("summary/{projectId}")]
        public async Task<ActionResult<ProjectMaintenanceSummaryDto>> getProjectSummary(Guid projectId)
        {

            try
            {
                var response = await _projectMaintenance.GetProjectSummaryAsync(projectId);

                return Ok(response);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
