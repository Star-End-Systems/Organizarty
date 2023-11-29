using Microsoft.AspNetCore.Mvc;
using Organizarty.Adapters;
using Organizarty.Application.App.Users.UseCases;

namespace Organizarty.UI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    public record UserCreateResponse(string Email);
    public record UserLoginResponse(Guid id, string Email, string Fullname, string Username, string Token);

    private readonly ILogger<UserController> _logger;
    private readonly RegisterUserUseCase _registerUser;
    private readonly LoginUserUseCase _loginUser;
    private readonly ITokenProvider _tokenProvider;

    public UserController(ILogger<UserController> logger, RegisterUserUseCase registerUser, LoginUserUseCase loginUser, ITokenProvider tokenProvider)
    {
        _logger = logger;
        _registerUser = registerUser;
        _loginUser = loginUser;
        _tokenProvider = tokenProvider;
    }

    [HttpPost("Login")]
    public async Task<ActionResult<UserLoginResponse>> Login(LoginUserDto userDto)
    {
        var user = await _loginUser.Execute(userDto);
        var token = _tokenProvider.GenerateToken(user.Id.ToString(), user.UserName, UserType.Client);

        return Ok(new UserLoginResponse(user.Id, user.Email, user.Fullname, user.UserName, token));
    }

    [HttpPost("Register")]
    public async Task<ActionResult<UserCreateResponse>> Register(RegisterUserDto userDto)
    {
        var user = await _registerUser.Execute(userDto);

        return Ok(new UserCreateResponse(user.Email));
    }
}
