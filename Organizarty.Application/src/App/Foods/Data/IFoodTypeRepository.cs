using Organizarty.Application.App.Foods.Entities;

namespace Organizarty.Application.App.Foods.Data;

public interface IFoodTypeRepository
{
    Task<FoodType> Create(FoodType foodType);
}
