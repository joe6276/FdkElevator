using FdkElevator.Models.Quotations;

namespace FdkElevator.Services.IServices
{
    public interface IQuotation
    {

        string addQuotation(Quotation quotation);

        List<Quotation> getAllQuotations(Guid tenantId);

        Quotation getQuotationByClientId(Guid id);

        Quotation getQuotationByLeadId(Guid LeadId);
    }
}
