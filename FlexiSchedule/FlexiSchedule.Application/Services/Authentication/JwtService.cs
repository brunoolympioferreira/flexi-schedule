namespace FlexiSchedule.Application.Services.Authentication;
public class JwtService(
    IConfiguration configuration,
    ILogger<JwtService> logger)
    : IJwtService
{
    public string GenerateAccessToken(Domain.Entities.Professional professional)
    {
        var isDocker = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("DB_HOST"));

        var jwtKey = isDocker
            ? Environment.GetEnvironmentVariable("JWT_KEY") ?? throw new InternalServerException("JWT_KEY is not set in environment variables.")
            : configuration["Jwt:Key"] ?? throw new InternalServerException("JWT Key is not set in configuration.");

        var jwtIssuer = isDocker
            ? Environment.GetEnvironmentVariable("JWT_ISSUER") ?? throw new InternalServerException("JWT_ISSUER is not set in environment variables.")
            : configuration["Jwt:Issuer"] ?? throw new InternalServerException("JWT Issuer is not set in configuration.");

        var jwtAudience = isDocker
            ? Environment.GetEnvironmentVariable("JWT_AUDIENCE") ?? throw new InternalServerException("JWT_AUDIENCE is not set in environment variables.")
            : configuration["Jwt:Audience"] ?? throw new InternalServerException("JWT Audience is not set in configuration.");

        var accessTokenExpiry = isDocker
            ? int.TryParse(Environment.GetEnvironmentVariable("JWT_ACCESS_TOKEN_EXPIRY_MINUTES"), out var envMinutes) ? envMinutes : 15
            : int.TryParse(configuration["Jwt:AccessTokenExpiryMinutes"], out var configMinutes) ? configMinutes : 15;

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        List<Claim> claims =
        [
            new Claim(ClaimTypes.NameIdentifier, professional.Id.ToString()),
            new Claim(ClaimTypes.Name, professional.Name),
            new Claim(ClaimTypes.Email, professional.Email),
            new Claim("jti", Guid.NewGuid().ToString())
        ];

        var token = new JwtSecurityToken(
            issuer: jwtIssuer,
            audience: jwtAudience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(accessTokenExpiry),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public string GenerateRefreshToken()
    {
        var randomNumber = new byte[64];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    public ClaimsPrincipal? GetPrincipalFromToken(string token)
    {
        try
        {
            var isDocker = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("DB_HOST"));

            var jwtKey = isDocker
                ? Environment.GetEnvironmentVariable("JWT_KEY") ?? throw new InvalidOperationException("JWT_KEY is not set in environment variables.")
                : configuration["Jwt:Key"] ?? throw new InternalServerException("JWT Key is not set in configuration.");

            var jwtIssuer = isDocker
                ? Environment.GetEnvironmentVariable("JWT_ISSUER") ?? "FlexiScheduleSystem"
                : configuration["Jwt:Issuer"] ?? "FlexiScheduleSystem";

            var jwtAudience = isDocker
                ? Environment.GetEnvironmentVariable("JWT_AUDIENCE") ?? "FlexiScheduleSystem"
                : configuration["Jwt:Audience"] ?? "FlexiScheduleSystem";

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
                ValidateLifetime = false,
                ValidIssuer = jwtIssuer,
                ValidAudience = jwtAudience
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);

            if (validatedToken is not JwtSecurityToken jwtToken ||
                !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                return null;

            return principal;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error validating token");
            return null;
        }
    }

    public RefreshToken CreateRefreshTokenForProfessional(Guid professionalId)
    {
        return new RefreshToken(
            token: GenerateRefreshToken(),
            expireAt: DateTime.UtcNow.AddDays(30),
            revokedAt: null,
            professionalId: professionalId
        );
    }
}
