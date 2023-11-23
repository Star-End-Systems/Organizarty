using Organizarty.Application.App.Foods.Entities;

namespace Organizarty.Application.App.Foods.Data;

public interface IFoodInfoRepository
{
    Task<FoodInfo> Create(FoodInfo foodType);

    Task<FoodInfo?> FindWithIdWithDetail(Guid id);
}
