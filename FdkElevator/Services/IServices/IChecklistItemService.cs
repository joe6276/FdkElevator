using FdkElevator.Models.Projects;

namespace FdkElevator.Services.IServices
{
    public interface IChecklistItemService
    {

        List<ChecklistItem> GetByTemplate(Guid templateId);

        ChecklistItem GetById(Guid Id);

        string CreateCheckList(ChecklistItem clI);

        string updateCheckList(ChecklistItem cli);

        bool deleteCheckListItem(ChecklistItem cli);
    }
}
