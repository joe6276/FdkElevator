using FdkElevator.DTOS.QuotationDTOS;
using FdkElevator.Models.Quotations;

namespace FdkElevator.Services.IServices
{
    public interface IRevision
    {

        string addRevision(Revision revision);

        List<RevisionResponseDTO> getAllRevisions(Guid tenantId);

        List<RevisionResponseDTO> getRevisionByClientId(Guid id);

        RevisionResponseDTO getRevisionByLeadId(Guid LeadId);

        RevisionResponseDTO getRevisionById(Guid id);


    }
}
