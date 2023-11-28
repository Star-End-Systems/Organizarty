using Organizarty.Application.App.Party.Entities;

namespace Organizarty.Application.App.Party.UseCases;

public record CreatePartyDto(string? name, int expectedGuests, Guid LocationId, Guid userId)
{
    public PartyTemplate ToModel
      => new PartyTemplate
      {
          Name = name ?? "",
          ExpectedGuests = expectedGuests,
          LocationId = LocationId,
          UserId = userId,
      };
}
