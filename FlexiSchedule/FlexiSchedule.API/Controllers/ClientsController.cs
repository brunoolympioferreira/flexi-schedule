
using FlexiSchedule.Application.Services.Client.ReadOnly;

namespace FlexiSchedule.API.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ClientsController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromServices] ICreateClientService clientService, 
        [FromBody] CreateClientInputModel model)
    {
        var clientId = await clientService.CreateAsync(model, CancellationToken.None);

        return CreatedAtAction(nameof(Create), new { id = clientId }, null);
    }

    [HttpGet("professional/{professionalId:guid}")]
    public  IActionResult GetAllByProfessionalId(
        [FromServices] IClientReadOnlyService clientReadOnlyService,
        [FromRoute] Guid professionalId, 
        [FromQuery] int pageNumber = 1, 
        [FromQuery] int pageSize = 5)
    {
        var clients = clientReadOnlyService.GetAll(professionalId, pageNumber, pageSize);

        return Ok(clients);
    }
}
