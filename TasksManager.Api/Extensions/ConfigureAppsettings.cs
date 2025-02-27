namespace TasksManager.Api.Extensions
{
    public static class ConfigureAppsettings
    {
        public static void AddAppsettingsConfiguration(this IServiceCollection services, ConfigurationManager configuration, IWebHostEnvironment environment)
        {
            configuration.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true)
                .AddJsonFile("appsettings.Local.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
        }
    }
}
