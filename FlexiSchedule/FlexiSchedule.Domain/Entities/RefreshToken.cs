namespace FlexiSchedule.Domain.Entities;
public class RefreshToken : BaseEntity
{
    public string Token { get; private set; }
    public DateTime ExpireAt { get; private set; }
    public DateTime? RevokedAt { get; private set; }
    public bool IsExpired { get; private set; }
    public bool IsRevoked { get; private set; }
    public bool IsActive { get; private set; }
    public Guid ProfessionalId { get; private set; }
    public Professional Professional { get; set; } = null!;


    public RefreshToken(string token, DateTime expireAt, DateTime? revokedAt, Guid professionalId)
    {
        Token = token;
        ExpireAt = expireAt;
        RevokedAt = revokedAt;
        IsExpired = DateTime.UtcNow >= ExpireAt;
        IsRevoked = RevokedAt != null;
        IsActive = !IsRevoked && !IsExpired;
        ProfessionalId = professionalId;
    }

    public static void Revoke(RefreshToken refreshToken) => refreshToken.RevokedAt = DateTime.UtcNow;
}
