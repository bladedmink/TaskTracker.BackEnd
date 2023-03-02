using TaskTracker.API.Models;

namespace TaskTracker.API.Services
{
    public interface ITaskService
    {
        public ICollection<TaskItem> GetTaskItems();
        public TaskItem AddTask(TaskItem task);
        public TaskItem UpdateTask(TaskItem task);
        public bool DeleteTask(Guid id);
    }
}