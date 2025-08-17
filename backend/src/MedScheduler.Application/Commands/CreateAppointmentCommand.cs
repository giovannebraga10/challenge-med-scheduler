using MediatR;

namespace MedScheduler.Application.Commands
{
    public class CreateAppointmentCommand : IRequest<Guid>
    {
        public DateTime AppointmentDate { get; set; }
        public Guid PatientId { get; set; }
        public string Symtoms { get; set; } = string.Empty;


    }
}
