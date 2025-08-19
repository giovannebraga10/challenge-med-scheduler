using MediatR;
using MedScheduler.Application.Queries.Dtos;

namespace MedScheduler.Application.Queries
{
    public record GetAppointmentsByUserIdAndDateQuery(Guid userId, DateTime appointmentDate) : IRequest<IEnumerable<AppointmentResponseDto>>;
  
}
