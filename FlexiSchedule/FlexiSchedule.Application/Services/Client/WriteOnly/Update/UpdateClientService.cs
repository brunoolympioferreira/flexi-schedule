
namespace FlexiSchedule.Application.Services.Client.WriteOnly.Update;
public class UpdateClientService(IUnitOfWork unitOfWork) : IUpdateClientService
{
    public async Task UpdateClientAsync(Guid clientId, UpdateClientInputModel model, CancellationToken cancellationToken = default)
    {
        var client = await unitOfWork.Clients.GeyByIdTrackingAsync(clientId, cancellationToken);

        var addresses = model.Addresses
            .Select(address => address.ToEntity(clientId))
            .ToList();

        client?.Update(model.Email, model.Phone, addresses);
        if (client is null) throw new NotFoundException(nameof(Domain.Entities.Client), clientId);

        unitOfWork.Clients.Update(client);

        await unitOfWork.CommitAsync(cancellationToken);
    }
}
