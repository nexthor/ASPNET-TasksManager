namespace TasksManager.Api.DTOs
{
    public class TaskRequestDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
