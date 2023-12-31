using Organizarty.Application.App.Foods.Entities;
using Organizarty.Application.App.Foods.UseCases;

namespace Organizarty.Tests.Unit.Samples.Foods;

public static partial class FoodSample
{
    public static async Task<FoodType> SetupFoodType(CreateFoodUseCase createFood, string thirdPartyId)
    {
        var data = new CreateFoodDto("Coxinhas", "Uma deliciosa coxinha vegana, não contém glutem", "salgados", new(), thirdPartyId);

        return await createFood.Execute(data);
    }

    public static async Task<FoodInfo> SetupFoodInfo(CreateFoodItemUseCase createFood, string foodTypeId)
    {
        var data = new CreateFoodItemDto(foodTypeId, true, "Carne", 50, new());

        return await createFood.Execute(data);
    }
}
