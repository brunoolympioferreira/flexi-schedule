namespace FlexiSchedule.Domain.Interfaces;
public interface IUnitOfWork : IDisposable
{
    IProfessionalRepository Professionals { get; }
    IRefreshTokenRepository RefreshTokens { get; }
    IAddressRepository Addresses { get; }
    IClientRepository Clients { get; }
    IAvailabilityRepository Availabilities { get; }

    Task<int> CommitAsync(CancellationToken cancellationToken = default);
}
