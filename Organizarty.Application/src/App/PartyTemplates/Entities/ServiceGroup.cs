using Organizarty.Application.App.ServiceInfos.Entities;

namespace Organizarty.Application.App.Party.Entities;

public class ServiceGroup
{
    public Guid Id { get; set; }

    public string Note { get; set; } = "";

    public Guid ServiceInfoId { get; set; } = default!;
    public ServiceInfo ServiceInfo { get; set; } = default!;

    public Guid PartyTemplateId { get; set; } = default!;
    public PartyTemplate PartyTemplate { get; set; } = default!;
}
