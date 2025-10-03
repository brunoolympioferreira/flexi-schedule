using FlexiSchedule.Application.Models.InputModels.Client;

namespace FlexiSchedule.Application.Services.Client.WriteOnly.Create;
public interface ICreateClientService
{
    Task<Guid> CreateAsync(CreateClientInputModel model, CancellationToken cancellationToken);
}
