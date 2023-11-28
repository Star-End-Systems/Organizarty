using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Adapters;
using Organizarty.Application.App.Party.UseCases;
using Organizarty.Application.Exceptions;
using Organizarty.UI.Attributes;
namespace Organizarty.UI.Pages.Clients.Party.Edit;

[Authorized("/Clients/Accounts/Login", UserType.Client)]
public class EditProductGroupModel : PageModel
{
    private readonly ILogger<EditProductGroupModel> _logger;
    private readonly SelectPartyUseCase _selectParty;
    private readonly EditPartyUseCase _editParty;

    public EditProductGroupModel(ILogger<EditProductGroupModel> logger, SelectPartyUseCase selectParty, EditPartyUseCase editParty)
    {
        _logger = logger;
        _selectParty = selectParty;
        _editParty = editParty;
    }

    [BindProperty]
    public InputModel Item { get; set; } = new();

    public class InputModel
    {
        public string? Note { get; set; }
        public int Quantity { get; set; }
    }

    public async Task<IActionResult> OnGetAsync(Guid itemid)
    {
        var item = await _selectParty.FindFood(itemid);

        if (item is null)
        {
            return Redirect("/");
        }

        Item.Note = item.Note;
        Item.Quantity = item.Quantity;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(Guid itemid)
    {
        try
        {
            var item = await _editParty.EditFood(new(itemid, Item.Quantity, Item.Note ?? ""));
            return Redirect($"/Clients/Party/Detail/{item.PartyTemplateId}");
        }
        catch (ValidationFailException e)
        {
            e.Errors.ForEach(e => ModelState.AddModelError(string.Empty, e.message));
            await OnGetAsync(itemid);
            return Page();
        }
        catch (Exception e)
        {
            _logger.LogError(e.ToString());
            ModelState.AddModelError(string.Empty, "Erro ao editar produto, tente novamente mais tarde.");
            await OnGetAsync(itemid);
            return Page();
        }
    }
}
