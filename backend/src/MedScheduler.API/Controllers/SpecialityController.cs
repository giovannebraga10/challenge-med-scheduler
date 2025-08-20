using MediatR;
using MedScheduler.Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace challenge_med_scheduler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialityController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllSpecialities()
        {
            try
            {
                var query = new GetAllSpecialitiesQuery();
                var specialities = await _mediator.Send(query);
                return Ok(specialities);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
