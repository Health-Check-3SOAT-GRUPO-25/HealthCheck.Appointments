namespace HealthCheck.Appointments.Domain.Entities;

public class Appointment
{
    public Guid Id { get; set; }
    public Guid DoctorId { get; private set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public decimal Price { get; set; }
    public Guid? PatientId { get; private set; }

    public Appointment(Guid doctorId, DateTime start, DateTime end, decimal price)
    {
        Id = Guid.NewGuid();
        DoctorId = doctorId;
        Start = start;
        End = end;
        Price = price;
    }

    public void ScheduleAppointment(Guid userId)
    {
        if (PatientId == null)
        {
            PatientId = userId;
        }
    }
}