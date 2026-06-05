using FdkElevator.DTOS.CommissionDTO;
using FdkElevator.Models.Commissions;

namespace FdkElevator.Services.IServices
{
    public interface ICommission
    {
        string addCommissioning(Commission commission);

        Task<CommissionResponse> getCommissionsByProjectId(Guid projectId);

        Task<CommissionResponse> getCommissionsById(Guid commissionId);
    }
}
