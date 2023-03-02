using TaskTracker.API.Models;

namespace TaskTracker.API.Services
{
    public class TaskService : ITaskService
    {
        private List<TaskItem> _tasks;

        public TaskService()
        { 
            _tasks = new List<TaskItem>();
        }

        public ICollection<TaskItem> GetTaskItems()
        {
            return _tasks.OrderByDescending(t => t.CreatedDate).ToList();
        }

        public TaskItem AddTask(TaskItem task)
        {
            task.Id = Guid.NewGuid();
            task.CreatedDate = DateTime.Now;
            _tasks.Add(task);

            return task;
        }

        public TaskItem UpdateTask(TaskItem task)
        {
            var taskToUpdate = _tasks.SingleOrDefault(t => t.Id == task.Id);
            if (taskToUpdate is not null)
            {
                taskToUpdate.Status = task.Status;
                taskToUpdate.Title = task.Title;
                taskToUpdate.Description = task.Description;
            }

            return task;
        }

        public bool DeleteTask(Guid id)
        {
            if (_tasks.Any(t => t.Id == id))
            {
                var task = _tasks.SingleOrDefault(t => t.Id == id);

                if (task is not null)
                {
                    _tasks.Remove(task);
                }

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
