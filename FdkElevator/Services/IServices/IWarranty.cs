using FdkElevator.Models.Warranty;

namespace FdkElevator.Services.IServices
{
    public interface IWarranty
    {
        string addWarranty(HandoverWarranty warranty);
        HandoverWarranty getWarrantyByProjectId(Guid projectId);
        string updateWarranty(HandoverWarranty warranty);
        HandoverWarranty getWarrantyById(Guid id);
    }
}
