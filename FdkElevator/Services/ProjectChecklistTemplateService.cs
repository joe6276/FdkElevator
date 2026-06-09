using FdkElevator.AppDbContext;
using FdkElevator.Models.Projects;
using FdkElevator.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace FdkElevator.Services
{
    public class ProjectChecklistTemplateService : IProjectChecklistTemplate
    {

        private readonly ApplicationDbContext _db;

        public ProjectChecklistTemplateService(ApplicationDbContext context)
        {
            _db= context;
        }

        public async Task<IEnumerable<ChecklistTemplate>> GetAllAsync()
        {
            return await _db.ChecklistTemplates
                .Include(t => t.Items.OrderBy(i => i.ItemOrder))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ChecklistTemplate?> GetByIdAsync(Guid id)
        {
            return await _db.ChecklistTemplates
                .Include(t => t.Items.OrderBy(i => i.ItemOrder))
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<ChecklistTemplate>> GetByServiceTypeAsync(ProjectMaintenanceServiceType serviceType)
        {
            return await _db.ChecklistTemplates
                .Include(t => t.Items.OrderBy(i => i.ItemOrder))
                .Where(t => t.ServiceType == serviceType)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<ChecklistTemplate>> GetByAssetTypeAsync(ProjectMaintenanceAssetType assetType)
        {
            return await _db.ChecklistTemplates
                .Include(t => t.Items.OrderBy(i => i.ItemOrder))
                .Where(t => t.LiftAssetType == assetType)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ChecklistTemplate> CreateAsync(ChecklistTemplate template)
        {
            template.Id = Guid.NewGuid();

            _db.ChecklistTemplates.Add(template);
            await _db.SaveChangesAsync();
            return template;
        }

        public async Task<ChecklistTemplate?> UpdateAsync(Guid id, ChecklistTemplate template)
        {
            var existing = await _db.ChecklistTemplates.FindAsync(id);
            if (existing is null) return null;

            existing.TemplateCode = template.TemplateCode;
            existing.TemplateName = template.TemplateName;
            existing.ServiceType = template.ServiceType;
            existing.LiftAssetType = template.LiftAssetType;
            existing.FaultCategory = template.FaultCategory;
            existing.IsActive = template.IsActive;

            await _db.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var template = await _db.ChecklistTemplates.FindAsync(id);
            if (template is null) return false;

            _db.ChecklistTemplates.Remove(template);
            await _db.SaveChangesAsync();
            return true;
        }

        public Task<string> addCheckListTemplate(ChecklistTemplate checkListTemplate)
        {
            throw new NotImplementedException();
        }
    }
}
