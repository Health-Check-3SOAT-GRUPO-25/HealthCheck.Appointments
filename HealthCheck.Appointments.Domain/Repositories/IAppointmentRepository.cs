using HealthCheck.Appointments.Domain.Entities;

namespace HealthCheck.Appointments.Domain.Repositories;

public interface IAppointmentRepository
{
    Task Add(Appointment order);

    Task<IEnumerable<Appointment>> GetAll();

    Task<Appointment> GetById(Guid id);

    Task<IEnumerable<Appointment>> GetByDoctorId(Guid doctorId);

    Task Update(Appointment order);
}