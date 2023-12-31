using Microsoft.AspNetCore.Mvc;
using Organizarty.Adapters;
using Organizarty.Application.App.Users.UseCases;

namespace Organizarty.UI.Controllers.Users;

[ApiController]
[Route("api/[controller]")]
public partial class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly ITokenProvider _tokenProvider;

    private readonly RegisterUserUseCase _registerUser;
    private readonly LoginUserUseCase _loginUser;
    private readonly ConfirmCodeUseCase _confirmCode;
    private readonly SendEmailConfirmUseCase _sendConfirmationCode;

    public UserController(ILogger<UserController> logger, RegisterUserUseCase registerUser, LoginUserUseCase loginUser, ITokenProvider tokenProvider, ConfirmCodeUseCase confirmCode, SendEmailConfirmUseCase sendConfirmationCode)
    {
        _logger = logger;
        _registerUser = registerUser;
        _loginUser = loginUser;
        _tokenProvider = tokenProvider;
        _confirmCode = confirmCode;
        _sendConfirmationCode = sendConfirmationCode;
    }
}
