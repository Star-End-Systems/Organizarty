using Organizarty.Application.App.FoodInfos.Entities;
using Organizarty.Application.App.FoodInfos.UseCases;
using Organizarty.Application.App.FoodTypes.Entities;
using Organizarty.Application.App.FoodTypes.UseCases;

namespace Organizarty.Tests.Samples.Foods;

public static class FoodSample
{
    public static async Task<FoodType> SetupFoodType(CreateFoodTypeUseCase createFood, Guid thirdPartyId)
    {
        var data = new CreateFoodTypeDto("Coxinhas", "Uma deliciosa coxinha vegana, não contém glutem", "salgados", new(), thirdPartyId);

        return await createFood.Execute(data);
    }

    public static async Task<FoodInfo> SetupFoodInfo(CreateFoodInfoUseCase createFood, Guid foodTypeId)
    {
        var data = new CreateFoodInfoDto(foodTypeId, true, "Carne", 50, new());

        return await createFood.Execute(data);
    }
}
