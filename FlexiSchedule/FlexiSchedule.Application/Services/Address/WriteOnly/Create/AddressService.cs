namespace FlexiSchedule.Application.Services.Address.WriteOnly.Create;
public class AddressService(IUnitOfWork unitOfWork) : IAddressService
{
    public async Task<Guid> CreateAddressAsync(AddressDTO dTO, Guid clientId, CancellationToken cancellationToken)
    {
        var address = dTO.ToEntity(clientId);

        await unitOfWork.Addresses.AddAsync(address, cancellationToken);

        await unitOfWork.CommitAsync(cancellationToken);

        return address.Id;
    }
}
