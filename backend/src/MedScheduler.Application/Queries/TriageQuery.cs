
using MediatR;
using MedScheduler.Application.Queries.Dtos;

namespace MedScheduler.Application.Queries
{
    public record TriageQuery : IRequest<TriageResponseDto>
    {
        public Guid Id { get; init; }
        public string Symtoms { get; init; } = string.Empty;
        public DateTime AppointmentDate { get; init; }
    }
}
