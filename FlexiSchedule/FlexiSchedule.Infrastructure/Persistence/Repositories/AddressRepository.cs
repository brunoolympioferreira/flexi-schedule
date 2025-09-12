namespace FlexiSchedule.Infrastructure.Persistence.Repositories;
public class AddressRepository(FlexiScheduleSQLServerDbContext dbContext) : IAddressRepository
{
    public async Task AddAsync(Address address, CancellationToken cancellationToken)
    {
        await dbContext.AddAsync(address, cancellationToken);
    }

    public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Address>> GetAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Address?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Address address, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
