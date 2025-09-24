namespace FlexiSchedule.Infrastructure.Persistence.Repositories;
public class ClientRepository(FlexiScheduleSQLServerDbContext dbContext) : IClientRepository
{
    public async Task AddAsync(Client client, CancellationToken cancellationToken)
    {
        await dbContext.Clients.AddAsync(client, cancellationToken);
    }

    public async Task<bool> ExistsByEmail(string email, CancellationToken cancellationToken)
    {
        bool exists = await dbContext.Clients
            .AsNoTracking()
            .AnyAsync(c => c.Email.Equals(email), cancellationToken);

        return exists;
    }

    public IQueryable<Client> GetAll()
        => dbContext.Clients.AsNoTracking();
}
