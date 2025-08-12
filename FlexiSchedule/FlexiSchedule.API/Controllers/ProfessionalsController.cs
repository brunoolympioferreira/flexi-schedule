namespace FlexiSchedule.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProfessionalsController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromServices] ICreateProfessionalService service,
        [FromBody] ProfessionalInputModel inputModel, CancellationToken cancellationToken)
    {
        await service.CreateAsync(inputModel, cancellationToken);

        return Ok();
    }
}
