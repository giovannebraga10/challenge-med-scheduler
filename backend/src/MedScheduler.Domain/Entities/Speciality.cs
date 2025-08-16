using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedScheduler.Domain.Entities
{
    public class Speciality
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;

        public Speciality()
        {

        }
    }
}
