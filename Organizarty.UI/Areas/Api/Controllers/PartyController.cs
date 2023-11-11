using Microsoft.AspNetCore.Mvc;

namespace Organizarty.UI.Areas.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PartyController : ControllerBase
{
    private readonly ILogger<PartyController> _logger;

    public PartyController(ILogger<PartyController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    => Ok("morte");
}
