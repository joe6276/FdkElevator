using FdkElevator.AppDbContext;
using FdkElevator.Models.Warranty;
using FdkElevator.Services.IServices;

namespace FdkElevator.Services
{
    public class WarrantyService : IWarranty
    {
        private readonly ApplicationDbContext _context;
        public WarrantyService(ApplicationDbContext context)
        {
            _context=context;
        }
        public string addWarranty(HandoverWarranty warranty)
        {
            _context.Warranties.Add(warranty);
            _context.SaveChanges();
            return "Warranty added successfully";
        }

        public HandoverWarranty getWarrantyById(Guid id)
        {
            return _context.Warranties.Where(w => w.Id == id).FirstOrDefault();
        }

        public HandoverWarranty getWarrantyByProjectId(Guid projectId)
        {
            return _context.Warranties.Where(w => w.ProjectId == projectId).FirstOrDefault();
        }

        public string updateWarranty(HandoverWarranty warranty)
        {
            _context.Warranties.Update(warranty);
            _context.SaveChanges();
            return "Warranty updated successfully";
        }
    }
}
