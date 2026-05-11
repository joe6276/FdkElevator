using FdkElevator.Models.Surveyors;

namespace FdkElevator.Services.IServices
{
    public interface ISurvey
    {

        Task<string> addSurvey(Survey survey);

        List<Survey> GetSurveys(Guid tenantId);

        Survey GetSurveyById(Guid id);

        string updateSurvey(Survey survey);
    }
}
