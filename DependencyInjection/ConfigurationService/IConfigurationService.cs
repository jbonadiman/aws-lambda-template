using Microsoft.Extensions.Configuration;

namespace DefaultLambda.DependencyInjection.ConfigurationService
{
    public interface IConfigurationService
    {
        IConfiguration GetConfiguration();
    }
}