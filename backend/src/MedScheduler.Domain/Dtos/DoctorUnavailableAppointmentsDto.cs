namespace MedScheduler.Domain.Dtos
{

    public class DoctorUnavailableAppointmentsDto
    {
        public Guid DoctorId { get; set; }
        public string DoctorName { get; set; } = string.Empty;
        public IEnumerable<DateTime> UnavailableTimes { get; set; } = new List<DateTime>();
    }

}
