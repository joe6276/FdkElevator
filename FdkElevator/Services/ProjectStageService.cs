using FdkElevator.AppDbContext;
using FdkElevator.Models.Projects;
using FdkElevator.Services.IServices;

namespace FdkElevator.Services
{
    public class ProjectStageService : IProjectStage
    {   
        private readonly ApplicationDbContext _context;
        public ProjectStageService(ApplicationDbContext context)
        {
            _context = context;
        }
        public string addProjectStage(ProjectStage projectStage)
        {
           _context.projectStages.Add(projectStage);
            _context.SaveChanges();
            return "Project Stage added successfully";
        }

        public List<ProjectStage> getProjectbasedOnUser(Guid userId)
        {
           
            return _context.projectStages.Where(p => p.UserId == userId).ToList();
        }

        public List<ProjectStage> getProjectStagesByProjectId(Guid phaseId)
        {
           return _context.projectStages.Where(p => p.PhaseId == phaseId).ToList();
        }
    }
}
