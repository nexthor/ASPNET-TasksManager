namespace TasksManager.Api.Options
{
    public class TaskManagerOptions
    {
        public string? Url { get; set; }
        public string? SMTPUser { get; set; }
        public string? SMTPPassword { get; set; }
        public string? SMTPHost { get; set; }
        public int SMTPPort { get; set; }
    }
}
