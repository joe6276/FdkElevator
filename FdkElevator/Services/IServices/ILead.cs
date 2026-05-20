using FdkElevator.DTOS.LeadDTOS;
using FdkElevator.Models.Leads;

namespace FdkElevator.Services.IServices
{
    public interface ILead
    {

        public string AddLead(Lead lead);

        public LeadGroupedDictionaryDto GetLeads(Guid tenantId);

        public Lead GetLeadById1(Guid id);

        public LeadResponseDTO GetLeadById(Guid id);
        public string UpdateLead(Lead lead);

        public string DeleteLead(Lead lead);

        public string updateLeadStatus(Guid leadId, Status status);

        List<LeadResponseDTO> getAllNewLeads();
    }
}
