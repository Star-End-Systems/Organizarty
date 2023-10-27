using Organizarty.Application.App.ThirdParties.Entities;

namespace Organizarty.Application.App.ServiceTypes.Entities;

public class ServiceType
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;

    public Guid ThirdPartyId { get; set; } = default!;
    public ThirdParty ThirdParty { get; set; } = default!;
}
