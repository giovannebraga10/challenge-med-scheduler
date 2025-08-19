
using MediatR;
using MedScheduler.Application.Queries.Dtos;

namespace MedScheduler.Application.Queries
{
    public record TriageQuery(string Symtoms, DateTime AppointmentDate) : IRequest<TriageResponseDto>;
}
