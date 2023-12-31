using Organizarty.Application.App.Party.Entities;
using Organizarty.Application.App.Party.Enums;

namespace Organizarty.Application.App.Party.UseCases;

public record CreatePartyDto(string? name, int expectedGuests, PartyType partyType, string LocationId, string userId)
{
    public PartyTemplate ToModel
      => new PartyTemplate
      {
          Name = name ?? "",
          ExpectedGuests = expectedGuests,
          Type = partyType,
          LocationId = LocationId,
          UserId = userId,
      };
}
