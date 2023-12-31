using Microsoft.AspNetCore.Mvc;
using Organizarty.Adapters;
using Organizarty.Application.App.Users.UseCases;

namespace Organizarty.UI.Controllers.Users;

public partial class UserController
{
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
