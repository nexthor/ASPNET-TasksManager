using System.ComponentModel.DataAnnotations.Schema;

namespace TasksManager.Api.Models
{
    [Table("Tasks")]
    public class TaskItem
    {
        public Guid Id { get; set; }
        public string? UserId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
