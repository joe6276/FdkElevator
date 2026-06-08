using FdkElevator.AppDbContext;
using FdkElevator.Models.Projects;
using FdkElevator.Services.IServices;
using static FdkElevator.DTOS.ProjectDTOS.ProjectMaintenanceResponses;

namespace FdkElevator.Services
{
    public class ProjectMaintenanceContract : IprojectMaintenanceContract
    {
        private readonly ApplicationDbContext _context;

        public ProjectMaintenanceContract(ApplicationDbContext context)
       {
            _context = context;
        }

        public string addContractAsset(AMCContractAsset amCAsset)
        {
            _context.AMCContractAssets.Add(amCAsset);
            _context.SaveChanges();
            return "AMCContract Asset added Successfully!";
        }

        public string addProjectContract(AMCContract aMC)
        {
            _context.AMCContracts.Add(aMC);
            _context.SaveChanges();
            return "Contract added successfully!";
        }

        public string addWarrantyRecord(WarrantyRecord wr)
        {
            _context.WarrantyRecords.Add(wr);
            _context.SaveChanges();
            return "Warranty Record Added!";
        }

        public List<AMCContract> GetAMCContracts(Guid tenantID)
        {
            var projects = _context.projects.Where(x => x.TenantId == tenantID).Select(x=>x.Id).ToList();

            var listofContact = new List<AMCContract>();
            foreach( var proj in projects)
            {
                var amcContract = _context.AMCContracts.Where(x => x.ProjectId == proj).FirstOrDefault();
                listofContact.Add(amcContract);
            }
            return listofContact;
        }

        public AMCContract GetAMCContractsByProject(Guid projectId)
        {
            return _context.AMCContracts.Where(x => x.ProjectId == projectId).FirstOrDefault();
        }

        public AMCContractAsset getContractAssetById(Guid Id)
        {
            return _context.AMCContractAssets.FirstOrDefault(x => x.Id == Id);
        }

        public AMCContract getContractById(Guid Id)
        {
            return _context.AMCContracts.Where(x => x.Id == Id).FirstOrDefault();
        }

        public WarrantyRecord GetWarrantyRecord(Guid Id)
        {
            return _context.WarrantyRecords.FirstOrDefault(x => x.Id == Id);
        }

        public string updateAMCContractAsset(AMCContractAsset aMCContract)
        {
            _context.AMCContractAssets.Update(aMCContract);
            _context.SaveChanges();
            return "AMCContract Asset Updated!";
        }

        public string updateContract(AMCContract aMC)
        {
            _context.AMCContracts.Update(aMC);
            _context.SaveChanges();
            return "Contract Updated Successfully";
        }

        public string updateWarrantyRecord(WarrantyRecord wrs)
        {
            _context.WarrantyRecords.Update(wrs);
            _context.SaveChanges();
            return " Warranty Record Updated Successfully!";
        }

        public AMCContractDetailResponse? GetAMCContractDetailByProjectId( Guid projectId)
        {
            return _context.AMCContracts
                .Where(c=>c.ProjectId == projectId )
                .Select(c => new AMCContractDetailResponse
                {
                    Id = c.Id,
                    ClientId = c.ClientId,
                    ProjectId = c.ProjectId,
                    ContractCode = c.ContractCode,
                    ContractType = c.ContractType,
                    StartDate = c.StartDate,
                    EndDate = c.EndDate,
                    ServiceFrequency = c.ServiceFrequency,
                    SLAPolicy = c.SLAPolicy,
                    BillingCycle = c.BillingCycle,
                    ContractValue = c.ContractValue,
                    CurrencyCode = c.CurrencyCode,
                    Inclusions = c.Inclusions,
                    Exclusions = c.Exclusions,
                    ContractStatus = c.ContractStatus,
                    CreatedAt = c.CreatedAt,

                    ContractAssets = c.ContractAssets
                        .Select(a => new AMCContractAssetResponse
                        {
                            Id = a.Id,
                            LiftAssetId = a.LiftAssetId,
                            AssetCode = a.LiftAsset.AssetCode,
                            LiftName = a.LiftAsset.LiftName,
                            CoverageStartDate = a.CoverageStartDate,
                            CoverageEndDate = a.CoverageEndDate,
                            IsActive = a.IsActive
                        })
                        .ToList()
                })
                .FirstOrDefault();
        }

        public AMCContractDetailResponse? GetAMCContractDetailByClientId(Guid clientId)
        {
            return _context.AMCContracts
                .Where(c => c.ClientId == clientId)
                .Select(c => new AMCContractDetailResponse
                {
                    Id = c.Id,
                    ClientId = c.ClientId,
                    ProjectId = c.ProjectId,
                    ContractCode = c.ContractCode,
                    ContractType = c.ContractType,
                    StartDate = c.StartDate,
                    EndDate = c.EndDate,
                    ServiceFrequency = c.ServiceFrequency,
                    SLAPolicy = c.SLAPolicy,
                    BillingCycle = c.BillingCycle,
                    ContractValue = c.ContractValue,
                    CurrencyCode = c.CurrencyCode,
                    Inclusions = c.Inclusions,
                    Exclusions = c.Exclusions,
                    ContractStatus = c.ContractStatus,
                    CreatedAt = c.CreatedAt,

                    ContractAssets = c.ContractAssets
                        .Select(a => new AMCContractAssetResponse
                        {
                            Id = a.Id,
                            LiftAssetId = a.LiftAssetId,
                            AssetCode = a.LiftAsset.AssetCode,
                            LiftName = a.LiftAsset.LiftName,
                            CoverageStartDate = a.CoverageStartDate,
                            CoverageEndDate = a.CoverageEndDate,
                            IsActive = a.IsActive
                        })
                        .ToList()
                })
                .FirstOrDefault();
        }
        public AMCContractDetailResponse? GetAMCContractDetail(Guid id)
        {
            return _context.AMCContracts
                .Where(c => c.Id == id)
                .Select(c => new AMCContractDetailResponse
                {
                    Id = c.Id,
                    ClientId = c.ClientId,
                    ProjectId = c.ProjectId,
                    ContractCode = c.ContractCode,
                    ContractType = c.ContractType,
                    StartDate = c.StartDate,
                    EndDate = c.EndDate,
                    ServiceFrequency = c.ServiceFrequency,
                    SLAPolicy = c.SLAPolicy,
                    BillingCycle = c.BillingCycle,
                    ContractValue = c.ContractValue,
                    CurrencyCode = c.CurrencyCode,
                    Inclusions = c.Inclusions,
                    Exclusions = c.Exclusions,
                    ContractStatus = c.ContractStatus,
                    CreatedAt = c.CreatedAt,

                    ContractAssets = c.ContractAssets
                        .Select(a => new AMCContractAssetResponse
                        {
                            Id = a.Id,
                            LiftAssetId = a.LiftAssetId,
                            AssetCode = a.LiftAsset.AssetCode,
                            LiftName = a.LiftAsset.LiftName,
                            CoverageStartDate = a.CoverageStartDate,
                            CoverageEndDate = a.CoverageEndDate,
                            IsActive = a.IsActive
                        })
                        .ToList()
                })
                .FirstOrDefault();
        }

     
    }
}
