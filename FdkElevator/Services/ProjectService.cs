using FdkElevator.AppDbContext;
using FdkElevator.DTOS.ProjectDTOS;
using FdkElevator.Models.Projects;
using FdkElevator.Services.IServices;

namespace FdkElevator.Services
{
    public class ProjectService : IProject
    {
        private readonly ApplicationDbContext _context;
        public ProjectService(ApplicationDbContext context)
        {
            _context = context;
        }
        public string addProject(Project project)
        {
           _context.projects.Add(project);
            _context.SaveChanges();
            return "Project added successfully!";
        }

        public List<Project> getAllProjects(Guid tenantId)
        {
          return   _context.projects.Where(x => x.TenantId == tenantId).ToList();
        }

        public List<ProjectResponseDTO> getProjectByClientId(Guid id)
        {
            var projectDTO = _context.projects
       .Where(x => x.ClientId == id)
       .Select(x => new ProjectResponseDTO
       {
           ProjectCode = x.ProjectCode,
           ClientId = x.ClientId,
           CreatedAt = x.CreatedAt,

           ClientDetails = new ClientDetailsDTO
           {
               Name = x.user.Name,
               Email = x.user.Email,
               PhoneNumber = x.user.PhoneNumber
           },

           Tasks = x.Tasks.Select(t => new ProjectResponseTasksDTO
           {
               Title = t.Title,
               Description = t.Description,
               Status = t.Status,
               Notes = t.Notes,
               ImageURL = t.ImageURL,
               DueDate = t.DueDate
           }).ToList(),

           Team = x.Teams.Select(t => new ProjectResponseTeamDTO
           {
               Name = t.user.Name,
               Email = t.user.Email,
               PhoneNumber = t.user.PhoneNumber,
               Role = t.user.Role 
           }).ToList()

       }).ToList();

            return projectDTO;
        }

        public ProjectResponseDTO getProjectById(Guid id)
        {
            var projectDTO = _context.projects
      .Where(x => x.Id == id)
      .Select(x => new ProjectResponseDTO
      {
          ProjectCode = x.ProjectCode,
          ClientId = x.ClientId,
          CreatedAt = x.CreatedAt,

          ClientDetails = new ClientDetailsDTO
          {
              Name = x.user.Name,
              Email = x.user.Email,
              PhoneNumber = x.user.PhoneNumber
          },

          Tasks = x.Tasks.Select(t => new ProjectResponseTasksDTO
          {
              Title = t.Title,
              Description = t.Description,
              Status = t.Status,
              Notes = t.Notes,
              ImageURL = t.ImageURL,
              DueDate = t.DueDate
          }).ToList(),

          Team = x.Teams.Select(t => new ProjectResponseTeamDTO
          {
              Name = t.user.Name,
              Email = t.user.Email,
              PhoneNumber = t.user.PhoneNumber,
              Role = t.user.Role
          }).ToList()

      }).FirstOrDefault();

            return projectDTO;
        }

        public Project getProjectByProjId(Guid id)
        {
           return _context.projects.FirstOrDefault(x => x.Id == id);
        }

        public string updateProjectStatus(Guid id, ProjectStatus status)
        {
            var project = _context.projects.FirstOrDefault(x => x.Id == id);
            if (project == null)
            {
                throw new Exception("Project not found!");
            }

            project.ProjectStatus = status;
            _context.projects.Update(project);
            _context.SaveChanges();

            return "Project status updated successfully!";
        }
    }
}
