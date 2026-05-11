using AutoMapper;
using FdkElevator.DTOS.LeadDTOS;
using FdkElevator.Models.Leads;
using FdkElevator.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FdkElevator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadController : ControllerBase
    {

        private readonly ILead _lead;
        private readonly IMapper _mapper;

        public LeadController(ILead lead, IMapper mapper)
        {
            _lead = lead;
            _mapper = mapper;
        }

        [HttpPost("addlead")]
        public ActionResult<string> addNewLeads(LeadDTO leadDTO)
        {
            try
            {
                var lead = _mapper.Map<Lead>(leadDTO);
                var result = _lead.AddLead(lead);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("getleads/{tenantId}")]
        public ActionResult<List<LeadResponseDTO>> getLeadsByTenantId(Guid tenantId)
        {
            try
            {
                var leads = _lead.GetLeads(tenantId);
                return Ok(leads);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("getlead/{leadId}")]
        public ActionResult<LeadResponseDTO> getLeadById(Guid leadId)
        {
            try
            {
                var lead = _lead.GetLeadById(leadId);
                if (lead == null)
                {
                    return NotFound("Lead not found");
                }
                return Ok(lead);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

        [HttpPut("updateleadstatus/{leadId}")]
        public ActionResult<string> updateLeadStatus(Guid leadId, Status newStatus)
        {
            try
            {
                var result = _lead.updateLeadStatus(leadId, newStatus);
                if (result == null)
                {
                    return NotFound("Lead not found");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

        [HttpPut("updatelead/{leadId}")]
        public ActionResult<string> updateLead(Guid leadId, LeadDTO uLead)
        {
            try
            {
                var lead = _lead.GetLeadById1(leadId);
                if (lead == null)
                {
                    return NotFound("Lead not found");
                }

                var updatedLead = _mapper.Map(uLead, lead);

                var result = _lead.UpdateLead(updatedLead);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpDelete("deletelead/{leadId}")]
        public ActionResult<string> deleteLead(Guid leadId)
        {
            try
            {
                var lead = _lead.GetLeadById1(leadId);
                if (lead == null)
                {
                    return NotFound("Lead not found");
                }

                var result = _lead.DeleteLead(lead);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("getnewleads/{TenantId}")]
        public ActionResult<List<LeadResponseDTO>> getAllNewLeads(Guid TenantId)
        {
            try
            {
                var leads = _lead.getAllNewLeads();
                return Ok(leads);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }
    }
}
