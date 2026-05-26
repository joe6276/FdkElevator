using FdkElevator.Models.Surveyors;

namespace FdkElevator.Services.IServices
{
    public interface ISurvey
    {
        string addSurvey(AllSurvey survey);

        Task<List<AllSurvey>> GetSurveyListAsync(Guid surveyorId);
 

        Task<List<AllSurvey>> GetSurveysByTenantAsync(Guid tenantId);

        Task<AllSurvey?> GetSurveyByIdAsync(Guid id);

        Task<string> UpdateSurveyAsync(AllSurvey survey);




    }
}
