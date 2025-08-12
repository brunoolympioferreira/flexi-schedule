namespace FlexiSchedule.CrossCutting.Utils;
public static class PasswordHasher
{
    public static string HashPassword(string password)
    {
        var hashedBytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));

        var hash = new StringBuilder();
        foreach (var b in hashedBytes)
            hash.Append(b.ToString("x2"));

        return hash.ToString();
    }
}
