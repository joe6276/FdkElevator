using FdkElevator.AppDbContext;
using FdkElevator.Models.Auth;
using FdkElevator.Models.Surveyors;
using FdkElevator.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace FdkElevator.Services
{
    public class SurveyService : ISurvey
    {
        private readonly ApplicationDbContext _context;
        private readonly IUser _user;
        private readonly IEmail _email;
        public SurveyService(ApplicationDbContext context, IUser user)
        {
            _context = context;
            _user = user;
        }

        public string addSurvey(AllSurvey survey)
        {
            _context.AllSurveys.Add(survey);
            _context.SaveChanges();
            return " Survey Added Successfully!";
        }

        public async Task<AllSurvey?> GetSurveyByIdAsync(Guid id)
        {
            return await _context.AllSurveys
                .Include(x => x.ProjectInfo)
                .Include(x => x.ShaftStructuralInfo)
                .Include(x => x.EntranceDoorDetails)
                .Include(x => x.PowerElectricalInfo)
                .Include(x => x.UsageTrafficInfo)
                .Include(x => x.FinishingDesignPreferences)
                .Include(x => x.SafetyComplianceInfo)
                .Include(x => x.MaintenanceServiceInfo)
                .Include(x => x.SiteMediaAttachments)
                .Include(x => x.AdditionalNotes)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<AllSurvey?> GetSurveyByLeadIdAsync(Guid leadId)
        {
            return await _context.AllSurveys
                .Where(x=>x.LeadId == leadId)
                .Include(x => x.ProjectInfo)
                .Include(x => x.ShaftStructuralInfo)
                .Include(x => x.EntranceDoorDetails)
                .Include(x => x.PowerElectricalInfo)
                .Include(x => x.UsageTrafficInfo)
                .Include(x => x.FinishingDesignPreferences)
                .Include(x => x.SafetyComplianceInfo)
                .Include(x => x.MaintenanceServiceInfo)
                .Include(x => x.SiteMediaAttachments)
                .Include(x => x.AdditionalNotes)
                .FirstOrDefaultAsync();
        }


        public async Task<List<AllSurvey>> GetSurveyorsListAsync(Guid surveyorId)
        {
            return await _context.AllSurveys
                .Where(x => x.SurveyorId == surveyorId)
                .Include(x => x.ProjectInfo)
                .Include(x => x.ShaftStructuralInfo)
                .Include(x => x.EntranceDoorDetails)
                .Include(x => x.PowerElectricalInfo)
                .Include(x => x.UsageTrafficInfo)
                .Include(x => x.FinishingDesignPreferences)
                .Include(x => x.SafetyComplianceInfo)
                .Include(x => x.MaintenanceServiceInfo)
                .Include(x => x.SiteMediaAttachments)
                .Include(x => x.AdditionalNotes)
                .ToListAsync();
        }

        public async Task<List<AllSurvey>> GetSurveysByTenantAsync(Guid tenantId)
        {
            return await _context.AllSurveys
                .Where(x => x.TenantId == tenantId)
                .Include(x => x.ProjectInfo)
                .Include(x => x.ShaftStructuralInfo)
                .Include(x => x.EntranceDoorDetails)
                .Include(x => x.PowerElectricalInfo)
                .Include(x => x.UsageTrafficInfo)
                .Include(x => x.FinishingDesignPreferences)
                .Include(x => x.SafetyComplianceInfo)
                .Include(x => x.MaintenanceServiceInfo)
                .Include(x => x.SiteMediaAttachments)
                .Include(x => x.AdditionalNotes)
                .ToListAsync();
        }

      

        public async Task<string> UpdateSurveyAsync(AllSurvey survey)
        {
            try
            {
                _context.AllSurveys.Update(survey);
                await _context.SaveChangesAsync();
                return "Survey updated successfully";
            }
            catch (Exception ex)
            {
                return $"Update failed: {ex.Message}";
            }
        }

        //public string addSurvey(Survey survey)
        //{
        //    _context.Surveys.Add(survey);
        //    _context.SaveChanges();
        //    return " Survey Added Successfully!";
        //}

        //public Survey GetSurveyById(Guid id)
        //{
        //    return _context.Surveys.Where(x => x.Id == id).FirstOrDefault();
        //}

        //public List<Survey> getSurveyList(Guid surveyorId)
        //{
        // return _context.Surveys.Where(x => x.SurveyorId == surveyorId).ToList();
        //}

        //public List<Survey> GetSurveys(Guid tenantId)
        //{
        //    return _context.Surveys.Where(x => x.TenantId == tenantId).ToList();
        //}

        //public async Task<string> update(Survey survey)
        //{
        //    try
        //    {
        //        var lead = _context.Leads.Where(x => x.Id == survey.LeadId).FirstOrDefault();

        //        var existingUser = _context.Users.Where(x => x.Email == lead.Email).FirstOrDefault();

        //        var client = new User()
        //        {
        //            Name = lead.CompanyName,
        //            Email = lead.Email,
        //            PhoneNumber = lead.PhoneNumber,
        //            Role = Role.Client,
        //            TenantId = survey.TenantId,

        //        };

        //        if (existingUser == null)
        //        {
        //            await _user.addUser(client);
        //        }

        //        _context.Surveys.Update(survey);
        //        _context.SaveChanges();
        //        return " Survey Added Successfully!";
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //}

        //public string updateSurvey(Survey survey)
        //{
        //    _context.Surveys.Update(survey);
        //    _context.SaveChanges();
        //    return " Survey updated Successfully!";
        //}
    }
}
