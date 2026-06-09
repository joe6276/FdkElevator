using AutoMapper;
using FdkElevator.Models.Projects;
using FdkElevator.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using static FdkElevator.DTOS.ProjectDTOS.ProjectMaintenanceDTO;

namespace FdkElevator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProjectMaintenanceScheduleController : ControllerBase
    {
        private readonly IProjectMaintenanceSchedule _projectMaintenance;
        private readonly IMapper _mapper;
        private readonly ILogger<ProjectMaintenanceScheduleController> _logger;

        public ProjectMaintenanceScheduleController(
            IProjectMaintenanceSchedule project,
            IMapper mapper,
            ILogger<ProjectMaintenanceScheduleController> logger)
        {
            _mapper = mapper;
            _projectMaintenance = project;
            _logger = logger;
        }

        // POST api/projectmaintenanceschedule
        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> AddProjectMaintenance(
            CreateMaintenanceScheduleRequest request,
            CancellationToken cancellationToken)
        {
            var scheduleRequest = _mapper.Map<MaintenanceSchedule>(request);
            var result = await _projectMaintenance.AddProjectMaintenanceScheduleAsync(scheduleRequest, cancellationToken);
            return Ok(result);
        }

        // GET api/projectmaintenanceschedule/{projectId}
        [HttpGet("{projectId:guid}")]
        [ProducesResponseType(typeof(List<MaintenanceSchedule>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<MaintenanceSchedule>>> GetMaintenanceByProjectId(
            Guid projectId,
            CancellationToken cancellationToken)
        {
            // Use a dedicated "get list by project" method — not the single-item lookup
            var result = await _projectMaintenance.GetMaintenanceSchedulesByProjectIdAsync(projectId, cancellationToken);

            if (result is null || result.Count == 0)
                return NotFound($"No schedules found for project {projectId}");

            return Ok(result);
        }

        // GET api/projectmaintenanceschedule/schedule/{id}
        [HttpGet("schedule/{id:guid}")]
        [ProducesResponseType(typeof(MaintenanceSchedule), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MaintenanceSchedule>> GetMaintenanceSchedule(
            Guid id,
            CancellationToken cancellationToken)
        {
            // Use a SEPARATE single-item method so it doesn't fetch a whole list
            var schedule = await _projectMaintenance.getProjectMaintenanceScheduleById(id, cancellationToken);

            if (schedule is null)
                return NotFound($"Schedule {id} not found");

            return Ok(schedule);
        }

        // PUT api/projectmaintenanceschedule/schedule/{id}
        [HttpPut("schedule/{id:guid}")]
        [ProducesResponseType(typeof(MaintenanceSchedule), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MaintenanceSchedule>> UpdateMaintenanceSchedule(
            Guid id,
            CreateMaintenanceScheduleRequest request,
            CancellationToken cancellationToken)
        {
            var existing = await _projectMaintenance.getProjectMaintenanceScheduleById(id, cancellationToken);

            if (existing is null)
                return NotFound($"Maintenance schedule {id} not found");

            _mapper.Map(request, existing); // mutate existing tracked entity — no extra allocation
            var result = await _projectMaintenance.UpdateProjectMaintenanceScheduleAsync(existing, cancellationToken);

            return Ok(result);
        }
    }
}