namespace FlexiSchedule.Application.Services.Address.WriteOnly.Create;
public interface IAddressService
{
    Task<Guid> CreateAddressAsync(AddressDTO dTO,Guid clientId, CancellationToken cancellationToken);
}
