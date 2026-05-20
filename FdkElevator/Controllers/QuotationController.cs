using AutoMapper;
using FdkElevator.DTOS.QuotationDTOS;
using FdkElevator.Models.Quotations;
using FdkElevator.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FdkElevator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotationController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IQuotation _quotation;


        public QuotationController(IMapper mapper, IQuotation quotation)
        {
            _mapper = mapper;
            _quotation = quotation;
        }


        [HttpPost("addQuotation")]
        public ActionResult<string> addQuotation(QuotationDTO quotationDTO)
        {
            try
            {
                var quotation = _mapper.Map<Quotation>(quotationDTO);
                quotation.Amount = quotationDTO.Items.Sum(x => x.Quantity * x.Price);
                var discount =( quotationDTO.Discount/ 100) * (quotation.Amount);
                quotation.SubTotal = quotation.Amount - discount;
                quotation.Discount=discount;

                var result = _quotation.addQuotation(quotation);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("listQuotations/{tenantId}")]
        public ActionResult<List<QuotationResponseDTO>> listQuotations(Guid tenantId)
        {
            try
            {
                var quatations = _quotation.getAllQuotations(tenantId);
                return Ok(quatations);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getLeadQuotations/{leadId}")]

        public ActionResult<List<QuotationResponseDTO>> getLeadQuotations(Guid leadId)
        {
            try
            {
                var result = _quotation.getQuotationByLeadId(leadId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("getClientQuotation/{clientId}")]
        public ActionResult<List<QuotationResponseDTO>> getlQuotations(Guid clientId)
        {
            try
            {
                var result = _quotation.getQuotationByClientId(clientId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
