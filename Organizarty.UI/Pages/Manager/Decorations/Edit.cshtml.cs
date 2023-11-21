using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Application.App.DecorationTypes.UseCases;
using Organizarty.Application.App.DecorationTypes.Entities;
using Organizarty.Application.Exceptions;
using System.ComponentModel.DataAnnotations;
namespace Organizarty.UI.Pages.Manager;

public class EditDecorationModel : PageModel
{
    private readonly ILogger<EditDecorationModel> _logger;

    private readonly EditDecorationUseCase _editDecoration;
    private readonly SelectDecorationTypeUseCase _selectDecoration;

    public EditDecorationModel(ILogger<EditDecorationModel> logger, EditDecorationUseCase editDecoration, SelectDecorationTypeUseCase selectDecoration)
    {
        _logger = logger;
        _editDecoration = editDecoration;
        _selectDecoration = selectDecoration;
    }

    [BindProperty]

    public DecorationType Input { get; set; } = new();

    public async Task OnGetAsync(Guid decorationId)
    {
        try
        {
            Input  = await _selectDecoration.FindById(decorationId);

        }
        catch (Exception e)
        {
          _logger.LogError(e.ToString());
        }
    }

    public async Task<IActionResult> OnPostAsync(Guid decorationId)
    {
        var data = new EditDecorationDto(decorationId, Input.Name, Input.Description, Input.Size, Input.Model, "https://www.google.com");

        try
        {
            await _editDecoration.Execute(data);
            return RedirectToPage("./Index");
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
