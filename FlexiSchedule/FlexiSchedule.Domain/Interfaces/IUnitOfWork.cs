namespace FlexiSchedule.Domain.Interfaces;
public interface IUnitOfWork : IDisposable
{
    IProfessionalRepository Professionals { get; }
    IRefreshTokenRepository RefreshTokens { get; }

    Task<int> CommitAsync(CancellationToken cancellationToken = default);
}
