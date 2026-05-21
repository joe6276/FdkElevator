using FdkElevator.DTOS.LeadDTOS;
using FdkElevator.Models.Leads;

namespace FdkElevator.Services.IServices
{
    public interface IActivity
    {

        string addActivity(Activity activity);

        List<ResponseActivityDTO> getActivitiesList(Guid leadId);
        string update(Activity activity);

        Activity getActivity(Guid id);

    }   
}
