using HealthCheck.Appointments.Application.DependencyInjection;
using HealthCheck.Appointments.Infrastructure.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HealthCheck.Appointments.IOC.Configurations;

public static class InjectionConfig
{
    public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddApplicationDependencies();
        services.AddInfrastructureDependencies(configuration);
    }
}
