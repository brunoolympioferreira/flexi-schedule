namespace FlexiSchedule.Application.Services.Authentication;
public interface IJwtService
{
    string GenerateAccessToken(Domain.Entities.Professional professional);
    string GenerateRefreshToken();
    ClaimsPrincipal? GetPrincipalFromToken(string token);
    Task<RefreshToken> CreateRefreshTokenAsync(Guid professionalId, CancellationToken cancellationToken = default);
    Task<RefreshToken?> GetRefreshTokenAsync(string token, CancellationToken cancellationToken = default);
    Task RevokeAllRefreshTokenAsync(Guid professionalId, CancellationToken cancellationToken = default);
    Task CleanExpiredTokenAsync(CancellationToken cancellationToken = default);
}
