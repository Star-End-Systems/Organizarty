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
            var usecases = new UseCasesFactory(context);

            var foodRepo = new RepositoriesFactory(context).FoodTypeRepository();
            var createFood = usecases.CreateFoodTypeUseCase(foodRepo);

            var thirdParty = await ThirdPartySample.SetupThirdPartyAuthorized(usecases);

            var food = await FoodSample.SetupFoodType(createFood, thirdParty.Id);

            Assert.NotEqual(string.Empty, thirdParty.Id);
            Assert.Equal(thirdParty.Id, food.ThirdPartyId);
        }
    }
}
