using System;
using DefaultLambda.DependencyInjection.ConfigurationService;
using DefaultLambda.DependencyInjection.EnvironmentService;
using Microsoft.Extensions.DependencyInjection;

namespace DefaultLambda.DependencyInjection
{
    public class DependencyResolver
    {
        public IServiceProvider ServiceProvider { get; }
        public string CurrentDirectory { get; set; }
        public Action<IServiceCollection> RegisterServices { get; }

        public DependencyResolver(Action<IServiceCollection> registerServices = null)
        {
            var serviceCollection = new ServiceCollection();
            this.RegisterServices = registerServices;
            this.ConfigureServices(serviceCollection);
            this.ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Register env and config services
            services.AddTransient<IEnvironmentService, EnvironmentService.EnvironmentService>();
            services.AddTransient<IConfigurationService, ConfigurationService.ConfigurationService>
            (provider =>
                new ConfigurationService.ConfigurationService(
                    provider.GetService<IEnvironmentService>())
                {
                    CurrentDirectory = this.CurrentDirectory
                });

            this.RegisterServices?.Invoke(services);
        }
    }
}