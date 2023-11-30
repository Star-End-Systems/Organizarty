using Organizarty.Application.App.Locations.Entities;
using Organizarty.Application.App.Users.Entities;

namespace Organizarty.Application.App.Party.Entities;

public class PartyTemplate
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;
    public int ExpectedGuests { get; set; }

    public string PartyType { get; set; } = default!;

    public Guid UserId { get; set; }
    public User? User { get; set; }

    public Guid LocationId { get; set; }
    public Location Location { get; set; } = default!;

    public Guid? OriginalPartyTemplateId { get; set; }
    public PartyTemplate? OriginalPartyTemplate { get; set; }
}
