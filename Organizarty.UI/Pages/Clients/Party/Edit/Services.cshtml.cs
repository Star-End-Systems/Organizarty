using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Adapters;
using Organizarty.Application.App.Party.UseCases;
using Organizarty.Application.Exceptions;
using Organizarty.UI.Attributes;
namespace Organizarty.UI.Pages.Clients.Party.Edit;

[Authorized("/Clients/Accounts/Login", UserType.Client)]
public class EditServiceGroupModel : PageModel
{
    private readonly ILogger<EditServiceGroupModel> _logger;
    private readonly SelectPartyUseCase _selectParty;
    private readonly EditPartyUseCase _editParty;

    public EditServiceGroupModel(ILogger<EditServiceGroupModel> logger, SelectPartyUseCase selectParty, EditPartyUseCase editParty)
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
    }

    public async Task<IActionResult> OnGetAsync(Guid itemid)
    {
        var item = await _selectParty.FindService(itemid);

        if (item is null)
        {
            // TODO:Change to not found page.
            return Redirect("/");
        }

        Item.Note = item.Note;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(Guid itemid)
    {
        try
        {
            var item = await _editParty.EditService(new(itemid, Item.Note ?? ""));
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
            ModelState.AddModelError(string.Empty, "Erro ao editar serviço, tente novamente mais tarde.");
            await OnGetAsync(itemid);
            return Page();
        }
    }
}
