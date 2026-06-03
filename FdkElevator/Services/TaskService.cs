using FdkElevator.AppDbContext;
using FdkElevator.Models.Projects;
using FdkElevator.Services.IServices;

namespace FdkElevator.Services
{
    public class TaskService : ITask
    {   

        private readonly ApplicationDbContext _context;

        public TaskService(ApplicationDbContext context)
        {
            _context = context;
        }

        public string addTask(ProjectTask task)
        {
           _context.projectTasks.Add(task);
            _context.SaveChanges();
            return "Task added successfully!";
        }

        public ProjectTask getProjectTaskById(Guid guid)
        {
            return _context.projectTasks.Find(guid);
        }

        public List<ProjectTask> getUserTasks(Guid userId)
        {
            return _context.projectTasks.Where(x => x.UserId == userId).ToList();
        }

        public string removeTask(ProjectTask task)
        {
           _context.projectTasks.Remove(task);
            _context.SaveChanges();
            return "Task removed successfully!";
        }

        public string updateTask(ProjectTask task)
        {
           _context.projectTasks.Update(task);
            _context.SaveChanges();
            return "Task updated successfully!";
        }

        public bool updateTaskStatus(Guid guid, AllTaskStatus newStatus)
        {
            var task = _context.projectTasks.Find(guid);

            if (task == null)
            {
                return false; // Task not found
            }

            task.Status = newStatus;
            _context.projectTasks.Update(task);
            _context.SaveChanges();
            return true;
        }
    }
}
