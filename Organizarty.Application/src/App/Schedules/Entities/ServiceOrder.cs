using Organizarty.Application.App.Schedules.Enum;
using Organizarty.Application.App.Services.Entities;
using Organizarty.Application.App.ThirdParties.Entities;

namespace Organizarty.Application.App.Schedules.Entities;

public class ServiceOrder
{
    public string Id { get; set; } = default!;

    public string Note { get; set; } = "";
    public decimal Price { get; set; }
    public DateTime EventDate { get; set; } = default!;
    public ItemStatus Status { get; set; } = ItemStatus.WAITING;

    public ServiceInfo ServiceInfo { get; set; } = default!;
    public string ServiceInfoId { get; set; } = default!;

    public Schedule Schedule { get; set; } = default!;
    public string ScheduleId { get; set; } = default!;

    public ThirdParty ThirdParty { get; set; } = default!;
    public string ThirdPartyId { get; set; } = default!;
}
