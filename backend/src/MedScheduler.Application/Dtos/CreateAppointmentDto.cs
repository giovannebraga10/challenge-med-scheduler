namespace MedScheduler.Application.Dtos
{
    public class CreateAppointmentDto
    {
        public DateTime AppointmentDate { get; set; }
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }
        public string Speciality { get; set; } = string.Empty;
        public string Symtoms { get; set; } = string.Empty;
    }
}
