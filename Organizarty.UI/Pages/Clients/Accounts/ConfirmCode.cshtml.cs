using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Application.App.Users.UseCases;
using Organizarty.UI.Attributes;

namespace Organizarty.UI.Pages.Clients.Accounts;

public class ConfirmCodeModel : PageModel
{
    private readonly ILogger<ConfirmCodeModel> _logger;
    private readonly ConfirmCodeUseCase _confirmCode;

    public ConfirmCodeModel(ILogger<ConfirmCodeModel> logger, ConfirmCodeUseCase confirmCode)
    {
        _logger = logger;
        _confirmCode = confirmCode;
    }

    public bool Success { get; set; } = false;

    public async Task OnGetAsync(Guid code)
    {
        try
        {
            await _confirmCode.Execute(code);

            Success = true;
        }
        catch (Exception e)
        {
            _logger.LogError(e.ToString());
            Success = false;
        }
    }
}
