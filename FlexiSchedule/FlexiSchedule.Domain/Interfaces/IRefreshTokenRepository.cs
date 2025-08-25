namespace FlexiSchedule.Domain.Interfaces;
public interface IRefreshTokenRepository
{
    Task<RefreshToken?> GetByTokenAsync(string token, CancellationToken cancellationToken = default);
    Task<List<RefreshToken>> GetByProfessionalIdAsync(Guid prefessionalId, CancellationToken cancellationToken = default);
    Task<List<RefreshToken>> GetExpiredTokensAsync(CancellationToken cancellationToken = default);
    Task<List<RefreshToken>> GetActiveTokensByProfessionalIdAsync(Guid professionalId, CancellationToken cancellationToken = default);
    Task AddAsync(RefreshToken refreshToken, CancellationToken cancellationToken = default);
    Task UpdateAsync(RefreshToken refreshToken);
    Task DeleteAsync(RefreshToken refreshToken);
    Task DeleteRangeAsync(IEnumerable<RefreshToken> refreshTokens);
}
