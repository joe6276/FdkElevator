using FdkElevator.AppDbContext;
using FdkElevator.DTOS.LeadDTOS;
using FdkElevator.Models.Leads;
using FdkElevator.Models.Tenants;
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

        public List<LeadResponseDTO> getAllNewLeads()
        {
            return _context.Leads.Where(l => l.leadStatus == Status.New).Select(l => new LeadResponseDTO()
            {
                Id = l.Id,
                TenantId = l.TenantId,
                clientCategory = l.clientCategory,
                CompanyName = l.CompanyName,
                ContactPerson = l.ContactPerson,
                Email = l.Email,
                leadStatus = l.leadStatus,
                PhoneNumber = l.PhoneNumber,
                Latitude = l.Latitude,
                Longitude = l.Longitude,
                Building_Address = l.Building_Address,
                NumberofElevators = l.NumberofElevators,
                NumberofFloors = l.NumberofFloors,
                SalesPersonId = l.SalesPersonId,
                leadType = l.leadType,
                source = l.source,
                urgency = l.urgency,
                budget = l.budget,
                decisionMaker = l.decisionMaker,
                survey = l.survey == null ? null : new SurveyResposeDTO()
                {
                    Id = l.survey.Id,
                    LeadId = l.survey.LeadId,
                    SurveyorId = l.survey.SurveyorId,
                    numberofStops = (int)l.survey.numberofStops,
                    PitDepth =(int) l.survey.PitDepth,
                    ShaftDepth = (int) l.survey.ShaftDepth,
                    ShaftAvailable = (bool) l.survey.ShaftAvailable,
                    ShaftWidth = (int) l.survey.ShaftWidth,
                    OverheadClearance = (int) l.survey.OverheadClearance,
                    PowerSupply = (string)l.survey.PowerSupply,
                    CivicReady = (bool)l.survey.CivicReady,
                    MachineRoom = (bool)l.survey.MachineRoom,
                    MLROption = (bool)l.survey.MLROption,
                    CivicWorkRequired = l.survey.CivicWorkRequired,
                    AccessRoute = l.survey.AccessRoute,
                    SafetyRisk = l.survey.SafetyRisk,
                    StorageArea = l.survey.StorageArea,
                    EngineerNotes = l.survey.EngineerNotes,
                    RecommendedLift = l.survey.RecommendedLift,
                }
            }).ToList();

        }

        public LeadResponseDTO GetLeadById(Guid id)
        {
         

            return _context.Leads.Where(l => l.Id == id).Select(l => new LeadResponseDTO()
            {
                Id = l.Id,
                TenantId = l.TenantId,
                clientCategory = l.clientCategory,
                CompanyName = l.CompanyName,
                ContactPerson = l.ContactPerson,
                Email = l.Email,
                leadStatus= l.leadStatus,
                PhoneNumber = l.PhoneNumber,
                Latitude = l.Latitude,
                Longitude = l.Longitude,
                Building_Address = l.Building_Address,
                NumberofElevators = l.NumberofElevators,
                NumberofFloors = l.NumberofFloors,
                SalesPersonId = l.SalesPersonId,
                leadType = l.leadType,
                source = l.source,
                urgency = l.urgency,
                budget = l.budget,
                decisionMaker = l.decisionMaker,
                survey = l.survey == null ? null :new SurveyResposeDTO()
                {
                    Id = l.survey.Id,
                    LeadId = l.survey.LeadId,
                    SurveyorId = l.survey.SurveyorId,
                    numberofStops = (int)l.survey.numberofStops,
                    PitDepth = (int)l.survey.PitDepth,
                    ShaftDepth = (int)l.survey.ShaftDepth,
                    ShaftAvailable = (bool)l.survey.ShaftAvailable,
                    ShaftWidth = (int)l.survey.ShaftWidth,
                    OverheadClearance = (int)l.survey.OverheadClearance,
                    PowerSupply = (string)l.survey.PowerSupply,
                    CivicReady = (bool)l.survey.CivicReady,
                    MachineRoom = (bool)l.survey.MachineRoom,
                    MLROption = (bool)l.survey.MLROption,
                    CivicWorkRequired = l.survey.CivicWorkRequired,
                    AccessRoute = l.survey.AccessRoute,
                    SafetyRisk = l.survey.SafetyRisk,
                    StorageArea = l.survey.StorageArea,
                    EngineerNotes = l.survey.EngineerNotes,
                    RecommendedLift = l.survey.RecommendedLift,
                }
            }).FirstOrDefault();

        }

        public Lead GetLeadById1(Guid id)
        {
           return _context.Leads.FirstOrDefault(l => l.Id == id);
        }

        public LeadGroupedDictionaryDto GetLeads(Guid tenantId)
        {
            var data = _context.Leads
         .Where(l => l.TenantId == tenantId)
         .GroupBy(l => l.leadStatus)
         .ToDictionary(
             g => ((int)g.Key).ToString(),
             g => g.Select(l => new LeadResDTO
             {
                 Id = l.Id,
                 TenantId = l.TenantId,
                 clientCategory = l.clientCategory,
                 CompanyName = l.CompanyName,
                 ContactPerson = l.ContactPerson,
                 leadStatus=l.leadStatus,
                 Email = l.Email,
                 PhoneNumber = l.PhoneNumber,
                 Latitude = l.Latitude,
                 Longitude = l.Longitude,
                 Building_Address = l.Building_Address,
                 NumberofFloors = l.NumberofFloors,
                 NumberofElevators = l.NumberofElevators,
                 SalesPersonId = l.SalesPersonId,
                 leadType = l.leadType,
                 source = l.source,
                 urgency = l.urgency,
                 budget = l.budget,
                 decisionMaker = l.decisionMaker,
             }).ToList()
         );

            return (new LeadGroupedDictionaryDto
            {
                Data = data
            });
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
