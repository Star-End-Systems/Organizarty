using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TP = Organizarty.Application.App.ThirdParties.Entities.ThirdParty;
using Organizarty.UI.Helpers;
using Organizarty.Application.Exceptions;
using Organizarty.Application.App.DecorationInfos.UseCases;

namespace Organizarty.UI.Pages.Manager.Decorations;

public class NewDecorationSubitemModel : PageModel
{
    private readonly CreateDecorationInfoUseCase _createDecoration;
    private readonly AuthenticationHelper _authHelper;

    public TP ThirdParty { get; set; } = new();

    public NewDecorationSubitemModel(CreateDecorationInfoUseCase createDecoration, AuthenticationHelper authHelper)
    {
        _createDecoration = createDecoration;
        _authHelper = authHelper;
    }

    [BindProperty]
    public InputModel Input { get; set; } = new();

    public class InputModel
    {
        [Required]
        public decimal Price { get; set; } = default!;

        public bool IsAvaible { get; set; } = default!;

        [Required]
        public string Color { get; set; } = default!;

        [Required]
        public string Material { get; set; } = default!;

        [Required]
        public string TextureURL { get; set; } = default!;
    }

    public async Task<IActionResult> OnPostAsync(Guid decorationId)
    {
        var data = new CreateDecorationInfoDto(Input.Color, Input.Material, Input.IsAvaible, Input.Price, Input.TextureURL, decorationId);

        try
        {
            await _createDecoration.Execute(data);
            return RedirectToPage("/Manager/Decorations/Index");
        }
        catch (ValidationFailException e)
        {
            foreach (var err in e.Errors)
            {
                ModelState.AddModelError(string.Empty, err.message);
            }

            return Page();
        }
    }
}
