using MedScheduler.Domain.Dtos;

namespace MedScheduler.Application.Queries.Dtos
{
    public class AppointmentResponseDto
    {
        public Guid AppointmentId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Name { get; set; } = null!;
        public string DoctorName { get; set; } = null!;
        public string Speciality { get; set; } = null!;
    }
}
