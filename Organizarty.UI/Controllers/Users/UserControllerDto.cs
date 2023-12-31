namespace Organizarty.UI.Controllers.Users;

public record UserCreateResponse(string Email);

public record UserLoginResponse(Guid id, string Email, string Fullname, string Username, string Token);
