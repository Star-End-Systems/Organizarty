using Organizarty.Application.App.Party.UseCases;
using Organizarty.Tests.Mock.Database;
using Organizarty.Tests.Mock.Repositories;
using Organizarty.Tests.Mock.UseCases;
using Organizarty.Tests.Unit.Samples.Foods;
using Organizarty.Tests.Unit.Samples.Locations;
using Organizarty.Tests.Unit.Samples.PartyTemplates;
using Organizarty.Tests.Unit.Samples.ThirdParties;
using Organizarty.Tests.Unit.Samples.Users;

namespace Organizarty.Tests.Unit.Tests.Parties;

public class AddFoodToPartyTest
{
    [Fact]
    public async Task AddFoodToParty_ValidData_ReturnAddedFood()
    {
        using (var context = DatabaseFactory.InMemoryDatabase())
        {
            var repos = new RepositoriesFactory(context);
            var usecases = new UseCasesFactory(context);

            var createLocation = usecases.CreateLocationUseCase();

            var location = await LocationSample.SetupLocation(createLocation);
            var thirdParty = await ThirdPartySample.SetupThirdParty(usecases);
            var user = await UserSample.SetupUserEmailConfirmed(usecases);
            var party = await PartyTemplateSample.SetuoPartyTemplate(usecases, location.Id, user.Id);

            var foodType = await FoodSample.SetupFoodType(usecases, thirdParty.Id);
            var foodInfo = await FoodSample.SetupFoodInfo(usecases, foodType.Id);

            var addFood = usecases.AddFoodToPartyUseCase();
            var selectOnParty = usecases.SelectPartyUseCase();

            var a = await addFood.Execute(new AddFoodToPartyDto(foodInfo.Id, party.Id, 1, "Sem cebola"));

            var foodss = await selectOnParty.GetFoods(party.Id);

            Assert.NotEqual(string.Empty, a.Id);
            Assert.Single(foodss);
        }
    }

    [Fact]
    public async Task AddDecorationToParty_NegativeQuantity_ThrowValidatioFail()
    {
        using (var context = DatabaseFactory.InMemoryDatabase())
        {
            var repos = new RepositoriesFactory(context);
            var usecases = new UseCasesFactory(context);

            var createLocation = usecases.CreateLocationUseCase();

            var location = await LocationSample.SetupLocation(createLocation);
            var thirdParty = await ThirdPartySample.SetupThirdParty(usecases);
            var user = await UserSample.SetupUserEmailConfirmed(usecases);
            var party = await PartyTemplateSample.SetuoPartyTemplate(usecases, location.Id, user.Id);

            var foodType = await FoodSample.SetupFoodType(usecases, thirdParty.Id);
            var foodInfo = await FoodSample.SetupFoodInfo(usecases, foodType.Id);

            var addFood = usecases.AddFoodToPartyUseCase();
            var selectOnParty = usecases.SelectPartyUseCase();

            var task = addFood.Execute(new AddFoodToPartyDto(foodInfo.Id, party.Id, 0, "Sem cebola"));

            var ex = await Assert.ThrowsAsync<ValidationFailException>(async () => await task);

            Assert.Single(ex.Errors);

            var decorations = await selectOnParty.GetDecorations(party.Id);

            Assert.Empty(decorations);
        }
    }

    [Fact]
    public async Task AddDecorationToParty_EmptyNote_RetuenAddedDecoration()
    {
        using (var context = DatabaseFactory.InMemoryDatabase())
        {
            var repos = new RepositoriesFactory(context);
            var usecases = new UseCasesFactory(context);

            var createLocation = usecases.CreateLocationUseCase();

            var location = await LocationSample.SetupLocation(createLocation);
            var thirdParty = await ThirdPartySample.SetupThirdParty(usecases);

            var user = await UserSample.SetupUserEmailConfirmed(usecases);
            var party = await PartyTemplateSample.SetuoPartyTemplate(usecases, location.Id, user.Id);

            var foodType = await FoodSample.SetupFoodType(usecases, thirdParty.Id);
            var foodInfo = await FoodSample.SetupFoodInfo(usecases, foodType.Id);

            var addFood = usecases.AddFoodToPartyUseCase();
            var selectOnParty = usecases.SelectPartyUseCase();

            var a = await addFood.Execute(new AddFoodToPartyDto(foodInfo.Id, party.Id, 1, ""));

            var foodss = await selectOnParty.GetFoods(party.Id);

            Assert.NotEmpty(a.Id);
            Assert.Single(foodss);
        }
    }
}
