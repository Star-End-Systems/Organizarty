using Organizarty.Application.App.Party.Entities;

namespace Organizarty.Application.App.Party.UseCases;

public record AddDecorationToPartyDto(Guid decorationInfoId, Guid partyId, int quantity, string note)
{
    public DecorationGroup ToModel
      => new DecorationGroup
      {
          PartyTemplateId = partyId,
          Quantity = quantity,
          DecorationInfoId = decorationInfoId,
          Note = note
      };
}
