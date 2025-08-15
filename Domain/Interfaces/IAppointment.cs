using MedScheduler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedScheduler.Domain.Interfaces
{
    public interface IAppointment
    {
        Task<IEnumerable<Appointment>> GetAppointmentsAsync(Guid userId);
        Task UpdateStatusAppointmentAsync (Appointment appointment);
        Task AddAppointmentAsync(Appointment appointment);
    }
}
