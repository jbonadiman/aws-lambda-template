using System;

namespace DefaultLambda.DependencyInjection.EnvironmentService
{
    public class EnvironmentService : IEnvironmentService
    {
        public string EnvironmentName { get; set; }

        public EnvironmentService()
        {
            this.EnvironmentName =
                Environment.GetEnvironmentVariable(
                    Constants.EnvironmentVariables.AspNetCoreEnvironment
                    ) ?? Constants.Environments.Development;
        }
    }
}