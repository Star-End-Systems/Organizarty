using Microsoft.AspNetCore.Mvc;
using Organizarty.Adapters;

namespace Organizarty.UI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SendEmailController : ControllerBase
{
    private readonly ILogger<SendEmailController> _logger;
    private readonly IEmailSender _mailSender;

    public SendEmailController(ILogger<SendEmailController> logger, IEmailSender mailSender)
    {
        _logger = logger;
        _mailSender = mailSender;
    }

    [HttpGet("SendEmail")]
    public async Task<IActionResult> Login(string code, string email)
    {
        await _mailSender.SendEmailVerificationCode(code, email);
        return Ok("Email enviado com sucesso");
    }
}
