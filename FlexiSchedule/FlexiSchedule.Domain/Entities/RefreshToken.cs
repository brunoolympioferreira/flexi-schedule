namespace FlexiSchedule.Domain.Entities;
public class RefreshToken : BaseEntity
{
    public string Token { get; private set; }
    public DateTime ExpireAt { get; private set; }
    public DateTime? RevokedAt { get; private set; }
    public bool IsExpired => DateTime.UtcNow >= ExpireAt;
    public bool IsRevoked => RevokedAt != null;
    public bool IsActive => !IsRevoked && !IsExpired;
    public Guid ProfessionalId { get; private set; }
    public Professional Professional { get; set; } = null!;


    public RefreshToken(string token, DateTime expireAt, DateTime? revokedAt, Guid professionalId)
    {
        Token = token;
        ExpireAt = expireAt;
        RevokedAt = revokedAt;
        ProfessionalId = professionalId;
    }

    public static void Revoke(RefreshToken refreshToken) => refreshToken.RevokedAt = DateTime.UtcNow;
}
