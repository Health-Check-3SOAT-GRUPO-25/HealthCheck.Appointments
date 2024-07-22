namespace HealthCheck.Appointments.Application.Models
{
    public class AppointmentCreateRequestModel
    {
        public Guid DoctorId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public decimal Price { get; set; }
    }
}