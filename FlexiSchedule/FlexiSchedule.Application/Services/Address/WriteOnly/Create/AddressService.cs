namespace FlexiSchedule.Application.Services.Address.WriteOnly.Create;
public class AddressService(IUnitOfWork unitOfWork) : IAddressService
{
    public async Task<Guid> CreateAddressAsync(AddressDTO dTO, CancellationToken cancellationToken)
    {
        var address = dTO.ToEntity();

        await unitOfWork.Addresses.AddAsync(address, cancellationToken);

        await unitOfWork.CommitAsync(cancellationToken);

        return address.Id;
    }
}
