using Organizarty.Application.App.Foods.Entities;
using Organizarty.Application.App.Schedules.Enum;
using Organizarty.Application.App.ThirdParties.Entities;

namespace Organizarty.Application.App.Schedules.Entities;

public class FoodOrder
{
    public string Id { get; set; } = default!;

    public int Quantity { get; set; }
    public string? Note { get; set; }
    public ItemStatus Status { get; set; } = ItemStatus.WAITING;

    public DateTime EventDate { get; set; }

    public decimal Price { get; set; }

    public string FoodInfoId { get; set; } = default!;
    public FoodInfo? FoodInfo { get; set; }

    public string ThirdPartyId { get; set; } = default!;
    public ThirdParty? ThirdParty { get; set; }

    public string ScheduleId { get; set; } = default!;
    public Schedule? Schedule { get; set; }
}
