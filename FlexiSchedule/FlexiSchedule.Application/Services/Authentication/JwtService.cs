using Microsoft.Extensions.Configuration;

namespace FlexiSchedule.Application.Services.Authentication;
public class JwtService(
    IConfiguration configuration
    ) 
    : IJwtService
{
    public Task CleanExpiredTokenAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<RefreshToken> CreateRefreshTokenAsync(Guid professionalId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public string GenerateAccessToken(Domain.Entities.Professional professional)
    {
        throw new NotImplementedException();
    }

    public string GenerateRefreshToken()
    {
        throw new NotImplementedException();
    }

    public ClaimsPrincipal? GetPrincipalFromToken(string token)
    {
        throw new NotImplementedException();
    }

    public Task<RefreshToken?> GetRefreshTokenAsync(string token, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task RevokeAllRefreshTokenAsync(Guid professionalId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
