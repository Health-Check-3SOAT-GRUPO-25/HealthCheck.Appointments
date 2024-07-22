using HealthCheck.Appointments.Application.Models;
using HealthCheck.Appointments.Domain.Entities;

namespace HealthCheck.Appointments.Application.Contracts.UseCases;

public interface IAppointmentUseCase
{
    Task Add(AppointmentCreateRequestModel order);

    Task<IEnumerable<Appointment>> GetAll();

    Task<Appointment> GetById(Guid id);

    Task<IEnumerable<Appointment>> GetByDoctorId(Guid doctorId);

    Task ScheduleAppointment(Guid appointmentId, Guid patientId);

    Task UpdateTime(Guid appointmentId, UpdateAppointmentTimeModel model);

    Task ConfirmAppointment(Guid appointmentId, bool appointmentAccepted);
}