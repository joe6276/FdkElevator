using AutoMapper;
using FdkElevator.DTOS.ComplaintDTOS;
using FdkElevator.Models.Complaints;
using FdkElevator.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace FdkElevator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplaintController : ControllerBase
    {
        private readonly IBreakdownService _service;
        private readonly IMapper _mapper;

        public ComplaintController(IBreakdownService breakdownService, IMapper mapper)
        {
            _service = breakdownService;
            _mapper = mapper;
        }

        // ── ① Intake ─────────────────────────────────────
        [HttpPost("log-complaint")]
        public async Task<ActionResult<BreakdownComplaintSummaryDto>> LogComplaint(
            [FromBody] CreateComplaintDto dto)
        {
            try
            {
                var result = await _service.LogComplaintAsync(dto);
                return Ok(_mapper.Map<BreakdownComplaintSummaryDto>(result));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to log complaint.", detail = ex.Message });
            }
        }

        // ── ③ Priority & SLA ─────────────────────────────
        [HttpPut("{id:guid}/assign-priority")]
        public async Task<ActionResult<BreakdownComplaintSummaryDto>> AssignPriority(
            Guid id,
            [FromBody] UpdatePriorityRequest request)
        {
            try
            {
                var result = await _service.AssignPriorityAndSLAAsync(id, request.Priority);
                return Ok(_mapper.Map<BreakdownComplaintSummaryDto>(result));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to assign priority.", detail = ex.Message });
            }
        }

        // ── ④ Dispatch ───────────────────────────────────
        [HttpPost("{id:guid}/dispatch-technician")]
        public async Task<ActionResult<DispatchSummaryDto>> DispatchTechnician(
            Guid id,
            [FromBody] DispatchTechnicianDto dto)
        {
            try
            {
                var result = await _service.DispatchTechnicianAsync(id, dto);
                return Ok(_mapper.Map<DispatchSummaryDto>(result));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to dispatch technician.", detail = ex.Message });
            }
        }

        // ── ⑤ Diagnosis ──────────────────────────────────
        [HttpPost("{id:guid}/submit-diagnosis")]
        public async Task<ActionResult<DiagnosisSummaryDto>> SubmitDiagnosis(
            Guid id,
            [FromBody] SubmitDiagnosisDto dto)
        {
            try
            {
                var result = await _service.SubmitDiagnosisAsync(id, dto);
                return Ok(_mapper.Map<DiagnosisSummaryDto>(result));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to submit diagnosis.", detail = ex.Message });
            }
        }

        [HttpPost("diagnosis/{diagnosisId:guid}/add-media")]
        public async Task<ActionResult> AddDiagnosisMedia(
            Guid diagnosisId,
            [FromBody] List<string> mediaUrls)
        {
            try
            {
                if (mediaUrls == null || !mediaUrls.Any())
                    return BadRequest(new { message = "At least one media URL is required." });

                await _service.AddDiagnosisMediaAsync(diagnosisId, mediaUrls);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to add media.", detail = ex.Message });
            }
        }

        [HttpPost("diagnosis/{diagnosisId:guid}/add-spare-parts")]
        public async Task<ActionResult> AddSpareParts(
            Guid diagnosisId,
            [FromBody] List<SparePartDto> parts)
        {
            try
            {
                if (parts == null || !parts.Any())
                    return BadRequest(new { message = "At least one spare part is required." });

                await _service.AddSparePartsAsync(diagnosisId, parts);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to add spare parts.", detail = ex.Message });
            }
        }

        // ── ⑥ Quotation ──────────────────────────────────
        [HttpPost("{id:guid}/create-quotation")]
        public async Task<ActionResult<QuotationSummaryDto>> CreateQuotation(
            Guid id,
            [FromBody] CreateQuotationDto dto)
        {
            try
            {
                var result = await _service.CreateQuotationAsync(id, dto);
                return Ok(_mapper.Map<QuotationSummaryDto>(result));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to create quotation.", detail = ex.Message });
            }
        }

        [HttpPut("quotation/{quotationId:guid}/update-status")]
        public async Task<ActionResult<QuotationSummaryDto>> UpdateQuotationStatus(
            Guid quotationId,
            [FromBody] UpdateQuotationStatusRequest request)
        {
            try
            {
                var result = await _service.UpdateQuotationStatusAsync(quotationId, request.Status);
                return Ok(_mapper.Map<QuotationSummaryDto>(result));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to update quotation status.", detail = ex.Message });
            }
        }

        // ── ⑦ Repair ─────────────────────────────────────
        [HttpPut("{id:guid}/update-job-status")]
        public async Task<ActionResult> UpdateJobStatus(
            Guid id,
            [FromBody] UpdateJobStatusRequest request)
        {
            try
            {
                await _service.UpdateJobStatusAsync(id, request.Status);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to update job status.", detail = ex.Message });
            }
        }

        // ── ⑧ Closure ────────────────────────────────────
        [HttpPost("{id:guid}/close-job")]
        public async Task<ActionResult<ClosureSummaryDto>> CloseJob(
            Guid id,
            [FromBody] CloseJobDto dto)
        {
            try
            {
                var result = await _service.CloseJobAsync(id, dto);
                return Ok(_mapper.Map<ClosureSummaryDto>(result));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to close job.", detail = ex.Message });
            }
        }

        // ── ⑨ RCA ────────────────────────────────────────
        [HttpPost("{id:guid}/submit-rca")]
        public async Task<ActionResult<RCASummaryDto>> SubmitRCA(
            Guid id,
            [FromBody] SubmitRCADto dto)
        {
            try
            {
                var result = await _service.SubmitRCAAsync(id, dto);
                return Ok(_mapper.Map<RCASummaryDto>(result));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to submit RCA.", detail = ex.Message });
            }
        }

        // ── Queries ───────────────────────────────────────
        [HttpGet("{id:guid}/get-summary")]
        public async Task<ActionResult<BreakdownComplaintSummaryDto>> GetComplaintSummary(Guid id)
        {
            try
            {
                var result = await _service.GetComplaintSummaryAsync(id);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to get complaint summary.", detail = ex.Message });
            }
        }

        [HttpGet("project/{projectId:guid}/get-complaints")]
        public async Task<ActionResult<List<BreakdownComplaintSummaryDto>>> GetByProject(
            Guid projectId)
        {
            try
            {
                var result = await _service.GetComplaintsByProjectAsync(projectId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to get project complaints.", detail = ex.Message });
            }
        }

        [HttpGet("get-open-complaints")]
        public async Task<ActionResult<List<BreakdownComplaintSummaryDto>>> GetOpenComplaints()
        {
            try
            {
                var result = await _service.GetOpenComplaintsAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to get open complaints.", detail = ex.Message });
            }
        }

    //    // ── SLA Monitor ───────────────────────────────────
    //    [HttpPost("sla/run-monitor")]
    //    public async Task<ActionResult> MonitorSLA()
    //    {
    //        try
    //        {
    //            await _service.MonitorSLABreachesAsync();
    //            return NoContent();
    //        }
    //        catch (Exception ex)
    //        {
    //            return StatusCode(500, new { message = "SLA monitoring failed.", detail = ex.Message });
    //        }
    //    }
    }
}