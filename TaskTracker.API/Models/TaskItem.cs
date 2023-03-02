namespace TaskTracker.API.Models
{
    public class TaskItem
    {
        public Guid Id { get; set; }
        public StatusType Status { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
