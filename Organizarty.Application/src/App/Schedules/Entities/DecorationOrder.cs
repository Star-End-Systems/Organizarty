using Organizarty.Application.App.DecorationInfos.Entities;
using Organizarty.Application.App.Schedules.Enum;

namespace Organizarty.Application.App.Schedules.Entities;

public class DecorationOrder
{
    public string Id { get; set; } = default!;

    public int Quantity { get; set; }
    public DateTime EventDate { get; set; } = default!;
    public decimal Price { get; set; }
    public string Note { get; set; } = "";
    public ItemStatus Status { get; set; }

    public DecorationInfo Decoration { get; set; } = default!;
    public string DecorationId { get; set; } = default!;

    public Schedule Schedule { get; set; } = default!;
    public string ScheduleId { get; set; } = default!;
}
