using Organizarty.Application.App.Party.Entities;

namespace Organizarty.Application.App.Party.Data;

public interface IFoodGroupRepository
{
    Task<FoodGroup> Add(FoodGroup group);
    Task<List<FoodGroup>> ListFoodFromParty(Guid partyId);
}
