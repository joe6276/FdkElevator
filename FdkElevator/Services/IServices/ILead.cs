using FdkElevator.Models.Leads;

namespace FdkElevator.Services.IServices
{
    public interface ILead
    {

        public string AddLead(Lead lead);

        public List<Lead> GetLeads(Guid tenantId);

        public Lead GetLeadById(Guid id);

        public string UpdateLead(Lead lead);

        public string DeleteLead(Lead lead);

        public string updateLeadStatus(Guid leadId, Status status);

        List<Lead> getAllNewLeads();
    }
}
