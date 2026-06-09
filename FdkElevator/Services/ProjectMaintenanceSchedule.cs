using FdkElevator.AppDbContext;
using FdkElevator.Models.Projects;
using FdkElevator.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace FdkElevator.Services
{
    public class ProjectMaintenanceScheduleService : IProjectMaintenanceSchedule
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ProjectMaintenanceScheduleService> _logger;

        public ProjectMaintenanceScheduleService(
            ApplicationDbContext context,
            ILogger<ProjectMaintenanceScheduleService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<string> AddProjectMaintenanceScheduleAsync(
            MaintenanceSchedule schedule,
            CancellationToken cancellationToken = default)
        {
      

            await _context.MaintenanceSchedules.AddAsync(schedule, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("Created maintenance schedule {ScheduleId} for project {ProjectId}",
                schedule.Id, schedule.ProjectId);

            return $"Maintenance schedule {schedule.Id} created successfully.";
        }

        public async Task<List<MaintenanceSchedule>> GetMaintenanceSchedulesByProjectIdAsync(
            Guid projectId,
            CancellationToken cancellationToken = default)
        {
            return await _context.MaintenanceSchedules
                .AsNoTracking()                          
                .Where(m => m.ProjectId == projectId)
                .ToListAsync(cancellationToken);
        }

        public async Task<MaintenanceSchedule?> getProjectMaintenanceScheduleById(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            return await _context.MaintenanceSchedules
                .AsNoTracking()                          // read-only: no change tracking overhead
                .FirstOrDefaultAsync(m => m.Id == id, cancellationToken);
        }

        public async Task<MaintenanceSchedule> UpdateProjectMaintenanceScheduleAsync(
            MaintenanceSchedule schedule,
            CancellationToken cancellationToken = default)
        {
            // Re-attach the entity so EF Core tracks and updates it
            _context.MaintenanceSchedules.Update(schedule);
            await _context.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("Updated maintenance schedule {ScheduleId}", schedule.Id);

            return schedule;
        }

     
    }
}