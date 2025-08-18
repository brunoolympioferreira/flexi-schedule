using FlexiSchedule.Application.Services.Professional.WriteOnly.Update;

namespace FlexiSchedule.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProfessionalsController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromServices] ICreateProfessionalService service,
        [FromBody] ProfessionalCreateInputModel inputModel, CancellationToken cancellationToken)
    {
        await service.CreateAsync(inputModel, cancellationToken);

        return Ok();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        [FromServices] IUpdateProfessionalService service,
        [FromBody] ProfessionalUpdateInputModel inputModel, Guid id, CancellationToken cancellationToken)
    {
        await service.UpdateAsync(inputModel, id, cancellationToken);
        return NoContent();
    }
}
