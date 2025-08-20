using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedScheduler.Application.Queries.Dtos
{
    public class SpecialityResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
