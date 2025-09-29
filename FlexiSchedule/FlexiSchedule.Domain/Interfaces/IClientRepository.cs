namespace FlexiSchedule.Domain.Interfaces;
public interface IClientRepository
{
    Task AddAsync(Client client, CancellationToken cancellationToken);
    Task<bool> ExistsByEmail(string email, CancellationToken cancellationToken);
    IQueryable<Client> GetAll();
    Task<IQueryable<Client>> GetAllAsync(Guid professionalId, CancellationToken cancellationToken);
    Task<Client?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}
