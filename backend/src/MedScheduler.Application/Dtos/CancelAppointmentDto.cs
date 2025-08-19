using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedScheduler.Application.Dtos
{
    public record CancelAppointmentDto (Guid AppointmentId);
}
