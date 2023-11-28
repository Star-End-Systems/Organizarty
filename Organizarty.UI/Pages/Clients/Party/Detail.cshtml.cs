using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Adapters;
using Organizarty.Application.App.Party.Entities;
using Organizarty.Application.App.Party.UseCases;
using Organizarty.UI.Attributes;
namespace Organizarty.UI.Pages.Clients.Party;

[Authorized("/Clients/Accounts/Login", UserType.Client)]
public class PartyDetailModel : PageModel
{
    private readonly ILogger<NewPartyModel> _logger;
    private readonly SelectPartyUseCase _selectParty;

    public PartyDetailModel(ILogger<NewPartyModel> logger, SelectPartyUseCase selectParty)
    {
        _logger = logger;
        _selectParty = selectParty;
    }

    public PartyTemplate Party { get; set; } = default!;

    public List<FoodGroup> Foods { get; set; } = default!;
    public List<ServiceGroup> Services { get; set; } = default!;
    public List<DecorationGroup> Decoration { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid partyId)
    {
        var p = await _selectParty.FromIdWithLocation(partyId);

        if (p is null)
        {
            return Redirect("/Clients");
        }

        Party = p;

        Foods = await _selectParty.GetFoods(partyId);
        Services = await _selectParty.GetServices(partyId);
        Decoration = await _selectParty.GetDecorations(partyId);

        return Page();
    }
}
