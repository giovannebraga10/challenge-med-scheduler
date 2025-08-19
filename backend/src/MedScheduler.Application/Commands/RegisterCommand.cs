using MediatR;
using MedScheduler.Application.Dtos;

namespace MedScheduler.Application.Commands
{
    public record RegisterCommand(
        string Name,
        string Email,
        string Password,
        int Role,
        Guid specialityId) : IRequest<AuthResponseDto>;

}
