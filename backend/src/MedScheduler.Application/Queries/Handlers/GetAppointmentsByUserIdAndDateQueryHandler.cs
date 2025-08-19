using MediatR;
using MedScheduler.Application.Queries.Dtos;
using MedScheduler.Domain.Interfaces;

namespace MedScheduler.Application.Queries.Handlers
{
    public class GetAppointmentsByUserIdAndDateQueryHandler(
        IUserRepository _userRepository
        ) : IRequestHandler<GetAppointmentsByUserIdAndDateQuery, IEnumerable<AppointmentResponseDto>>
    {
        public Task<IEnumerable<AppointmentResponseDto>> Handle(GetAppointmentsByUserIdAndDateQuery request, CancellationToken cancellationToken)
        {
            var appointments = _userRepository.GetAppointmentsByUserIdAndDateAsync(request.userId, request.appointmentDate);
        }
    }
}


