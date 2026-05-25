using FdkElevator.AppDbContext;
using FdkElevator.Models.Projects;
using FdkElevator.Services.IServices;

namespace FdkElevator.Services
{
    public class ProjectTeamService : IProjectTeam
    {

        private readonly ApplicationDbContext _context;
        private readonly IEmail _email;
        public ProjectTeamService(ApplicationDbContext context, IEmail email)
        {
            _context = context;
            _email= email;
        }
        public async Task<string>  addProjectTeam(List<ProjectTeam> projectTeam)
        {   

            var project= _context.projects.Where(x => x.Id == projectTeam[0].ProjectId).FirstOrDefault();

            var client = _context.Users.Where(x => x.Id == projectTeam[0].UserId).FirstOrDefault();

            if(project != null && client != null)
            {

                await _email.projectEmail(client.Name, project.ProjectCode, client.Email, project.CreatedAt.ToShortDateString());
               
            }

            _context.projectTeams.AddRange(projectTeam);
            _context.SaveChanges();
            return "Project Team added successfully!";

        }
    }
}
