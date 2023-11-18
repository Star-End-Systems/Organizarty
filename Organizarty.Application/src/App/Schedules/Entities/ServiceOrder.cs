using Organizarty.Application.App.Schedules.Enum;
using Organizarty.Application.App.Services.Entities;
using Organizarty.Application.App.ThirdParties.Entities;

namespace Organizarty.Application.App.Schedules.Entities;

public class ServiceOrder
{
    public Guid Id { get; set; }

    public string Note { get; set; } = "";
    public decimal Price { get; set; }
    public DateTime EventDate { get; set; } = default!;
    public ItemStatus Status { get; set; }

    public ServiceInfo ServiceInfo { get; set; } = default!;
    public Guid ServiceInfoId { get; set; } = default!;

    public Schedule Schedule { get; set; } = default!;
    public Guid ScheduleId { get; set; } = default!;

    public ThirdParty ThirdParty { get; set; } = default!;
    public Guid ThirdPartyId { get; set; } = default!;
}
