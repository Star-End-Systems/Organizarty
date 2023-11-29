using Organizarty.Application.App.Party.UseCases;
using Organizarty.Tests.Mock.Database;
using Organizarty.Tests.Mock.Repositories;
using Organizarty.Tests.Mock.UseCases;
using Organizarty.Tests.Unit.Samples.Decorations;
using Organizarty.Tests.Unit.Samples.Locations;
using Organizarty.Tests.Unit.Samples.PartyTemplates;
using Organizarty.Tests.Unit.Samples.Users;

namespace Organizarty.Tests.Unit.Tests.Parties;

public class AddDecorationToPartyTest
{

    [Fact]
    public async Task AddDecorationToParty_ValidData_ReturnAddedDecoration()
    {
        using (var context = DatabaseFactory.InMemoryDatabase())
        {
            var repos = new RepositoriesFactory(context);
            var usecases = new UseCasesFactory(context);

            var createLocation = usecases.CreateLocationUseCase();

            var location = await LocationSample.SetupLocation(createLocation);

            var user = await UserSample.SetupUserEmailConfirmed(usecases);
            var party = await PartyTemplateSample.SetuoPartyTemplate(usecases, location.Id, user.Id);

            var decorationType = await DecorationSample.SetupDecorationType(usecases);
            var decorationInfo = await DecorationSample.SetupDecorationInfo(usecases, decorationType.Id);

            var addDecoration = usecases.AddDecorationToPartyUseCase();
            var selectOnParty = usecases.SelectPartyUseCase();

            var a = await addDecoration.Execute(new AddDecorationToPartyDto(decorationInfo.Id, party.Id, 1, "Sem cebola"));

            var decorations = await selectOnParty.GetDecorations(party.Id);

            Assert.NotEqual(Guid.Empty, a.Id);
            Assert.Single(decorations);
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

            var user = await UserSample.SetupUserEmailConfirmed(usecases);
            var party = await PartyTemplateSample.SetuoPartyTemplate(usecases, location.Id, user.Id);

            var decorationType = await DecorationSample.SetupDecorationType(usecases);
            var decorationInfo = await DecorationSample.SetupDecorationInfo(usecases, decorationType.Id);

            var addDecoration = usecases.AddDecorationToPartyUseCase();
            var selectOnParty = usecases.SelectPartyUseCase();

            var task = addDecoration.Execute(new AddDecorationToPartyDto(decorationInfo.Id, party.Id, 0, "Sem cebola"));

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

            var user = await UserSample.SetupUserEmailConfirmed(usecases);
            var party = await PartyTemplateSample.SetuoPartyTemplate(usecases, location.Id, user.Id);

            var decorationType = await DecorationSample.SetupDecorationType(usecases);
            var decorationInfo = await DecorationSample.SetupDecorationInfo(usecases, decorationType.Id);

            var addDecoration = usecases.AddDecorationToPartyUseCase();
            var selectOnParty = usecases.SelectPartyUseCase();

            var a = await addDecoration.Execute(new AddDecorationToPartyDto(decorationInfo.Id, party.Id, 1, ""));

            var decorations = await selectOnParty.GetDecorations(party.Id);

            Assert.NotEqual(Guid.Empty, a.Id);
            Assert.Single(decorations);
        }
    }
}
