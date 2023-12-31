using Microsoft.AspNetCore.Mvc;

namespace Organizarty.UI.Controllers.Users;

public partial class UserController
{
    [HttpPost("re-sent-confirmation")]
    public async Task<IActionResult> ResendConfirmation(ReSendEmailConfirmationRequest request)
    {
        await _sendConfirmationCode.Execute(request.Email);

        return Ok("Check your email");
    }

    [HttpPost("confirm-code")]
    public async Task<IActionResult> ConfirmCode(ConfirmCodeRequest request)
    {
        await _confirmCode.Execute(request.code, request.Email);

        return Ok("Email confirmed");
    }

}
