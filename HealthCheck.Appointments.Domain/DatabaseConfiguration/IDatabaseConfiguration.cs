namespace HealthCheck.Appointments.Domain.DatabaseConfiguration;

public interface IDatabaseConfiguration
{
    string ConnectionURI();

    string DatabaseName();

    string CollectionName();
}
