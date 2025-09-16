using FlexiSchedule.Application.Services.Address.WriteOnly.Create;

namespace FlexiSchedule.Application.Services.Client.WriteOnly.Create;
public class CreateClientService(IUnitOfWork unitOfWork, IAddressService addressService) : ICreateClientService
{
    public async Task<Guid> CreateAsync(CreateClientInputModel model, CancellationToken cancellationToken)
    {
        var client = model.ToEntity();

        await unitOfWork.Clients.AddAsync(client, cancellationToken);
        await unitOfWork.CommitAsync(cancellationToken);

        foreach (var addressDto in model.Adresses)
        {
            await addressService.CreateAddressAsync(addressDto, client.Id, cancellationToken);
        }

        return client.Id;
    }
}
