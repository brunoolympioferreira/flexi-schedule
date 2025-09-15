namespace FlexiSchedule.Infrastructure.Persistence.Repositories;
public class ClientRepository(FlexiScheduleSQLServerDbContext dbContext) : IClientRepository
{
    public async Task AddAsync(Client client, CancellationToken cancellationToken)
    {
        await dbContext.Clients.AddAsync(client, cancellationToken);
    }
}
