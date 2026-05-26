using AutoMapper;
using FdkElevator.DTOS.OrganizationDTOS;
using FdkElevator.Models.Organization;
using FdkElevator.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FdkElevator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {

        private readonly IOrganization _organization;
        private readonly IMapper _mapper;
        public OrganizationController(IOrganization organization, IMapper mapper)
        {
            _organization = organization;
            _mapper = mapper;
        }


        [HttpPost("addorg")]
        public ActionResult<string> addOrganization(OrganizationDTO newOrg)
        {
            try
            {

                var organization = _mapper.Map<Organization>(newOrg);
                var result = _organization.addOrganization(organization);
                return Ok(organization);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server Error {ex.Message}");
            }
        }

        [HttpPut("updateOrganization")]
        public ActionResult<string> updateOrganization(OrganizationDTO updatedOrganization)
        {
            try
            {
                var organization = _organization.GetOrganization();
                if (organization == null)
                {
                    return NotFound("Organization not found");
                }
                var organizationDTO = _mapper.Map(updatedOrganization, organization);

                var result = _organization.updateorganization(organizationDTO);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        public ActionResult<Organization> getOrganization()
        {
            try
            {
                var organization = _organization.GetOrganization();
                if (organization == null)
                {
                    return NotFound("Organization not found");
                }
                return Ok(organization);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

}
