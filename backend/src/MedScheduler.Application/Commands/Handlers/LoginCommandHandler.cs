using MediatR;
using MedScheduler.Application.Commands;
using MedScheduler.Application.Dtos;
using MedScheduler.Application.Interfaces;

public class LoginCommandHandler(
    IUserService _userService,
    IJwtTokenService _jwtTokenService) : IRequestHandler<LoginCommand, AuthResponseDto>
{

    public async Task<AuthResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userService.AuthenticateAsync(request.Email, request.Password);
        if (user == null)
            throw new UnauthorizedAccessException("Credenciais inválidas");

        var token = _jwtTokenService.GenerateToken(user.Id, user.Role.ToString());

        return new AuthResponseDto
        {
            Token = token,
            Role = user.Role.ToString()
        };
    }
}
