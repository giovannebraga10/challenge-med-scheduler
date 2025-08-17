using MediatR;
using MedScheduler.Domain.Interfaces;

namespace MedScheduler.Application.Commands.Handlers
{
    public class CreateAppointmentHandler(IAppointmentRepository _repository) : IRequestHandler<CreateAppointmentCommand, Guid>
    {
        public async Task<Guid> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            

        }
    }
}
