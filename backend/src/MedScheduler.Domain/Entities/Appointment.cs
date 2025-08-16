using MedScheduler.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MedScheduler.Domain.Entities
{
    public class Appointment
    {
        public Guid Id { get; private set; }
        public Guid PatientId { get; private set; }
        public Guid DoctorId { get; private set; }
        public DateTime AppointmentDate { get; private set; }
        public string Symtoms { get; private set; } = string.Empty;
        public string SpecialitySuggested { get; private set; } = string.Empty;
        public AppointmentsStatusEnum Status { get; private set; } = AppointmentsStatusEnum.Pending;
        public DateTime CreatedAt { get; private set; }

        public Appointment(){}

        public Appointment(Guid patientId, Guid doctorId, DateTime appoitmentDate, string symtoms, string specialitySuggested)
        {
            Id = Guid.NewGuid();
            PatientId = patientId;
            DoctorId = doctorId;
            ApproveAppointmentDate(appoitmentDate); 
            Symtoms = symtoms;
            SpecialitySuggested = specialitySuggested;
            Status = AppointmentsStatusEnum.Confirmed;
            CreatedAt = DateTime.Now;
        }

        public void ApproveAppointmentDate(DateTime appointmentDate)
        {
            if (appointmentDate < DateTime.Now) throw new ArgumentException("Appointment date cannot be in the past.");
            AppointmentDate = appointmentDate;
        }

    }
}
