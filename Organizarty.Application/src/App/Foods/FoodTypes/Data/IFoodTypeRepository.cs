using Organizarty.Application.App.FoodTypes.Entities;

namespace Organizarty.Application.App.FoodTypes.Data;

public interface IFoodTypeRepository
{
    Task<FoodType> Create(FoodType foodType);
}
