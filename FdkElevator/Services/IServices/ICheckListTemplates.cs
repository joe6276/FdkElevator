using FdkElevator.Models.Projects;

namespace FdkElevator.Services.IServices
{
    public interface ICheckListTemplates
    {
        string addCheckListTemplate(ChecklistTemplate checkListTemplate);
        List<ChecklistTemplate> GetCheckListTemplates(Guid tenantID);
        ChecklistTemplate GetCheckListTemplateById(Guid Id);
        string updateCheckListTemplate(ChecklistTemplate checkListTemplate);
    }
}
