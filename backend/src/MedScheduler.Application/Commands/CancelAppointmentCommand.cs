using MediatR;

namespace MedScheduler.Application.Commands
{
    public record CancelAppointmentCommand(Guid AppointmentId) : IRequest<bool>;
}
