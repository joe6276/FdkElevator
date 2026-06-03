using FdkElevator.AppDbContext;
using FdkElevator.Models.Projects;
using FdkElevator.Services.IServices;

namespace FdkElevator.Services
{
    public class ProjectPhraseService : IProjectPhase
    {   

        private readonly ApplicationDbContext _context;

        public ProjectPhraseService(ApplicationDbContext context)
        {
            _context=context;
        }
        public string GenerateTrackingNumber()
        {
            return $"PRJH-{Guid.NewGuid().ToString("N")[..8].ToUpper()}";
        }

        public string addProjectPhase(ProjectPhase projectPhase)
        {   
            projectPhase.PhaseCode = GenerateTrackingNumber();
            _context.ProjectPhases.Add(projectPhase);
            _context.SaveChanges();
            return "Project Phase added successfully";
        }

        public ProjectPhase getProjectPhase(Guid projectPhaseId)
        {
            return _context.ProjectPhases.FirstOrDefault(p => p.Id == projectPhaseId)!;
        }

        public List<ProjectPhase> getProjectPhasesByProjectId(Guid projectId)
        {
           return _context.ProjectPhases.Where(p => p.ProjectId == projectId).ToList();
        }

        public string markProjectPhaseAsCompleted(Guid projectPhaseId, string? notes)
        {
            var projectPhase = _context.ProjectPhases.FirstOrDefault(p => p.Id == projectPhaseId);
            if (projectPhase == null)
            {
                throw new Exception("Project Phase not found");
            }
            projectPhase.Status = PhaseStatus.Closed;
            projectPhase.notes = notes;

            _context.ProjectPhases.Update(projectPhase);
            _context.SaveChanges();
            return "Project Phase marked as completed";
        }

        public string updateProjectPhase(ProjectPhase projectPhase)
        {
           _context.ProjectPhases.Update(projectPhase);
            _context.SaveChanges();
            return "Project Phase updated successfully";
        }

        public string updateProjectPhaseStatus(Guid projectPhaseId, PhaseStatus status)
        {
            var projectPhase = _context.ProjectPhases.FirstOrDefault(p => p.Id == projectPhaseId);
            if (projectPhase == null)
            {
                throw new Exception("Project Phase not found");
            }
            projectPhase.Status = status;
            _context.ProjectPhases.Update(projectPhase);
            _context.SaveChanges();
            return "Project Phase status updated successfully";
        }
    }
}
