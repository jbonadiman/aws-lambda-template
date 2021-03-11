using System.IO;
using DefaultLambda.DependencyInjection.EnvironmentService;
using Microsoft.Extensions.Configuration;

namespace DefaultLambda.DependencyInjection.ConfigurationService
{
    public class ConfigurationService : IConfigurationService
    {
        public IEnvironmentService EnvironmentService { get; }
        public string CurrentDirectory { get; set; }

        public ConfigurationService(IEnvironmentService envService)
        {
            this.EnvironmentService = envService;
        }

        public IConfiguration GetConfiguration()
        {
            this.CurrentDirectory ??= Directory.GetCurrentDirectory();
            return new ConfigurationBuilder()
                .SetBasePath(this.CurrentDirectory)
                .AddJsonFile(
                    $"appsettings.{this.EnvironmentService.EnvironmentName}.json",
                    optional: true)
                .AddJsonFile(
                    "appsettings.json",
                    optional: true,
                    reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}