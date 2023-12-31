namespace Organizarty.UI.Controllers.Users;

public record UserCreateResponse(string Email);

public record UserLoginResponse(string id, string Email, string Fullname, string Username, string Token);

public record ReSendEmailConfirmationRequest(string Email);

public record ConfirmCodeRequest(string Email, string code);
