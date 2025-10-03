using FlexiSchedule.Application.Models.InputModels.Client;

namespace FlexiSchedule.Application.Services.Client.WriteOnly.Create;
public class CreateClientService(IUnitOfWork unitOfWork, IAddressService addressService) : ICreateClientService
{
    public async Task<Guid> CreateAsync(CreateClientInputModel model, CancellationToken cancellationToken)
    {
        await RulesValidation(model, cancellationToken);

        var client = model.ToEntity();

        await unitOfWork.Clients.AddAsync(client, cancellationToken);

        foreach (var addressDto in model.Adresses)
        {
            await addressService.CreateAddressAsync(addressDto, client.Id, cancellationToken);
        }

        await unitOfWork.CommitAsync(cancellationToken);
        return client.Id;
    }

    private async Task RulesValidation(CreateClientInputModel model, CancellationToken cancellationToken)
    {
        bool existsProfessional = await unitOfWork.Professionals.ExistsAsync(model.ProfessionalId, cancellationToken);

        if (!existsProfessional)
            throw new NotFoundException(nameof(Domain.Entities.Professional), model.ProfessionalId);

        bool existsClient = await unitOfWork.Clients.ExistsByEmail(model.Email, cancellationToken);

        if (existsClient)
            throw new AlreadyExistsException(nameof(Domain.Entities.Client), model.Email);
    }
}
