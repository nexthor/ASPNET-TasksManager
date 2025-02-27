using TasksManager.Api.DTOs;
using TasksManager.Api.Models;

namespace TasksManager.Api.Services.Interfaces
{
    public interface ITaskService
    {
        Task<TaskItem> CreateTaskAsync(TaskRequestDto task, string userId);
        Task DeleteTaskAsync(Guid id, string userId);
        Task<TaskItem?> GetTaskAsync(Guid id, string userId);
        Task<IEnumerable<TaskItem>> GetTasksAsync(string userId);
        Task<TaskItem> UpdateTaskAsync(Guid id, string userId, TaskRequestDto task);
    }
}