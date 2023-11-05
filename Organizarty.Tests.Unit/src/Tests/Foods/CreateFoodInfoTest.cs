using Organizarty.Tests.Mock.Database;
using Organizarty.Tests.Mock.Repositories;
using Organizarty.Tests.Mock.UseCases;
using Organizarty.Tests.Unit.Samples.Foods;
using Organizarty.Tests.Unit.Samples.ThirdParties;

namespace Organizarty.Tests.Unit.Tests.Foods;

public class CreateFoodInfoTest
{
    [Fact]
    public async Task CreateFoodInfo_ValidInfos_ReturnCreatedFood()
    {
        using (var context = DatabaseFactory.InMemoryDatabase())
        {
            var repos = new RepositoriesFactory(context);
            var foodRepo = repos.FoodTypeRepository();
            var thirdpartyRepo = repos.ThirdPartyRepository();

            var usecases = new UseCasesFactory();
            var createFood = usecases.CreateFoodTypeUseCase(foodRepo);
            var registerThirdParty = usecases.RegisterThirdPartyUseCase(thirdpartyRepo);
            var authorize = usecases.AuthorizeThirdPartyUseCase(thirdpartyRepo);

            var thirdParty = await ThirdPartySample.SetupThirdPartyAuthorized(registerThirdParty, authorize);
            var type = await FoodSample.SetupFoodType(createFood, thirdParty.Id);

            var fRepo = repos.FoodInfoRepository();
            var fUse = usecases.CreateFoodInfoUseCase(fRepo);
            var food = await FoodSample.SetupFoodInfo(fUse, type.Id);

            Assert.NotEqual(Guid.Empty, food.Id);
            Assert.Equal(type.Id, food.FoodTypeId);
        }
    }
}
