using Organizarty.Application.App.FoodTypes.UseCases;
using Organizarty.Application.App.FoodTypes.Entities;
using Organizarty.Application.App.FoodTypes.Data;
using Organizarty.Application.App.FoodInfos.Entities;
using Organizarty.Application.App.FoodInfos.Data;
using Organizarty.Application.App.FoodInfos.UseCases;

namespace Organizarty.Tests.Factories.UseCases;

public partial class UseCasesFactory
{
    public CreateFoodTypeUseCase CreateFoodTypeUseCase(IFoodTypeRepository repo)
      => new CreateFoodTypeUseCase(repo, new FoodTypeValidator());

    public CreateFoodInfoUseCase CreateFoodInfoUseCase(IFoodInfoRepository repo)
      => new CreateFoodInfoUseCase(repo, new FoodInfoValidator());
}
