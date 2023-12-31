using Organizarty.Application.App.Party.Entities;

namespace Organizarty.Application.App.Party.Data;

public interface IFoodGroupRepository
{
    Task<FoodGroup> Add(FoodGroup group);
    Task<FoodGroup> Update(FoodGroup group);
    Task Delete(string id);

    Task<List<FoodGroup>> ListFromParty(string partyId);

    Task<FoodGroup?> FindById(string id);
}
