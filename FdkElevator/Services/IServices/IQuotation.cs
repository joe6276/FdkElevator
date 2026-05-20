using FdkElevator.DTOS.QuotationDTOS;
using FdkElevator.Models.Quotations;

namespace FdkElevator.Services.IServices
{
    public interface IQuotation
    {

        string addQuotation(Quotation quotation);

        List<QuotationResponseDTO> getAllQuotations(Guid tenantId);

        List<QuotationResponseDTO> getQuotationByClientId(Guid id);

        QuotationResponseDTO getQuotationByLeadId(Guid LeadId);

        QuotationResponseDTO getQuotationById(Guid id);
    }
}
