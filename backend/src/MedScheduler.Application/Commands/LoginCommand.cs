namespace MedScheduler.Application.Commands
{
    using MediatR;
    using MedScheduler.Application.Dtos;

    public record LoginCommand(string Email, string Password) : IRequest<AuthResponseDto>;

}
 
