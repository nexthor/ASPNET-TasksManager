using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TasksManager.Api.Contexts;
using TasksManager.Api.DTOs;
using TasksManager.Api.Models;
using TasksManager.Api.Services.Interfaces;

namespace TasksManager.Api.Services
{
    public class TaskService : ITaskService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public TaskService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TaskItem>> GetTasksAsync(string userId)
            => await _context.Tasks
                            .Where(x => x.UserId != null && x.UserId.Equals(userId))
                            .ToListAsync();

        public async Task<TaskItem?> GetTaskAsync(Guid id, string userId)
        {
            if (id == Guid.Empty)
                throw new ArgumentException(nameof(id));
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentException(nameof(userId));

            var task = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id 
                                                && x.UserId != null 
                                                && x.UserId.Equals(userId));
            return task == null ? throw new Exception("Task not found") : task;
        }

        public async Task<TaskItem> CreateTaskAsync(TaskRequestDto request, string userId)
        {
            if (request == null)
                throw new ArgumentException(null, nameof(request));
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentException(null, nameof(userId));

            var task = _mapper.Map<TaskItem>(request);
            task.UserId = userId;
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<TaskItem> UpdateTaskAsync(Guid id, string userId, TaskRequestDto request)
        {
            if (request == null)
                throw new ArgumentException(null, nameof(request));
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentException(null, nameof(userId));

            var task = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id && x.UserId != null
                                                && x.UserId.Equals(userId));
            if (task == null)
                throw new Exception("Task not found");

            _mapper.Map(request, task);

            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task DeleteTaskAsync(Guid id, string userId)
        {
            if (id == Guid.Empty)
                throw new ArgumentException(null, nameof(id));
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentException(null, nameof(userId));

            var task = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id 
                                            && x.UserId != null && x.UserId.Equals(userId));
            if (task == null)
                throw new Exception("Task not found");
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }
    }
}
