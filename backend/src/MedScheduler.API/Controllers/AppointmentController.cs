using MediatR;
using MedScheduler.Application.Commands;
using MedScheduler.Application.Dtos;
using MedScheduler.Application.Queries;
using MedScheduler.Application.Queries.Dtos;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class AppointmentController : ControllerBase
{
    private readonly IMediator _mediator;

    public AppointmentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("triage")]
    public async Task<IActionResult> Triage([FromBody] TriageRequestDto dto)
    {
        var query = new TriageQuery(dto.Symtoms, dto.AppointmentDate);
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAppointment([FromBody] CreateAppointmentDto dto)
    {
        try
        {
            var command = new CreateAppointmentCommand
            {
                AppointmentDate = dto.AppointmentDate,
                PatientId = dto.PatientId,
                DoctorId = dto.DoctorId,
                Speciality = dto.Speciality,
                Symtoms = dto.Symtoms
            };
            var appointmentId = await _mediator.Send(command);
            return CreatedAtAction(nameof(CreateAppointment), new { id = appointmentId }, null);
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }

    [HttpPost("cancel")]
    public async Task<IActionResult> CancelAppointment([FromBody] CancelAppointmentDto dto)
    {
        try
        {
            var command = new CancelAppointmentCommand(dto.AppointmentId);
            var result = await _mediator.Send(command);
            if (result)
            {
                return Ok(new { Message = "Appointment cancelled successfully." });
            }
            return NotFound(new { Message = "Appointment not found." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }

    [HttpGet("my-appointments-by-date")]
    public async Task<IActionResult> GetAppointmentsByDate([FromQuery] DateTime appointmentDate)
    {
        try
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
            if (string.IsNullOrEmpty(userIdClaim))
                return Unauthorized();

            var userId = Guid.Parse(userIdClaim);

            var query = new GetAppointmentsByUserIdAndDateQuery(userId, appointmentDate);
            var appointments = await _mediator.Send(query);

            return Ok(appointments);
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }
}
