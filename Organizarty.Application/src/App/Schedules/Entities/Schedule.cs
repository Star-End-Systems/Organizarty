using Organizarty.Application.App.Locations.Entities;
using Organizarty.Application.App.Party.Entities;
using Organizarty.Application.App.Party.Enums;
using Organizarty.Application.App.Users.Entities;

namespace Organizarty.Application.App.Schedules.Entities;

public class Schedule
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;
    public int ExpectedGuests { get; set; }
    public DateTime StartDate { get; set; } = default!;
    public DateTime EndDate { get; set; } = default!;
    public decimal Price { get; set; } = default!;

    public PartyType Type { get; set; }

    public Guid UserId { get; set; } = default!;
    public User User { get; set; } = default!;

    public Guid LocationId { get; set; } = default!;
    public Location Location { get; set; } = default!;

    public Guid PartyId { get; set; }
    public PartyTemplate? Party { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
