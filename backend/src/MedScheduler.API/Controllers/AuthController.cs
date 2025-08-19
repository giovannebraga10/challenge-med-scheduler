using MediatR;
using Microsoft.AspNetCore.Mvc;
using MedScheduler.Application.Commands;
using MedScheduler.Application.Dtos;

namespace MedScheduler.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IMediator _mediator) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
        {
            try
            {
                var command = new LoginCommand(dto.Email, dto.Password);
                var response = await _mediator.Send(command);
                return Ok(response);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { Message = ex.Message });
            }
        }
    }
}
