using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TasksManager.Api.Options;
using TasksManager.Api.Services;
using TasksManager.Api.Services.Interfaces;

namespace TasksManager.Api.Extensions
{
    /// <summary>
    /// Extension methods for adding services to the DI container.
    /// </summary>
    public static class ServicesExtension
    {
        /// <summary>
        /// Adds services to the DI container.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped<ITaskService, TaskService>();

            return services;
        }

        /// <summary>
        /// generic method to add authorization to the services.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        public static void ConfigureAuthorization(this IServiceCollection services, IConfiguration config)
        {
            var options = config.GetSection(SD.Jwt).Get<JwtOptions>();
            var secret = options?.Secret;
            var issuer = options?.Issuer;
            var audience = options?.Audience;

            var key = Encoding.ASCII.GetBytes(secret!);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    ValidateAudience = true,
                };
            });
            services.AddAuthorization();
        }
    }
}
