using AutoMapper;
using FdkElevator.DTOS.CommissionDTO;
using FdkElevator.Models.Commissions;
using FdkElevator.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FdkElevator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommisionController : ControllerBase
    {

        private readonly ICommission _commission;
        private readonly IMapper _mapper;

        public CommisionController(IMapper mapper, ICommission commission)
        {
            _mapper = mapper;
            _commission = commission;

        }

        [HttpPost]
        public ActionResult<string> addCommission(CreateCommissionRequest ccR)
        {
            try
            {
                var commission = _mapper.Map<Commission>(ccR);
                //commission.generatedDocumentsCertificate = _mapper.Map<GeneratedDocumentsCertificate>(ccR.GeneratedDocuments);
                var result = _commission.addCommissioning(commission);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{projectId}")]
        public async Task<ActionResult<CommissionResponse>> getCommissionByProjectId(Guid projectId)
        {
            try
            {
                var commission = await _commission.getCommissionsByProjectId(projectId);
                return Ok(commission);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
