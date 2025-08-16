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

        public Task AddAppointmentAsync(Appointment appointment)
        {
            _context.Appointments.AddAsync(appointment);
            return _context.SaveChangesAsync();
        }
    }
}
