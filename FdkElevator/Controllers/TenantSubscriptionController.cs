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
    public class TenantSubscriptionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITenantSub _sub;

        public TenantSubscriptionController(IMapper mapper, ITenantSub Subscription)
        {
            _mapper = mapper;
            _sub = Subscription;
        }

        [HttpPost("paysubscription")]
        public ActionResult<PaymentResponseDTO> PaySub(TenantSubDTO newTenant)
        {
            try
            {

                var subscription = _mapper.Map<TenantSub>(newTenant);

                var result = _sub.addTenant(subscription);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("validatepayment")]
        public ActionResult<bool> validatepayment(string stripeSessionId)
        {
            try
            {
                var result = _sub.ValidatePayment(stripeSessionId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
