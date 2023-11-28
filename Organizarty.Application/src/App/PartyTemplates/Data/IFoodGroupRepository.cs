using Organizarty.Application.App.Party.Entities;

namespace Organizarty.Application.App.Party.Data;

public interface IFoodGroupRepository
{
    Task<FoodGroup> Add(FoodGroup group);
    Task<FoodGroup> Update(FoodGroup group);
    Task Delete(Guid id);

    Task<List<FoodGroup>> ListFromParty(Guid partyId);

    Task<FoodGroup?> FindById(Guid id);
}
