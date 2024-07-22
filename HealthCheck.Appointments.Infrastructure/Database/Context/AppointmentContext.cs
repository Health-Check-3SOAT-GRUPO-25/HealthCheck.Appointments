using HealthCheck.Appointments.Domain.DatabaseConfiguration;
using HealthCheck.Appointments.Domain.Entities;
using MongoDB.Driver;

namespace HealthCheck.Appointments.Infrastructure.Database.Context;

public class AppointmentContext
{
    public readonly IMongoCollection<Appointment> Appointments;

    public AppointmentContext(IDatabaseConfiguration databaseSettings)
    {
        MongoClient client = new(databaseSettings.ConnectionURI());

        IMongoDatabase database = client.GetDatabase(databaseSettings.DatabaseName());

        Appointments = database.GetCollection<Appointment>(databaseSettings.CollectionName());
    }
}