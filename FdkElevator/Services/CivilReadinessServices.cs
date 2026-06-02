using FdkElevator.AppDbContext;
using FdkElevator.Models.Civil;
using FdkElevator.Models.Projects;
using FdkElevator.Services.IServices;

namespace FdkElevator.Services
{
    public class CivilReadinessServices : ICivilReadiness
    {
        private readonly ApplicationDbContext _context;
        public CivilReadinessServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public string addCivilReadiness(CivilReadiness civilReadiness)
        {
           _context.CivilReadinesses.Add(civilReadiness);
            _context.SaveChanges();
            return "Civil Readiness added successfully";
        }

        public CivilReadiness getCivilReadinessById(Guid id)
        {
            return _context.CivilReadinesses.Where(cr => cr.Id == id).FirstOrDefault();
        }

        public CivilReadiness getCivilReadinessByProjectId(Guid projectId)
        {
           return _context.CivilReadinesses.Where(cr => cr.ProjectId == projectId).FirstOrDefault();
        }

        public string markCivicReadiness(Guid projectId)
        {
            var project= _context.projects.Where(p => p.Id == projectId).FirstOrDefault();
            project.IsCivicReady= true;
            _context.projects.Update(project);
            _context.SaveChanges();
            return "Civic Readiness marked successfully";
        }

        public string updateCivilReadiness(CivilReadiness civilReadiness)
        {
            _context.CivilReadinesses.Update(civilReadiness);
            _context.SaveChanges();
            return "Civil Readiness updated successfully";
        }
    }
}
