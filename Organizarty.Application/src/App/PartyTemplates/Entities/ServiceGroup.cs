using Organizarty.Application.App.Services.Entities;

namespace Organizarty.Application.App.Party.Entities;

public class ServiceGroup
{
    public string Id { get; set; } = default!;

    public string Note { get; set; } = "";

    public string ServiceInfoId { get; set; } = default!;
    public ServiceInfo ServiceInfo { get; set; } = default!;

    public string PartyTemplateId { get; set; } = default!;
    public PartyTemplate PartyTemplate { get; set; } = default!;
}
