using HealthCheck.Appointments.IOC.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HealthCheck.Appointments.IOC;

public static class DependencyInjectionConfiguration
{
    public static void Register
    (
        IServiceCollection services,
        IConfiguration configuration
    )
    {
        //ConfigureDatabase.Register(services, configuration);
        //ConfigureHealthChecks.Register(services);
        ConfigureOptions.Register(services, configuration);
        ConfigureSecurity.Register(services, configuration);
        InjectionConfig.AddDependencies(services, configuration);
        //ConfigureServices.Register(services);
    }
}
