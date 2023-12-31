using Organizarty.Application.App.Party.Entities;

namespace Organizarty.Application.App.Party.UseCases;

public record AddFoodToPartyDto(string foodInfoId, string partyId, int quantity, string note)
{
    public FoodGroup ToModel
      => new FoodGroup
      {
          PartyTemplateId = partyId,
          FoodInfoId = foodInfoId,
          Quantity = quantity,
          Note = note
      };
}
