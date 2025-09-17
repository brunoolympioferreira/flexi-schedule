namespace FlexiSchedule.Application.Services.Client.WriteOnly.Create;
public class CreateClientService(IUnitOfWork unitOfWork, IAddressService addressService) : ICreateClientService
{
    public async Task<Guid> CreateAsync(CreateClientInputModel model, CancellationToken cancellationToken)
    {
        bool existsProfessional = await unitOfWork.Professionals.ExistsAsync(model.ProfessionalId, cancellationToken);

        if (!existsProfessional)
            throw new NotFoundException(nameof(Domain.Entities.Professional), model.ProfessionalId);

        var client = model.ToEntity();

        await unitOfWork.Clients.AddAsync(client, cancellationToken);

        foreach (var addressDto in model.Adresses)
        {
            await addressService.CreateAddressAsync(addressDto, client.Id, cancellationToken);
        }

        await unitOfWork.CommitAsync(cancellationToken);
        return client.Id;
    }
}
