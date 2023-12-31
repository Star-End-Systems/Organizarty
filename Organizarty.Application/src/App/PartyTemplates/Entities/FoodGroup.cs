using Organizarty.Application.App.Foods.Entities;

namespace Organizarty.Application.App.Party.Entities;

public class FoodGroup
{
    public string Id { get; set; } = default!;

    public int Quantity { get; set; }
    public string Note { get; set; } = default!;

    public string PartyTemplateId { get; set; } = default!;
    public PartyTemplate? PartyTemplate { get; set; }

    public string FoodInfoId { get; set; } = default!;
    public FoodInfo? FoodInfo { get; set; }
}
