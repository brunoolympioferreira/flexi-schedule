using FlexiSchedule.Application.Models.InputModels.Auth;

namespace FlexiSchedule.Application.Services.Authentication;
public class AuthService(
        IProfessionalReadOnlyService professionalReadOnlyService,
        IJwtService jwtService,
        IUnitOfWork unitOfWork,
        ILogger<AuthService> _logger
    ) : IAuthService
{
    public async Task<AuthResponseViewModel> LoginAsync(LoginInputModel model, CancellationToken cancellationToken = default)
    {
        var professional = await unitOfWork.Professionals.GetByEmailAsync(model.Email, cancellationToken);

        if (professional == null || !professionalReadOnlyService.VerifyPassword(model.Password, professional.PasswordHash))
        {
            throw new CrossCutting.Exceptions.UnauthorizedAccessException("Invalid email or password.");
        }

        var accessToken = jwtService.GenerateAccessToken(professional);
        var refreshToken = jwtService.CreateRefreshTokenForProfessional(professional.Id);

        await unitOfWork.RefreshTokens.AddAsync(refreshToken, cancellationToken);
        await unitOfWork.CommitAsync(cancellationToken);

        var accessTokenExpiry = DateTime.UtcNow.AddMinutes(15);
        var refreshTokenExpiry = refreshToken.ExpireAt;
        ProfessionalInfoDTO professionalInfoDTO = new (professional.Id, professional.Email);

        return new AuthResponseViewModel(accessToken, refreshToken.Token, accessTokenExpiry, refreshTokenExpiry, professionalInfoDTO);
    }

    public async Task<AuthResponseViewModel> RefreshTokenAsync(RefreshTokenInputModel model, CancellationToken cancellationToken = default)
    {
        var refreshToken = await unitOfWork.RefreshTokens.GetByTokenAsync(model.RefreshToken, cancellationToken);
        if (refreshToken == null || !refreshToken.IsActive)
        {
            throw new CrossCutting.Exceptions.UnauthorizedAccessException("Refresh token inválido ou expirado");
        }

        //Revoga o refresh token atual
        RefreshToken.Revoke(refreshToken);
        await unitOfWork.RefreshTokens.UpdateAsync(refreshToken, cancellationToken);

        //Gera novos tokens
        var newAccessToken = jwtService.GenerateAccessToken(refreshToken.Professional);
        var newRefreshToken = jwtService.CreateRefreshTokenForProfessional(refreshToken.ProfessionalId);

        await unitOfWork.CommitAsync(cancellationToken);

        var accessTokenExpiry = DateTime.UtcNow.AddMinutes(15);
        var refreshTokenExpiry = newRefreshToken.ExpireAt;
        ProfessionalInfoDTO professionalInfoDto = new(refreshToken.Professional.Id, refreshToken.Professional.Email);

        return new AuthResponseViewModel(newAccessToken, newRefreshToken.Token, accessTokenExpiry, refreshTokenExpiry, professionalInfoDto);
    }

    public async Task RevokeRefreshTokenAsync(string token, CancellationToken cancellationToken = default)
    {
        var refreshToken = await unitOfWork.RefreshTokens.GetByTokenAsync(token, cancellationToken);
        if (refreshToken != null && refreshToken.IsActive)
        {
            RefreshToken.Revoke(refreshToken);
            await unitOfWork.RefreshTokens.UpdateAsync(refreshToken, cancellationToken);
            await unitOfWork.CommitAsync(cancellationToken);
        }
    }

    public async Task RevokeAllRefreshTokenAsync(Guid professionalId, CancellationToken cancellationToken = default)
    {
        var activeTokens = await unitOfWork.RefreshTokens.GetActiveTokensByProfessionalIdAsync(professionalId, cancellationToken);
        foreach (var token in activeTokens)
        {
            RefreshToken.Revoke(token);
            await unitOfWork.RefreshTokens.UpdateAsync(token, cancellationToken);
        }

        await unitOfWork.CommitAsync(cancellationToken);
    }

    public async Task CleanExpiredTokenAsync(CancellationToken cancellationToken = default)
    {
        var expiredTokens = await unitOfWork.RefreshTokens.GetExpiredTokensAsync(cancellationToken);
        if (expiredTokens.Count != 0)
        {
            await unitOfWork.RefreshTokens.DeleteRangeAsync(expiredTokens, cancellationToken);
            await unitOfWork.CommitAsync(cancellationToken);
        }

        _logger.LogInformation($"Removed {expiredTokens.Count} expired refresh tokens");
    }
}
