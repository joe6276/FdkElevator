using AutoMapper;
using FdkElevator.Models.Quotations;
using FdkElevator.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FdkElevator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotationPaymentController : ControllerBase
    {

        private readonly IQuotationPayment _quotePayment;
        private readonly IMapper _mapper;

        public QuotationPaymentController(IQuotationPayment quotation, IMapper mapper)
        {
            _mapper = mapper;
            _quotePayment = quotation;
        }

        [HttpPost("MakePayment/{Id}")]
        public ActionResult<string> MakePayment(Guid Id)
        {
            try
            {
                var result = _quotePayment.MakePayment(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("validatePayment/{stripeSessionId}")]
        public ActionResult<string> validatePayment(string stripeSessionId)
        {
            try
            {
                var result = _quotePayment.validatePayment(stripeSessionId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("listPayments/{clientId}")]
        public ActionResult<List<QuotationPayment>> listPayments(Guid clientId)
        {
            try
            {
                var payments = _quotePayment.GetQuotations(clientId);
                var result = _mapper.Map<List<QuotationPayment>>(payments);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
