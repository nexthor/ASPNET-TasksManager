using TasksManager.Api.Models;

namespace TasksManager.Api.Services.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser user);
    }
}