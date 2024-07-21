using HealthCheck.Appointments.Domain.DatabaseConfiguration;
using HealthCheck.Appointments.Domain.Repositories;
using HealthCheck.Appointments.Infrastructure.Database.Config;
using HealthCheck.Appointments.Infrastructure.Database.Context;
using HealthCheck.Appointments.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HealthCheck.Appointments.Infrastructure.DependencyInjection;

public static class InjectionConfig
{
    public static void AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IAppointmentRepository, AppointmentRepository>();

        services.AddScoped<IDatabaseConfiguration, MongoDBSettings>();
        services.AddScoped<AppointmentContext>();
    }
}