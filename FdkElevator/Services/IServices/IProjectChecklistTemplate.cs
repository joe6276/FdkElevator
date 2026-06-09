using FdkElevator.Models.Projects;
using static FdkElevator.DTOS.ProjectDTOS.ProjectMaintenanceResponses;

namespace FdkElevator.Services.IServices
{
    public interface IProjectChecklistTemplate
    {
        Task<string> addCheckListTemplate(ChecklistTemplate checkListTemplate);
        Task<IEnumerable<ChecklistTemplate>> GetAllAsync();
        Task<ChecklistTemplate?> GetByIdAsync(Guid id);
        Task<IEnumerable<ChecklistTemplate>> GetByServiceTypeAsync(ProjectMaintenanceServiceType serviceType);
        Task<IEnumerable<ChecklistTemplate>> GetByAssetTypeAsync(ProjectMaintenanceAssetType assetType);
        Task<ChecklistTemplate> CreateAsync(ChecklistTemplate template);
        Task<ChecklistTemplate?> UpdateAsync(Guid id, ChecklistTemplate template);
        Task<bool> DeleteAsync(Guid id);

    }
}
