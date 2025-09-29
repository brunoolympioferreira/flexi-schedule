using FlexiSchedule.Application.Services.Cache;
using FlexiSchedule.Domain.Entities;

namespace FlexiSchedule.Infrastructure.Persistence.Repositories;
public class ClientRepository(FlexiScheduleSQLServerDbContext dbContext, ICacheService cache) : IClientRepository
{
    private const string CacheKeyPrefix = "Client_";
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

    public async Task<IQueryable<Client>> GetAllAsync(Guid professionalId, CancellationToken cancellationToken)
    {
        var cacheKey = $"{CacheKeyPrefix}All";
        var cached = await cache.GetAsync<List<Client>>(cacheKey, cancellationToken);

        if (cached != null)
            return cached.AsQueryable();

        var clients = await dbContext.Clients
            .Where(c => c.ProfessionalId == professionalId)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        await cache.SetAsync(cacheKey, clients, TimeSpan.FromMinutes(10), cancellationToken);

        return clients.AsQueryable();
    }

    public async Task<Client?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var cachekey = $"{CacheKeyPrefix}{id}";
        var cached = await cache.GetAsync<Client>(cachekey, cancellationToken);

        if (cached is not null)
            return cached;

        var client = await dbContext.Clients
            .Include(p => p.Addresses)
            .Include(p => p.Professional)
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

        if (client != null)
        {
            await cache.SetAsync(cachekey, client, TimeSpan.FromHours(1), cancellationToken);
        }

        return client;
    }
}
