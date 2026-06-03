using AutoMapper;
using FdkElevator.DTOS.ProjectDTOS;
using FdkElevator.Models.Projects;
using FdkElevator.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FdkElevator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {

        private readonly ITask _task;
        private readonly IMapper _mapper;

        public TaskController(IMapper mapper, ITask task)
        {
            _mapper = mapper;
            _task = task;
        }

        [HttpPost("addTask")]
        public ActionResult<string> addTask(AddTaskDTO newtask)
        {
            try
            {

                var task = _mapper.Map<ProjectTask>(newtask);
                var result = _task.addTask(task);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("updateTask/{Id}")]
        public ActionResult<string> updateTask(Guid Id, AddTaskDTO updatedTask)
        {
            try
            {   

                var existingTask = _task.getProjectTaskById(Id);
                if (existingTask == null)
                {
                    return NotFound($"Task with ID {Id} not found.");
                }

                var task = _mapper.Map(updatedTask, existingTask);
                var result = _task.updateTask(task);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("updateTaskStatus/{Id}")]
        public ActionResult<string> updateTaskStatus(Guid Id, AllTaskStatus newStatus)
        {
            try
            {
                var existingTask = _task.getProjectTaskById(Id);
                if (existingTask == null)
                {
                    return NotFound($"Task with ID {Id} not found.");
                }
                var result = _task.updateTaskStatus(Id, newStatus);
                if (!result)
                {
                    return BadRequest("Failed to update task status.");
                }
                return Ok("Task status updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete("removeTask/{Id}")]
        public ActionResult<string> removeTask(Guid Id)
        {
            try
            {
                var existingTask = _task.getProjectTaskById(Id);
                if (existingTask == null)
                {
                    return NotFound($"Task with ID {Id} not found.");
                }
                var result = _task.removeTask(existingTask);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet("tasks/{userId}")]

        public ActionResult<List<ProjectTask>> getUserTasks(Guid userId)
        {
            try
            {
                var tasks = _task.getUserTasks(userId);
                return Ok(tasks);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        }
}
