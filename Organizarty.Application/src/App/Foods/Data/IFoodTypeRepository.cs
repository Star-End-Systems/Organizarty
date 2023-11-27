using Organizarty.Application.App.Foods.Entities;

namespace Organizarty.Application.App.Foods.Data;

public interface IFoodTypeRepository
{
    Task<FoodType> Create(FoodType foodType);
    Task<FoodType> Update(FoodType foodType);

    Task<List<FoodType>> AllFoods();
    Task<List<FoodType>> AllFoods(bool avaible);

    Task<List<FoodType>> AllFoodsFromThirdParty(Guid thirdPartyId);

    Task<FoodType?> FindById(Guid id);
}
