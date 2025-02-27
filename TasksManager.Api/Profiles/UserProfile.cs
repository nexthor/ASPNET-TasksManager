using AutoMapper;
using TasksManager.Api.DTOs;
using TasksManager.Api.Models;

namespace TasksManager.Api.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, RegistrationRequestDto>()
                .ReverseMap();
            CreateMap<ApplicationUser, UserDto>()
                .ReverseMap();
            CreateMap<RegistrationRequestDto, ApplicationUser>()
                .ReverseMap();
        }
    }
}
