using FdkElevator.AppDbContext;
using FdkElevator.DTOS.InstallationsDTO;
using FdkElevator.Models.Installations;
using FdkElevator.Models.Projects;
using FdkElevator.Services.IServices;

namespace FdkElevator.Services
{
    public class InstallationService : IInstallation
    {   
        private readonly ApplicationDbContext _context;

        public InstallationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public string addInstallation(Installation installation)
        {
           _context.Installations.Add(installation);
            _context.SaveChanges();
            return "Installation added successfully";
        }

        public string completeInstallation(Guid installationId, string? notes)
        {
          var installation = _context.Installations.FirstOrDefault(i => i.Id == installationId);
            if (installation == null)
            {
                return "Installation not found";
            }
            installation.IsCompleted = true;
            installation.Notes = notes;
            _context.Installations.Update(installation);
            _context.SaveChanges();
            return "Installation marked as completed";
        }

        public Installation getInstallation(Guid installationId)
        {
            var installation = _context.Installations.FirstOrDefault(i => i.Id == installationId);
            return installation!;
        }

        public List<Installation> getInstallationsByProjectId(Guid projectId)
        {
           return _context.Installations.Where(i => i.ProjectId == projectId).ToList();
        }

        public ProjectInstallationResponseDto GetTasksByProjectAsync(Guid projectId)
        {
            var tasks = _context.Installations
        .Where(t => t.ProjectId == projectId)
        .ToList();

            var response = new ProjectInstallationResponseDto
            {
                CompletedTasks = tasks
                    .Where(t => t.IsCompleted)
                    .Select(MapToDto)
                    .ToList(),

                PendingTasks = tasks
                    .Where(t => !t.IsCompleted)
                    .Select(MapToDto)
                    .ToList()
            };

            return response;
        }

        private static TaskInstallationDto MapToDto(Installation task)
        {
            return new TaskInstallationDto
            {
                Id = task.Id,
                ProjectId = task.ProjectId,
                TaskName = task.TaskName,
                PlannedStart = task.PlannedStart,
                PlannedEnd = task.PlannedEnd,
                IsCompleted = task.IsCompleted,
                Notes = task.Notes
            };
        }

        public string updateInstallation(Installation installation)
        {
          _context.Installations.Update(installation);
            _context.SaveChanges();
            return "Installation updated successfully";
        }
    }
}
