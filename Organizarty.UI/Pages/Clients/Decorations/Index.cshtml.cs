using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Application.App.DecorationTypes.UseCases;
using Organizarty.Application.App.DecorationTypes.Entities;
using System.ComponentModel.DataAnnotations;

namespace Organizarty.UI.Pages.Clients.Decorations;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly SelectDecorationTypeUseCase _selectDecoration;

    public List<DecorationType> Decorations = new();

    public IndexModel(ILogger<IndexModel> logger, SelectDecorationTypeUseCase selectDecoration)
    {
        _selectDecoration = selectDecoration;
        _logger = logger;
    }

    public InputModel Input { get; set; } = default!;

    public class InputModel
    {
        [Display(Name = "Search")]
        public string Search { get; set; } = default!;
    }

    public async Task OnGetAsync()
    {
        Decorations = await _selectDecoration.GetAllAvaible();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        return RedirectToPage("", new { search = Input.Search });
    }
}
