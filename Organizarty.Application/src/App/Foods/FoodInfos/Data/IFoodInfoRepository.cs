using Organizarty.Application.App.FoodInfos.Entities;

namespace Organizarty.Application.App.FoodInfos.Data;

public interface IFoodInfoRepository
{
    Task<FoodInfo> Create(FoodInfo foodType);
}
