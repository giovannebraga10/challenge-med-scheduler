
using MedScheduler.Domain.Dtos;

namespace MedScheduler.Domain.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> GetAllAppointmentsAsync();
        Task UpdateStatusAppointmentAsync (Appointment appointment);
        Task<Guid> AddAppointmentAsync(Appointment appointment);
        Task<IEnumerable<DoctorUnavailableAppointmentsDto>> GetUnavailableAppointmentsAsync(IEnumerable<DoctorDto> doctorDtos, DateTime appointmentDateTime);
        Task<bool> AppointmentWasAvailable(DateTime appointmentDate, Guid doctorId);
    }
}
