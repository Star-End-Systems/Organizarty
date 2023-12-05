using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Application.Exceptions;
using Organizarty.Application.App.DecorationInfos.UseCases;
using Organizarty.Application.App.DecorationInfos.Entities;
using Organizarty.UI.Attributes;
using Organizarty.Adapters;

namespace Organizarty.UI.Pages.Manager.Decorations;

[Authorized("/Manager/Accounts/Login", UserType.Mannager)]
public class EditDecorationItemModel : PageModel
{
    private readonly EditDecorationItemUseCase _editDecoration;
    private readonly SelectDecorationItemUseCase _selectDecoration;

    public EditDecorationItemModel(EditDecorationItemUseCase editDecoration, SelectDecorationItemUseCase selectDecoration)
    {
        _editDecoration = editDecoration;
        _selectDecoration = selectDecoration;
    }

    [BindProperty]
    public DecorationInfo Input { get; set; } = new();

    public async Task OnGetAsync(Guid decorationId)
    {
        try
        {
            Input = await _selectDecoration.FinbById(decorationId);
        }
        catch (Exception)
        {

        }

    }

    public async Task<IActionResult> OnPostAsync(Guid decorationId)
    {
        var data = new EditDecorationItemDto(decorationId, Input.Color, Input.Material, Input.IsAvaible, Input.Price, Input.TextureURL);

        try
        {
            await _editDecoration.Execute(data);
            return RedirectToPage("/Manager/Decorations/Index");
        }
        catch (ValidationFailException e)
        {
            foreach (var err in e.Errors)
            {
                ModelState.AddModelError(string.Empty, err.message);
            }

            return Page();
        } catch(Exception e){
             ModelState.AddModelError(string.Empty, e.Message);

             return Page();
        }
    }
}
