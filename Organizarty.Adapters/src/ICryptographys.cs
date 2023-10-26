namespace Organizarty.Adapters;

public interface ICryptographys
{
    byte[] GenenateSalt();
    (string HashedPassword, string Salt) Hash(string password, byte[] salt);
    (string HashedPassword, string Salt) HashPassword(string password);
    bool VerifyPassword(string password, string storedHashedPassword, string storedSalt);
}
