namespace Organizarty.Adapters;

public interface ITokenProvider
{
    string GenerateToken(string userId, string username);
}
