using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Adapters;
using Organizarty.Application.App.Party.Enums;
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
    public Guid PartyId { get; set; }

    public List<FoodGroup> Foods { get; set; } = new();
    public List<ServiceGroup> Services { get; set; } = new();
    public List<DecorationGroup> Decoration { get; set; } = new();

    public List<ItemOrder> Items { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(Guid partyId)
    {
        PartyId = partyId;
        var p = await _selectParty.FromIdWithLocation(partyId);

        if (p is null)
        {
            return Redirect("/Clients");
        }

        var t = ItemType.Food;

        switch (t)
        {
            case ItemType.Decoration:
                break;
            case ItemType.Food:
                break;
            case ItemType.Service:
                break;
        }

        Party = p;

        Foods = await _selectParty.GetFoods(partyId);
        Services = await _selectParty.GetServices(partyId);
        Decoration = await _selectParty.GetDecorations(partyId);

        Items.Aggregate(0m, (acc, x) => acc + (x.price * x.quantity));

        Items.AddRange(Foods.Select(x => new ItemOrder(x.Id, ItemType.Food, $"{x.FoodInfo?.FoodType?.Name ?? "no name"} - {x?.FoodInfo?.Flavour ?? ""} ", x.Quantity, x.Note, x.FoodInfo.Price, x.PartyTemplateId)));
        Items.AddRange(Services.Select(x => new ItemOrder(x.Id, ItemType.Service, $"{x.ServiceInfo?.ServiceType?.Name ?? "no name"} - {x.ServiceInfo.Plan}", 1, x.Note, x.ServiceInfo.Price, x.PartyTemplateId)));
        Items.AddRange(Decoration.Select(x => new ItemOrder(x.Id, ItemType.Decoration, $"{x.DecorationInfo?.DecorationType?.Name ?? "no name"} - {x.DecorationInfo.Material}", x.Quantity, x.Note, x.DecorationInfo.Price, x.PartyTemplate!.Id)));

        return Page();
    }
}
