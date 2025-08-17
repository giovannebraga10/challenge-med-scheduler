using MedScheduler.Domain.Dtos;
using MedScheduler.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedScheduler.Infrastructure.Repositories.Appointmenties
{
    public class AppointmentRepository(AppDbContext _context) : IAppointmentRepository
    {
        public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync() => await _context.Appointments.ToListAsync();

        public async Task UpdateStatusAppointmentAsync(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task<Guid> AddAppointmentAsync(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
            await _context.SaveChangesAsync();
            return appointment.Id;
        }

        public async Task<IEnumerable<DoctorUnavailableAppointmentsDto>> GetUnavailableAppointmentsAsync(IEnumerable<DoctorDto> doctorDtos, DateTime appointmentDateTime)
        {

            var doctorIds = doctorDtos.Select(x => x.Id).ToList();

            return await _context.Appointments
                .Where(a => doctorIds.Contains(a.DoctorId) && a.AppointmentDate.Date == appointmentDateTime.Date)
                .GroupBy(a => a.DoctorId)
                .Select(g => new DoctorUnavailableAppointmentsDto
                {
                    DoctorId = g.Key,
                    DoctorName = doctorDtos.First(d => d.Id == g.Key).Name,
                    UnavailableTimes = g.Select(a => a.AppointmentDate).ToList()
                }).ToListAsync();
        }
         
        public async Task<bool> AppointmentWasAvailable(DateTime appointmentDate, Guid doctorId)
        {
            return !await _context.Appointments.AnyAsync(a => a.DoctorId == doctorId && a.AppointmentDate == appointmentDate); ;
        }
    }
}
