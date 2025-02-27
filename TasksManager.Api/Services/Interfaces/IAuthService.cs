using TasksManager.Api.DTOs;

namespace TasksManager.Api.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginDto> Login(LoginRequestDto request);
        Task<UserDto?> Register(RegistrationRequestDto request);
    }
}