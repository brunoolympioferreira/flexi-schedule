namespace FlexiSchedule.Domain.Interfaces;
public interface IUnitOfWork : IDisposable
{
    IProfessionalRepository Professionals { get; }

    Task<int> CommitAsync(CancellationToken cancellationToken = default);
}
