using Organizarty.Tests.Mock.Database;
using Organizarty.Tests.Mock.Repositories;
using Organizarty.Tests.Mock.UseCases;
using Organizarty.Tests.Unit.Samples.Foods;
using Organizarty.Tests.Unit.Samples.ThirdParties;

namespace Organizarty.Tests.Unit.Tests.Foods;

public class CreateFoodTypeTest
{
    [Fact]
    public async Task CreateFoodType_ValidInfos_ReturnCreatedFood()
    {
        using (var context = DatabaseFactory.InMemoryDatabase())
        {
            var foodRepo = new RepositoriesFactory(context).FoodTypeRepository();
            var createFood = new UseCasesFactory().CreateFoodTypeUseCase(foodRepo);

            var thirdpartyRepo = new RepositoriesFactory(context).ThirdPartyRepository();
            var registerThirdParty = new UseCasesFactory().RegisterThirdPartyUseCase(thirdpartyRepo);
            var authorize = new UseCasesFactory().AuthorizeThirdPartyUseCase(thirdpartyRepo);

            var thirdParty = await ThirdPartySample.SetupThirdPartyAuthorized(registerThirdParty, authorize);

            var food = await FoodSample.SetupFoodType(createFood, thirdParty.Id);

            Assert.NotEqual(Guid.Empty, thirdParty.Id);
            Assert.Equal(thirdParty.Id, food.ThirdPartyId);
        }
    }
}
