using Organizarty.Application.App.Foods.Entities;

namespace Organizarty.Application.App.Party.Entities;

public class FoodGroup
{
    public Guid Id { get; set; }

    public int Quantity { get; set; }
    public string Note { get; set; } = default!;

    public Guid PartyTemplateId { get; set; }
    public PartyTemplate? PartyTemplate { get; set; }

    public Guid FoodInfoId { get; set; }
    public FoodInfo? FoodInfo { get; set; }
}
