using System.Text;
using Organizarty.Adapters;

namespace Organizarty.Tests.Mock.Adapters;

public class CryptographyMock : ICryptographys
{
    public byte[] GenenateSalt()
    => Encoding.UTF8.GetBytes(Guid.NewGuid().ToString());

    public (string HashedPassword, string Salt) Hash(string password, byte[] salt)
    {
        var strSalt = Convert.ToBase64String(salt);
        var pass = password + strSalt;

        return (pass, strSalt);
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
