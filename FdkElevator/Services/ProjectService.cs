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
        public string GenerateProjectCode()
        {
            return $"PRJ-{Guid.NewGuid().ToString("N")[..8].ToUpper()}";
        }
        public string addProject(Project project)
        {
           
            project.ProjectCode = GenerateProjectCode();
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
           ProjectId= x.Id,
           ClientDetails = new ClientDetailsDTO
           {
               Name = x.user.Name,
               Email = x.user.Email,
               PhoneNumber = x.user.PhoneNumber
           },

           Phases = x.ProjectPhases.Select(t => new ProjectResponseTasksDTO
           {
             PhaseCode = t.PhaseCode,
               PhaseName = t.PhaseName,
               Status = t.Status,
               PlannedEndDate = t.PlannedEndDate,
               PlannedStartedDate = t.PlannedStartedDate
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
          ProjectId=x.Id,
          ClientDetails = new ClientDetailsDTO
          {
              Name = x.user.Name,
              Email = x.user.Email,
              PhoneNumber = x.user.PhoneNumber
          },

          Phases = x.ProjectPhases.Select(t => new ProjectResponseTasksDTO
          {
              PhaseCode = t.PhaseCode,
              PhaseName = t.PhaseName,
              Status = t.Status,
              PlannedEndDate = t.PlannedEndDate,
              PlannedStartedDate = t.PlannedStartedDate
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
