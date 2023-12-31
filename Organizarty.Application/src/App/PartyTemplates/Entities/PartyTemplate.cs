using Organizarty.Application.App.Locations.Entities;
using Organizarty.Application.App.Party.Enums;
using Organizarty.Application.App.Users.Entities;

namespace Organizarty.Application.App.Party.Entities;

public class PartyTemplate
{
    public string Id { get; set; } = default!;

    public string Name { get; set; } = default!;
    public int ExpectedGuests { get; set; }

    public PartyType Type { get; set; }

    public string UserId { get; set; } = default!;
    public User? User { get; set; }

    public string LocationId { get; set; } = default!;
    public Location Location { get; set; } = default!;

    public string? OriginalPartyTemplateId { get; set; }
    public PartyTemplate? OriginalPartyTemplate { get; set; }
}
