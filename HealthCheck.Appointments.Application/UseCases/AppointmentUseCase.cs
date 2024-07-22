using HealthCheck.Appointments.Application.Contracts.UseCases;
using HealthCheck.Appointments.Application.Models;
using HealthCheck.Appointments.Domain.Entities;
using HealthCheck.Appointments.Domain.Repositories;

namespace HealthCheck.Appointments.Application.UseCases;

public class AppointmentUseCase(IAppointmentRepository repository) : IAppointmentUseCase
{
    public async Task Add(AppointmentCreateRequestModel model)
    {
        Appointment appointment = new Appointment(model.DoctorId, model.Start, model.End, model.Price);
        await repository.Add(appointment);
    }

    public async Task<IEnumerable<Appointment>> GetAll()
    {
        return await repository.GetAll();
    }

    public async Task<IEnumerable<Appointment>> GetByDoctorId(Guid doctorId)
    {
        return await repository.GetByDoctorId(doctorId);
    }

    public async Task<Appointment> GetById(Guid id)
    {
        return await repository.GetById(id);
    }

    public async Task ScheduleAppointment(Guid appointmentId, Guid patientId)
    {
        var appointment = await GetById(appointmentId);
        appointment.ScheduleAppointment(patientId);
        await repository.Update(appointment);
    }
}
