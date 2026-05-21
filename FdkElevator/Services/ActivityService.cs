using FdkElevator.AppDbContext;
using FdkElevator.DTOS.LeadDTOS;
using FdkElevator.Models.Leads;
using FdkElevator.Services.IServices;

namespace FdkElevator.Services
{
    public class ActivityService : IActivity
    {
        private readonly ApplicationDbContext _context;
        public ActivityService(ApplicationDbContext context)
        {
            _context = context;
        }

  

        public string addActivity(Activity activity)
        {
            _context.Activities.Add(activity);
            _context.SaveChanges();
            return "Activity added successfully!";
        }

        public List<ResponseActivityDTO> getActivitiesList(Guid leadId)
        {
           
                var activities = _context.Activities.Where(a => a.LeadId == leadId).Select(a => new ResponseActivityDTO
                {
                    LeadId = a.LeadId,
                    TenantId = a.TenantId,
                    Description = a.Description,
                    UserId = a.UserId,
                    Username = a.user.Name,
                    type = a.type,
                    Id = a.Id
                }).ToList();

                return activities;
            
        }

        public Activity getActivity(Guid id)
        {
            return _context.Activities.FirstOrDefault(a => a.Id == id);

        }


        public string update(Activity activity)
        {
           _context.Activities.Update(activity);
            _context.SaveChanges();
            return "Activity updated successfully!";
        }

       
    }
}
