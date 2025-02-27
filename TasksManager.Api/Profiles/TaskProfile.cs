using AutoMapper;
using TasksManager.Api.DTOs;
using TasksManager.Api.Models;

namespace TasksManager.Api.Profiles
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<TaskItem, TaskRequestDto>().ReverseMap();
        }
    }
}
