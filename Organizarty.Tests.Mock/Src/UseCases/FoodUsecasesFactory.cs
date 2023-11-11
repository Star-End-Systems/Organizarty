using Organizarty.Application.App.FoodTypes.UseCases;
using Organizarty.Application.App.FoodTypes.Entities;
using Organizarty.Application.App.FoodTypes.Data;
using Organizarty.Application.App.FoodInfos.Entities;
using Organizarty.Application.App.FoodInfos.Data;
using Organizarty.Application.App.FoodInfos.UseCases;

namespace Organizarty.Tests.Mock.UseCases;

public partial class UseCasesFactory
{
    public CreateFoodTypeUseCase CreateFoodTypeUseCase(IFoodTypeRepository repo)
      => new CreateFoodTypeUseCase(repo, new FoodTypeValidator());

    public CreateFoodTypeUseCase CreateFoodTypeUseCase()
    {
        var repo = _repositories.FoodTypeRepository();

        return new CreateFoodTypeUseCase(repo, new FoodTypeValidator()); ;
    }

    public CreateFoodInfoUseCase CreateFoodInfoUseCase(IFoodInfoRepository repo)
      => new CreateFoodInfoUseCase(repo, new FoodInfoValidator());

    public CreateFoodInfoUseCase CreateFoodInfoUseCase()
    {
        var repo = _repositories.FoodInfoRepository();

        return new CreateFoodInfoUseCase(repo, new FoodInfoValidator());
    }
}
