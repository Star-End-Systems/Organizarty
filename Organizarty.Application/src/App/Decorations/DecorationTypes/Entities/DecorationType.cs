using Organizarty.Application.App.DecorationInfos.Entities;
using Organizarty.Application.App.ThirdParties.Entities;

namespace Organizarty.Application.App.DecorationTypes.Entities;

public class DecorationType
{
    public Guid Id { get; set; }

    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Size { get; set; }
    public string? Model { get; set; }
    public string? ObjectURL { get; set; }

    public Guid ThirdPartyId { get; set; }
    public ThirdParty ThirdParty { get; set; } = default!;

    public ICollection<DecorationInfo> Decorations { get; set; } = default!;

}
