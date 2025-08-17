using MediatR;

namespace MedScheduler.Application.Commands
{
    public class CancelAppointmentCommand : IRequest<bool>
    {
        public Guid AppointmentId { get; set; }
    }
}
