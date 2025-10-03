using FlexiSchedule.Application.Models.InputModels.Auth;

namespace FlexiSchedule.Application.Services.Authentication;
public interface IAuthService
{
    Task<AuthResponseViewModel> LoginAsync(LoginInputModel model, CancellationToken cancellationToken = default);
    Task<AuthResponseViewModel> RefreshTokenAsync(RefreshTokenInputModel model, CancellationToken cancellationToken = default);
    Task RevokeRefreshTokenAsync(string token, CancellationToken cancellationToken = default);
    Task RevokeAllRefreshTokenAsync(Guid professionalId, CancellationToken cancellationToken = default);
    Task CleanExpiredTokenAsync(CancellationToken cancellationToken = default);
}
