namespace FlexiSchedule.Domain.Interfaces;
public interface IAddressRepository
{
    Task AddAsync(Address address, CancellationToken cancellationToken);
    Task<Address?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<Address>> GetAllAsync(CancellationToken cancellationToken);
    Task UpdateAsync(Address address, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}
