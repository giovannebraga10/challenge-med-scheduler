using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedScheduler.Application.Queries.Dtos
{
    public class TriageRequestDto
    {
        public string Symtoms { get; init; } = string.Empty;
        public DateTime AppointmentDate { get; init; }
    }
}
