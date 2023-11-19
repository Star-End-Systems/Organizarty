using Organizarty.Application.App.Foods.UseCases;
using Organizarty.Application.App.Foods.Entities;
using Organizarty.Application.App.Foods.Data;

namespace Organizarty.Tests.Mock.UseCases;

public partial class UseCasesFactory
{
    public CreateFoodUseCase CreateFoodTypeUseCase(IFoodTypeRepository repo)
      => new CreateFoodUseCase(repo, new FoodTypeValidator());

    public CreateFoodUseCase CreateFoodTypeUseCase()
    {
        var repo = _repositories.FoodTypeRepository();

        return new CreateFoodUseCase(repo, new FoodTypeValidator()); ;
    }

    public CreateFoodItemUseCase CreateFoodInfoUseCase(IFoodInfoRepository repo)
      => new CreateFoodItemUseCase(repo, new FoodInfoValidator());

    public CreateFoodItemUseCase CreateFoodInfoUseCase()
    {
        var repo = _repositories.FoodInfoRepository();

        return new CreateFoodItemUseCase(repo, new FoodInfoValidator());
    }
}
