namespace Organizarty.Adapters;

public enum UserType{
    Client,
    ThirdParty,
    Mannager
}

public interface ITokenProvider
{
    string GenerateToken(string userId, string username, UserType userType);
}
