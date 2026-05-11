using FdkElevator.AppDbContext;
using FdkElevator.Models.Leads;
using FdkElevator.Services.IServices;

namespace FdkElevator.Services
{
    public class LeadService : ILead
    {   

        private readonly ApplicationDbContext _context;

        public LeadService(ApplicationDbContext context)
        {
            _context = context;
        }
        public string AddLead(Lead lead)
        {
           _context.Leads.Add(lead);
            _context.SaveChanges();
            return "Lead added successfully!";
        }

        public string DeleteLead(Lead lead)
        {
           _context.Leads.Remove(lead);
            _context.SaveChanges();
            return "Lead deleted successfully!";
        }

        public Lead GetLeadById(Guid id)
        {
            return _context.Leads.FirstOrDefault(l => l.Id == id);
        }

        public List<Lead> GetLeads(Guid tenantId)
        {
          return  _context.Leads.Where(l => l.TenantId == tenantId).ToList();
        }

        public string UpdateLead(Lead lead)
        {
            _context.Leads.Update(lead);
            _context.SaveChanges();
            return "Lead updated successfully!";
        }

        public string updateLeadStatus(Guid leadId, Status status)
        {
           var lead = _context.Leads.FirstOrDefault(l => l.Id == leadId);
            if (lead == null)
            {
                throw new Exception( "Lead not found!");
            }
            lead.leadStatus = status;
            _context.Leads.Update(lead);
            _context.SaveChanges();
            return "Lead status updated successfully!";
        }
    }
}
