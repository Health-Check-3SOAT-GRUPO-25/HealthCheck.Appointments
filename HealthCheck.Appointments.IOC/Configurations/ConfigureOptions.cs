using HealthCheck.Appointments.Domain.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HealthCheck.Appointments.IOC.Configurations;

public static class ConfigureOptions
{
    public static void Register
    (
        IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.Configure<JwtConfiguration>
        (
            options => configuration.GetSection("Jwt").Bind(options)
        );

        //services.Configure<AwsConfiguration>
        //(
        //    options => configuration.GetSection("AWS").Bind(options)
        //);
    }
}
