using Organizarty.Tests.Factories.Database;
using Organizarty.Tests.Factories.Repositories;
using Organizarty.Tests.Factories.UseCases;
using Organizarty.Tests.Samples.Foods;
using Organizarty.Tests.Samples.ThirdParties;

namespace Organizarty.Tests.Unit.Foods;

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
