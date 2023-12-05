using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Adapters;
using Organizarty.Application.App.DecorationInfos.Entities;
using Organizarty.Application.App.DecorationInfos.UseCases;
using Organizarty.Application.App.Party.Entities;
using Organizarty.Application.App.Party.UseCases;
using Organizarty.Application.App.Users.Entities;
using Organizarty.UI.Attributes;
using Organizarty.UI.Helpers;
using System.ComponentModel.DataAnnotations;
namespace Organizarty.UI.Pages.Clients.Decorations;

[Authorized("/Clients/Accounts/Login", UserType.Client)]
public class DescriptionModel : PageModel
{
    private readonly ILogger<DescriptionModel> _logger;
    private readonly SelectDecorationItemUseCase _selectDecoration;
    private readonly AddDecorationToPartyUseCase _addDecoration;
    private readonly AuthenticationHelper _authHelper;
    private readonly SelectPartyUseCase _selectParty;

    public DescriptionModel(ILogger<DescriptionModel> logger, SelectDecorationItemUseCase selectDecoration, AddDecorationToPartyUseCase addDecoration, AuthenticationHelper authHelper, SelectPartyUseCase selectParty)
    {
        _logger = logger;
        _selectDecoration = selectDecoration;
        _addDecoration = addDecoration;
        _authHelper = authHelper;
        _selectParty = selectParty;
    }

    [BindProperty]
    public InputModel Input { get; set; } = default!;

    public class InputModel
    {
        [Display(Name = "Notes")]
        public string? Note { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Festa")]
        public Guid PartyId { get; set; } = default!;
    }

    public DecorationInfo Decoration { get; set; } = new();
    public List<PartyTemplate> Parties { get; set; } = new();
    public User UserModel { get; set; } = new();

    public async Task OnGetAsync(Guid decorationId)
    {
        Decoration = await _selectDecoration.FinbByIdWithType(decorationId);
        UserModel = (await _authHelper.GetUserFromToken(_authHelper.GetToken()!))!;
        Parties = await _selectParty.FromUser(UserModel.Id);
    }

    public async Task<IActionResult> OnPostAsync(Guid decorationId)
    {
        if (!ModelState.IsValid)
        {
            Decoration = await _selectDecoration.FinbByIdWithType(decorationId);
            await OnGetAsync(decorationId);
            return Page();
        }

        try
        {
            await _selectDecoration.FinbByIdWithType(decorationId);
            await _addDecoration.Execute(new(decorationId, Input.PartyId, Input.Quantity, Input.Note ?? ""));
            return Redirect($"/Clients/Party/Detail/{Input.PartyId}");
        }
        catch (Exception e)
        {
            // TODO: add error to ModelState
            _logger.LogError(e.ToString());
            return Redirect("/");
        }

    }
}