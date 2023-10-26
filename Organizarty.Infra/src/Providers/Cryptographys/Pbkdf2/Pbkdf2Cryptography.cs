using System.Security.Cryptography;

using Organizarty.Adapters;

namespace Organizarty.Infra.Providers.Cryptography.Pbkdf2;

public class Pbkdf2Cryptography : ICryptographys
{
    private readonly int SALT_LENGTH = 16;
    private readonly int INTERATIONS = 10000;

    public byte[] GenenateSalt()
    {
        byte[] salt = new byte[SALT_LENGTH];

        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
            return salt;
        }
    }

    public (string HashedPassword, string Salt) Hash(string password, byte[] salt)
    {
        using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, INTERATIONS, HashAlgorithmName.SHA256))
        {
            byte[] hashedPassword = pbkdf2.GetBytes(32); // 256 bits
            return (Convert.ToBase64String(hashedPassword), Convert.ToBase64String(salt));
        }
    }

    public (string HashedPassword, string Salt) HashPassword(string password)
      => Hash(password, GenenateSalt());

    public bool VerifyPassword(string password, string storedHashedPassword, string storedSalt)
    {
        byte[] saltBytes = Convert.FromBase64String(storedSalt);
        var hashedPassword = Hash(password, saltBytes).HashedPassword;

        return hashedPassword == storedHashedPassword;
    }
}
