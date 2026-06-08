using FdkElevator.AppDbContext;
using FdkElevator.Models.Projects;
using FdkElevator.Services.IServices;
using Microsoft.EntityFrameworkCore;
using static FdkElevator.DTOS.ProjectDTOS.ProjectMaintenanceDTO;
using static FdkElevator.DTOS.ProjectDTOS.ProjectMaintenanceResponses;

namespace FdkElevator.Services
{
    public class ProjectMaintenanceService : IProjectMaintenance
    {
        private readonly ApplicationDbContext _context;
        public ProjectMaintenanceService(ApplicationDbContext context)
        {
            _context = context;
        }

        public string addLiftAsset(LiftAsset liftAsset)
        {
            _context.LiftAssets.Add(liftAsset);
            _context.SaveChanges();
            return "Lift Asset added successfully";
        }

        public List<LiftAssetDetailResponse> GetLiftAssets()
        {
            return _context.LiftAssets
                .Select(a => new LiftAssetDetailResponse
                {
                    Id = a.Id,
                    ClientId = a.ClientId,
                    ProjectId = a.ProjectId,
                    AssetCode = a.AssetCode,
                    LiftName = a.LiftName,
                    LiftAssetType = a.LiftAssetType,
                    Manufacturer = a.Manufacturer,
                    Model = a.Model,
                    SerialNumber = a.SerialNumber,
                    UnitNumber = a.UnitNumber,
                    DriveType = a.DriveType,
                    ControllerBrand = a.ControllerBrand,
                    ControllerModel = a.ControllerModel,
                    Stops = a.Stops,
                    CapacityKg = a.CapacityKg,
                    SpeedMps = a.SpeedMps,
                    InstalledDate = a.InstalledDate,
                    HandoverDate = a.HandoverDate,
                    CurrentStatus = a.CurrentStatus,
                    CreatedAt = a.CreatedAt,
                    UpdatedAt = a.UpdatedAt,

                    Components = a.Components.Select(c => new AssetComponentResponse
                    {
                        Id = c.Id,
                        LiftAssetId = c.LiftAssetId,
                        ComponentType = c.ComponentType,
                        ComponentName = c.ComponentName,
                        SerialNumber = c.SerialNumber,
                        SupplierId = c.SupplierId,
                        WarrantyStartDate = c.WarrantyStartDate,
                        WarrantyEndDate = c.WarrantyEndDate,
                        LastReplacementDate = c.LastReplacementDate,
                        ComponentStatus = c.ComponentStatus,
                        Notes = c.Notes,
                        CreatedAt = c.CreatedAt
                    }).ToList(),

                    StatusHistory = a.StatusHistory.Select(h => new AssetStatusHistoryResponse
                    {
                        Id = h.Id,
                        LiftAssetId = h.LiftAssetId,
                        JobId = h.JobId,
                        OldStatus = h.OldStatus,
                        NewStatus = h.NewStatus,
                        Reason = h.Reason,
                        ChangedAt = h.ChangedAt,
                        ChangedByUserId = h.ChangedByUserId
                    }).ToList()
                })
                .ToList();
        }
        public LiftAsset GetLiftAssetById(Guid id)
        {
           return _context.LiftAssets.FirstOrDefault(l => l.Id == id);
        }


        public string updateLiftAsset(LiftAsset liftAsset)
        {
           _context.LiftAssets.Update(liftAsset);
            _context.SaveChanges();
            return "Lift Asset updated successfully";
        }

        public AssetComponent getAssetComponentById(Guid Id)
        {
            return _context.AssetComponents.FirstOrDefault(x => x.Id == Id);
        }

        public string updateAssetComponent(AssetComponent ac)
        {
            _context.AssetComponents.Update(ac);
            _context.SaveChanges();
            return "Asset Component Updated!";
        }

        public string addNewComponent(AssetComponent aC)
        {
            _context.AssetComponents.Add(aC);
            _context.SaveChanges();
            return "New Component Added";
        }

        public string deleteAssetComponent(AssetComponent ac)
        {
            _context.AssetComponents.Remove(ac);
            _context.SaveChanges();
            return "Component deleted Successfully!";
        }
    }
}
