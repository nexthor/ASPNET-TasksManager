
using Microsoft.EntityFrameworkCore;
using TasksManager.Api.Contexts;
using TasksManager.Api.Extensions;

namespace TasksManager.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services;
            var configuration = builder.Configuration;
            var environment = builder.Environment;

            // Add services to the container.

            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            // configuration priority: appsettings.Local.json > appsettings.Development.json > appsettings.json
            services.AddAppsettingsConfiguration(configuration, environment);
            // Add DbContext
            services.AddDbContext<AppDbContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString(SD.DbConnection)));
            // add common options
            services.Configure<TaskManagerOptions>(configuration.GetSection(SD.TasksManager));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
