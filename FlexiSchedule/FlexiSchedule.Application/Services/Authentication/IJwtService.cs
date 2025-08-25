namespace FlexiSchedule.Application.Services.Authentication;
public interface IJwtService
{
    string GenerateAccessToken(Domain.Entities.Professional professional);
    string GenerateRefreshToken();
    ClaimsPrincipal? GetPrincipalFromToken(string token);
    RefreshToken CreateRefreshTokenForProfessional(Guid professionalId);
}
