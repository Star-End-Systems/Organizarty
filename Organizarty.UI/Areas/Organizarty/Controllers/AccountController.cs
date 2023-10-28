using Microsoft.AspNetCore.Mvc;

namespace Organizarty.UI.Areas.Organizarty.Controllers;

[Area("Organizarty")]
public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;

    public AccountController(ILogger<AccountController> logger)
    {
        _logger = logger;
    }

    public async Task<IActionResult> Login()
    {
        return View();
    }

    public async Task<IActionResult> Register()
    {
        return View();
    }
}
