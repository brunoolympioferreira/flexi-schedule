namespace FlexiSchedule.Infrastructure.Persistence.Repositories;
public class RefreshTokenRepository(FlexiScheduleSQLServerDbContext dbContext) : IRefreshTokenRepository
{
    public async Task<RefreshToken?> GetByTokenAsync(string token, CancellationToken cancellationToken = default)
    {
        return await dbContext.RefreshTokens
            .AsNoTracking()
            .FirstOrDefaultAsync(rt => rt.Token == token, cancellationToken);
    }

    public async Task<List<RefreshToken>> GetByProfessionalIdAsync(Guid prefessionalId, CancellationToken cancellationToken = default)
    {
        return await dbContext.RefreshTokens
            .AsNoTracking()
            .Where(rt => rt.ProfessionalId == prefessionalId)
            .ToListAsync(cancellationToken);
    }

    public async Task<List<RefreshToken>> GetExpiredTokensAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.RefreshTokens
            .AsNoTracking()
            .Where(rt => rt.ExpireAt <= DateTime.UtcNow)
            .ToListAsync(cancellationToken);
    }

    public async Task<List<RefreshToken>> GetActiveTokensByProfessionalIdAsync(Guid professionalId, CancellationToken cancellationToken = default)
    {
        return await dbContext.RefreshTokens
            .AsNoTracking()
            .Where(rt => rt.ProfessionalId == professionalId && rt.RevokedAt == null && rt.ExpireAt > DateTime.UtcNow)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(RefreshToken refreshToken, CancellationToken cancellationToken = default)
    {
        await dbContext.RefreshTokens.AddAsync(refreshToken, cancellationToken);
    }

    public Task UpdateAsync(RefreshToken refreshToken, CancellationToken cancellationToken = default)
    {
        dbContext.RefreshTokens.Update(refreshToken);

        return Task.CompletedTask;
    }

    public Task DeleteAsync(RefreshToken refreshToken, CancellationToken cancellationToken = default)
    {
        dbContext.RefreshTokens.Remove(refreshToken);

        return Task.CompletedTask;
    }

    public Task DeleteRangeAsync(IEnumerable<RefreshToken> refreshTokens, CancellationToken cancellationToken = default)
    {
        dbContext.RefreshTokens.RemoveRange(refreshTokens);

        return Task.CompletedTask;
    }
}
