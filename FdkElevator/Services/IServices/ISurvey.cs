using FdkElevator.DTOS.SurveyDTOS;
using FdkElevator.Models.Surveyors;

namespace FdkElevator.Services.IServices
{
    public interface ISurvey
    {
        Task<string> addSurvey(AllSurvey survey);
        Task<List<SurveyListDto>> GetSurveyorsListAsync(Guid surveyorId);

        Task<AllSurvey?> GetSurveyByLeadIdAsync(Guid leadId);
        Task<List<SurveyListDto>> GetSurveysByTenantAsync(Guid tenantId);

        Task<AllSurvey?> GetSurveyByIdAsync(Guid id);

        Task<string> UpdateSurveyAsync(AllSurvey survey);




    }
}
