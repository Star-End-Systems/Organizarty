using Organizarty.Application.App.Party.Entities;

namespace Organizarty.Application.App.Party.UseCases;

public record CreatePartyDto(string? name, int expectedGuests, string partyType, Guid LocationId, Guid userId)
{
    public PartyTemplate ToModel
      => new PartyTemplate
      {
          Name = name ?? "",
          ExpectedGuests = expectedGuests,
          PartyType = partyType,
          LocationId = LocationId,
          UserId = userId,
      };
}
