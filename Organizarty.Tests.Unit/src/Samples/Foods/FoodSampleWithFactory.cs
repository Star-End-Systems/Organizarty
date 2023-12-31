using Organizarty.Application.App.Foods.Entities;
using Organizarty.Tests.Mock.UseCases;

namespace Organizarty.Tests.Unit.Samples.Foods;

public static partial class FoodSample
{
    public static async Task<FoodType> SetupFoodType(UseCasesFactory usecases, string thirdPartyId)
    {
        var use = usecases.CreateFoodTypeUseCase();
        return await SetupFoodType(use, thirdPartyId);
    }

    public static async Task<FoodInfo> SetupFoodInfo(UseCasesFactory usecases, string foodTypeId)
    {
        var use = usecases.CreateFoodInfoUseCase();
        return await SetupFoodInfo(use, foodTypeId);
    }
}
