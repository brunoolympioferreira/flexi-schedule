namespace FlexiSchedule.Domain.Interfaces;
public interface IClientRepository
{
    Task AddAsync(Client client, CancellationToken cancellationToken);
}
