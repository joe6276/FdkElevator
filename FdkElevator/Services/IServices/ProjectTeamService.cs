using FdkElevator.AppDbContext;
using FdkElevator.Models.Projects;

namespace FdkElevator.Services.IServices
{
    public class ProjectTeamService : IProjectTeam
    {

        private readonly ApplicationDbContext _context;

        public ProjectTeamService(ApplicationDbContext context)
        {
            _context= context;
        }
        public string addProjectTeam(List<ProjectTeam> projectTeam)
        {
           _context.projectTeams.AddRange(projectTeam);
            _context.SaveChanges();
            return "Project Team added successfully!";

        }
    }
}
