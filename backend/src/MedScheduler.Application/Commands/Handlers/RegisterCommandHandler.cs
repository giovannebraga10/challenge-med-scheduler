using MediatR;
using MedScheduler.Application.Dtos;
using MedScheduler.Application.Interfaces;
using MedScheduler.Domain.Entities;
using MedScheduler.Domain.Enums;
using MedScheduler.Domain.Interfaces;

namespace MedScheduler.Application.Commands.Handlers
{
    public class RegisterCommandHandler(
        IUserRepository _userRepository,
        IUserService _userService) : IRequestHandler<RegisterCommand, AuthResponseDto> 
    {
        public async Task<AuthResponseDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var userExist = await _userRepository.GetUserByEmailAsync(request.Email);
            if (userExist != null)
            {
                throw new Exception("User already exists");
            }

            var hashedPassword = _userService.HashPassword(request.Password);
            
            var user = User.Create(
                request.Name,
                request.Email,
                hashedPassword,
                (UserEnum)request.Role,
                request.specialityId);


            await _userRepository.AddUserAsync(user);

            return new AuthResponseDto
            {
                Token = "GeneratedToken",
                Role = user.Role.ToString(),
                UserId = user.Id,
                Name = user.Name
            };
        }

    }
}
