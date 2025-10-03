
using FlexiSchedule.Application.Models.DTOs.Filters;
using FlexiSchedule.Application.Services.Client.ReadOnly;
using FlexiSchedule.CrossCutting.Models;

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
        [FromQuery] int pageSize = 5,
        [FromQuery] ClientFilter? filter = null)
    {
        var clients = clientReadOnlyService.GetAll(professionalId, pageNumber, pageSize, filter);

        return Ok(clients);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(
        [FromServices] IClientReadOnlyService clientReadOnlyService,
        [FromRoute] Guid id)
    {
        var client = await clientReadOnlyService.GetByIdAsync(id, CancellationToken.None);

        return Ok(client);
    }
}
