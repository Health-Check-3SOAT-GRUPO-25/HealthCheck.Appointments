using HealthCheck.Appointments.Domain.Entities;
using HealthCheck.Appointments.Domain.Repositories;
using HealthCheck.Appointments.Infrastructure.Database.Context;
using MongoDB.Driver;

namespace HealthCheck.Appointments.Infrastructure.Repositories;

public class AppointmentRepository(AppointmentContext context) : IAppointmentRepository
{
    public async Task Add(Appointment appointment)
    {
        await context.Appointments.InsertOneAsync(appointment);
    }

    public async Task<IEnumerable<Appointment>> GetAll()
    {
        return await context.Appointments
            .Find(o => true)
            .ToListAsync();
    }

    public async Task<IEnumerable<Appointment>> GetByDoctorId(Guid doctorId)
    {
        return await context.Appointments
           .Find(o => o.DoctorId == doctorId).ToListAsync();
    }

    public async Task<Appointment?> GetById(Guid id)
    {
        return await context.Appointments
            .Find(o => o.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task Update(Appointment order)
    {
        var filter = Builders<Appointment>.Filter.Eq(e => e.Id, order.Id);

        await context.Appointments.ReplaceOneAsync(filter, order);
    }
}