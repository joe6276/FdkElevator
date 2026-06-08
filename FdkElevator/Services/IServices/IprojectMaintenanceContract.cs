using FdkElevator.Models.Projects;
using static FdkElevator.DTOS.ProjectDTOS.ProjectMaintenanceResponses;

namespace FdkElevator.Services.IServices
{
    public interface IprojectMaintenanceContract
    {
        string addProjectContract(AMCContract aMC);

        List<AMCContract> GetAMCContracts(Guid tenantID);

        AMCContract GetAMCContractsByProject(Guid projectId);
        AMCContract getContractById(Guid Id);
        string updateContract(AMCContract aMC);

        string addContractAsset(AMCContractAsset amCAsset);
        AMCContractAsset getContractAssetById(Guid Id);

        string updateAMCContractAsset(AMCContractAsset aMCContract);

        string addWarrantyRecord(WarrantyRecord wr);

        WarrantyRecord GetWarrantyRecord(Guid Id);

        string updateWarrantyRecord(WarrantyRecord wrs);

   
        AMCContractDetailResponse? GetAMCContractDetailByClientId(Guid clientId);

        AMCContractDetailResponse? GetAMCContractDetailByProjectId(Guid projectId);
        AMCContractDetailResponse? GetAMCContractDetail(Guid id);
    }
}
