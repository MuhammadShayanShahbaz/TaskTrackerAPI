namespace TaskTracker.Models
{
    public class TaskModel
    {
        public int TaskID { get; set; }
        public int ProjectID { get; set; }
        public string? TaskTitle { get; set; }
        public string? Status { get; set; }
        public DateTime DueDate { get; set; }
    }
}