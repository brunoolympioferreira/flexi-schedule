namespace FlexiSchedule.Application.Services.Client.WriteOnly.Update;
public interface IUpdateClientService
{
    Task UpdateClientAsync(Guid clientId, UpdateClientInputModel model, CancellationToken cancellationToken = default);
}
