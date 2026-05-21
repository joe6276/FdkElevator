using FdkElevator.AppDbContext;
using FdkElevator.Models.Auth;
using FdkElevator.Models.Surveyors;
using FdkElevator.Services.IServices;
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

        public string addSurvey(Survey survey)
        {
            _context.Surveys.Add(survey);
            _context.SaveChanges();
            return " Survey Added Successfully!";
        }

        public Survey GetSurveyById(Guid id)
        {
            return _context.Surveys.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Survey> getSurveyList(Guid surveyorId)
        {
         return _context.Surveys.Where(x => x.SurveyorId == surveyorId).ToList();
        }

        public List<Survey> GetSurveys(Guid tenantId)
        {
            return _context.Surveys.Where(x => x.TenantId == tenantId).ToList();
        }

        public async Task<string> update(Survey survey)
        {
            try
            {
                var lead = _context.Leads.Where(x => x.Id == survey.LeadId).FirstOrDefault();

                var existingUser = _context.Users.Where(x => x.Email == lead.Email).FirstOrDefault();

                var client = new User()
                {
                    Name = lead.CompanyName,
                    Email = lead.Email,
                    PhoneNumber = lead.PhoneNumber,
                    Role = Role.Client,
                    TenantId = survey.TenantId,

                };

                if (existingUser == null)
                {
                    await _user.addUser(client);
                }

                _context.Surveys.Update(survey);
                _context.SaveChanges();
                return " Survey Added Successfully!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string updateSurvey(Survey survey)
        {
            _context.Surveys.Update(survey);
            _context.SaveChanges();
            return " Survey updated Successfully!";
        }
    }
}
