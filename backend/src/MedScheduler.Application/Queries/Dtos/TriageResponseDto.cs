using MedScheduler.Domain.Dtos;
using MedScheduler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MedScheduler.Application.Queries.Dtos
{
    public class TriageResponseDto
    {
        public IEnumerable<DoctorUnavailableAppointmentsDto> UnavailableAppointments { get; set; }
        public string Symptoms { get; set; }
        public DateTime AppointmentDateTime { get; set; }

    }
}
