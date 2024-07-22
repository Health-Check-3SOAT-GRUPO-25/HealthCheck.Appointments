namespace HealthCheck.Appointments.Domain.Entities;

public class Appointment
{
    public Guid Id { get; set; }
    public Guid DoctorId { get; private set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public decimal Price { get; set; }
    public Guid? PatientId { get; private set; }

    public bool? AcceptedByDoctor { get; set; }

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

    public void AcceptAppointment()
    {
        if (AcceptedByDoctor == null)
        {
            AcceptedByDoctor = true;
        }
    }

    public void DeclineAppointment()
    {
        if (AcceptedByDoctor == null)
        {
            AcceptedByDoctor = false;
        }
    }

    public void UpdateTime(DateTime start, DateTime end)
    {
        Start = start;
        End = end;
    }
}