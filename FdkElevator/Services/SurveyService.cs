using FdkElevator.AppDbContext;
using FdkElevator.Models.Surveyors;
using FdkElevator.Services.IServices;

namespace FdkElevator.Services
{
    public class SurveyService : ISurvey
    {
        private readonly ApplicationDbContext _context;
        public SurveyService(ApplicationDbContext context)
        {
            _context = context;
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
