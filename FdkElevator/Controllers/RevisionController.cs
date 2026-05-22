using AutoMapper;
using FdkElevator.DTOS.QuotationDTOS;
using FdkElevator.Migrations;
using FdkElevator.Models.Quotations;
using FdkElevator.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FdkElevator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RevisionController : ControllerBase
    {

        private readonly IRevision _revision;
        private readonly IMapper _mapper;
        private readonly IQuotation _quotation;


        public RevisionController(IRevision revision, IMapper mapper, IQuotation quotation)
        {
            _revision= revision;
            _mapper = mapper;
            _quotation = quotation;
        }



        [HttpPost("addRevision")]
        public ActionResult<string> addRevision( Guid QuotationId,  RevisionDTO revisionDTO)
        {
            try
            {   

                var quotation = _quotation.GetQuotationById(QuotationId);
                if (quotation == null)
                {
                    return NotFound("Quotation not found");
                }

                var revision = _mapper.Map<Revision>(revisionDTO);
                revision.Amount = revisionDTO.Items.Sum(x => x.Quantity * x.Price);
                var discount = (revisionDTO.Discount / 100) * (revision.Amount);
                revision.SubTotal = revision.Amount - discount;
                revision.Discount = discount;


                revision.QuotationId = QuotationId;
                revision.LeadId = quotation.LeadId;
                revision.ClientId = quotation.ClientId;
                var quotationPayments = new List<QuotationPayment>();
                foreach (var item in revisionDTO.quotationPayments)
                {
                    var payment = new QuotationPayment
                    {
                        Amount = item.Amount,
                        ClientId = quotation.ClientId,
                        DueDate = item.DueDate
                    };

                    quotationPayments.Add(payment);

                }

                var config = _mapper.Map<LiftConfigurationRevision>(revisionDTO.AddLiftConfiguration);
                revision.configuration = config;
                var result = _revision.addRevision(revision);
                _quotation.updateRevisedQuote(QuotationId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("listQuotations/{tenantId}")]
        public ActionResult<List<RevisionResponseDTO>> listQuotations(Guid tenantId)
        {
            try
            {
                var quatations = _revision.getAllRevisions(tenantId);
                return Ok(quatations);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getLeadQuotations/{leadId}")]

        public ActionResult<List<QuotationResponseDTO>> getLeadRevisions(Guid leadId)
        {
            try
            {
                var result = _revision.getRevisionByLeadId(leadId);
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
                var result = _revision.getRevisionByClientId(clientId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
     
    }
}
