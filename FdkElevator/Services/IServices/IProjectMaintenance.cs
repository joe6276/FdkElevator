using FdkElevator.Models.Projects;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System.Globalization;
using static FdkElevator.DTOS.ProjectDTOS.ProjectMaintenanceDTO;
using static FdkElevator.DTOS.ProjectDTOS.ProjectMaintenanceResponses;

namespace FdkElevator.Services.IServices
{
    public interface IProjectMaintenance
    {
        string addLiftAsset(LiftAsset liftAsset);

        List<LiftAssetDetailResponse> GetLiftAssets();

        LiftAsset GetLiftAssetById(Guid id);
        string updateLiftAsset(LiftAsset liftAsset);

        AssetComponent getAssetComponentById(Guid Id);

        string updateAssetComponent(AssetComponent ac);


        string addNewComponent(AssetComponent aC);

        string deleteAssetComponent(AssetComponent ac);
    }
}
