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

        public string GeneratePassword(int length = 8)
        {
            const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnpqrstuvwxyz23456789!@#$";
            var rng = RandomNumberGenerator.Create();
            return new string(Enumerable.Range(0, length)
                .Select(_ => { var b = new byte[1]; rng.GetBytes(b); return chars[b[0] % chars.Length]; })
                .ToArray());
        }
        public async Task<string> addSurvey(Survey survey)
        {

            var lead = _context.Leads.Where(x => x.Id == survey.LeadId).FirstOrDefault();

            var password = GeneratePassword();

            var client = new User()
            {
                Name = lead.CompanyName,
                Email = lead.Email,
                PhoneNumber = lead.PhoneNumber,
                Role = Role.Client,
                TenantId = survey.TenantId,
                Password = BCrypt.Net.BCrypt.HashPassword(password)
            };

            await _user.addUser(client);
            _context.Surveys.Add(survey);
            _context.SaveChanges();

            await _email.welcomeEmail(client.Name, client.Email, password);


            return " Survey Added Successfully!";
        }

        public Survey GetSurveyById(Guid id)
        {
            return _context.Surveys.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Survey> GetSurveys(Guid tenantId)
        {
            return _context.Surveys.Where(x => x.TenantId == tenantId).ToList();
        }

        public string updateSurvey(Survey survey)
        {
            _context.Surveys.Update(survey);
            _context.SaveChanges();
            return " Survey updated Successfully!";
        }
    }
}
