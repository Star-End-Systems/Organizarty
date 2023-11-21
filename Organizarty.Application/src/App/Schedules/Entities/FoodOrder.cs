using Organizarty.Application.App.Foods.Entities;
using Organizarty.Application.App.Party.Entities;
using Organizarty.Application.App.Schedules.Enum;
using Organizarty.Application.App.ThirdParties.Entities;

namespace Organizarty.Application.App.Schedules.Entities;

public class FoodOrder
{
    public Guid Id { get; set; }

    public int Quantity { get; set; }
    public string? Note { get; set; }
    public ItemStatus Status { get; set; } = ItemStatus.WAITING;

    public DateTime EventDate { get; set; }

    public decimal Price { get; set; }

    public Guid PartyTemplateId { get; set; }
    public PartyTemplate? PartyTemplate { get; set; }

    public Guid FoodInfoId { get; set; }
    public FoodInfo? FoodInfo { get; set; }

    public Guid ThirdPartyId { get; set; }
    public ThirdParty? ThirdParty { get; set; }

    public Guid ScheduleId { get; set; }
    public Schedule? Schedule { get; set; }
}
