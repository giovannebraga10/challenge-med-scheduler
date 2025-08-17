
using MedScheduler.Domain.Dtos;

namespace MedScheduler.Domain.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> GetAllAppointmentsAsync();
        Task UpdateStatusAppointmentAsync (Appointment appointment);
        Task AddAppointmentAsync(Appointment appointment);
        Task<IEnumerable<DoctorUnavailableAppointmentsDto>> GetUnavailableAppointmentsAsync(IEnumerable<DoctorDto> doctorDtos, DateTime appointmentDateTime);
    }
}
