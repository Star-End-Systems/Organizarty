using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Adapters;
using Organizarty.Application.App.DecorationTypes.Entities;
using Organizarty.Application.App.DecorationTypes.UseCases;
using Organizarty.UI.Attributes;

namespace Organizarty.UI.Pages.Manager.Decorations;

[Authorized("/Manager/Accounts/Login", UserType.Mannager)]
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    private readonly SelectDecorationTypeUseCase _selectDecoration;

    public IndexModel(ILogger<IndexModel> logger, SelectDecorationTypeUseCase selectDecoration)
    {
        _selectDecoration = selectDecoration;
        _logger = logger;
    }

    public List<DecorationType> Decorations { get; set; } = new();

    public async Task OnGetAsync()
    {
        try
        {
            Decorations = await _selectDecoration.All();
        }
        catch (Exception)
        {

        }
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        return RedirectToPage("");
    }
}
