using Organizarty.Application.App.FoodInfos.Entities;
using Organizarty.Application.App.FoodTypes.Entities;
using Organizarty.Tests.Mock.UseCases;

namespace Organizarty.Tests.Unit.Samples.Foods;

public static partial class FoodSample
{
    public static async Task<FoodType> SetupFoodType(UseCasesFactory usecases, Guid thirdPartyId)
    {
        var use = usecases.CreateFoodTypeUseCase();
        return await SetupFoodType(use, thirdPartyId);
    }

    public static async Task<FoodInfo> SetupFoodInfo(UseCasesFactory usecases, Guid foodTypeId)
    {
        var use = usecases.CreateFoodInfoUseCase();
        return await SetupFoodInfo(use, foodTypeId);
    }
}
