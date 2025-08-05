namespace FlexiSchedule.Infrastructure.Persistence.UnityOfWork;
public interface IUnitOfWork : IDisposable
{
    IProfessionalRepository Professionals { get; }

    Task<int> CommitAsync(CancellationToken cancellationToken = default);
}
