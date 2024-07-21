using HealthCheck.Appointments.Application.Contracts.UseCases;
using HealthCheck.Appointments.Application.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace HealthCheck.Appointments.Application.DependencyInjection;

public static class InjectionConfig
{
    public static void AddApplicationDependencies(this IServiceCollection services)
    {
        #region UseCases

        services.AddScoped<IAppointmentUseCase, AppointmentUseCase>();

        #endregion
    }
}