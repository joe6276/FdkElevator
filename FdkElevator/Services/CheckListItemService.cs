using FdkElevator.AppDbContext;
using FdkElevator.Models.Projects;
using FdkElevator.Services.IServices;

namespace FdkElevator.Services
{
    public class CheckListItemService : IChecklistItemService
    {

        private readonly ApplicationDbContext _context;

        public CheckListItemService(ApplicationDbContext context)
        {
            _context = context;
        }
        public string CreateCheckList(ChecklistItem clI)
        {
            _context.ChecklistItems.Add(clI);
            _context.SaveChanges();
            return " Check List Item Added Successfully";
        }

        public bool deleteCheckListItem(ChecklistItem cli)
        {
            _context.ChecklistItems.Remove(cli);
            _context.SaveChanges();
            return true;
        }

        public ChecklistItem GetById(Guid Id)
        {
            return _context.ChecklistItems.FirstOrDefault(x => x.Id == Id);
        }

        public List<ChecklistItem> GetByTemplate(Guid templateId)
        {
            return _context.ChecklistItems.Where(x => x.ChecklistTemplateId == templateId).ToList();
        }

        public string updateCheckList(ChecklistItem cli)
        {
           _context.ChecklistItems.Update(cli);
            _context.SaveChanges();
            return "CheckList items Updated";
        }
    }
}
