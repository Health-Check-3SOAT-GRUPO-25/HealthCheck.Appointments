using HealthCheck.Appointments.Application.Contracts.UseCases;
using HealthCheck.Appointments.Application.Models;
using HealthCheck.Appointments.Domain.Constants;
using HealthCheck.Appointments.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HealthCheck.Appointments.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AppointmentController(IAppointmentUseCase service) : ControllerBase
{
    [HttpGet(Name = "Get appointments")]
    [SwaggerOperation(
     Summary = "Get all appointments",
     Description = "Get all appointments.")]
    [ProducesResponseType(typeof(List<Appointment>), StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> GetAllAppointments()
    {
        var result = await service.GetAll();
        return Ok(result);
    }

    [Authorize(Roles = $"{RolesConstants.Doctor}")]
    [HttpPost(Name = "Create appointment")]
    [SwaggerOperation(
     Summary = "Create an appointment",
     Description = "Create an appointment.")]
    [ProducesResponseType(typeof(void), StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> CreateAppointment([FromBody] AppointmentCreateRequestModel appointment)
    {
        await service.Add(appointment);
        return Ok();
    }

    [Authorize]
    [HttpGet("{id:Guid}", Name = "Get appointments by DoctorId")]
    [SwaggerOperation(
 Summary = "Get appointments by DoctorId",
 Description = "Get appointments by DoctorId.")]
    [ProducesResponseType(typeof(IEnumerable<Appointment>), StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> GetAppointmentsByDoctorId(Guid id)
    {
        var result = await service.GetByDoctorId(id);
        return Ok(result);
    }

    [Authorize(Roles = $"{RolesConstants.Patient}")]
    [HttpPut("{appointmentId:Guid}/{patientId:Guid}", Name = "Schedule an appointment")]
    [SwaggerOperation(
Summary = "Schedule an appointment",
Description = "Schedule an appointment.")]
    [ProducesResponseType(typeof(IEnumerable<Appointment>), StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> ScheduleAppointment(Guid appointmentId, Guid patientId)
    {
        await service.ScheduleAppointment(appointmentId, patientId);
        return Ok();
    }
}
