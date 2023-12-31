using Organizarty.Tests.Mock.Database;
using Organizarty.Tests.Mock.Repositories;
using Organizarty.Tests.Mock.UseCases;
using Organizarty.Tests.Unit.Samples.Locations;
using Organizarty.Tests.Unit.Samples.PartyTemplates;
using Organizarty.Tests.Unit.Samples.Users;

namespace Organizarty.Tests.Unit.Tests.Parties;

public class CreatePartyTest
{
    [Fact]
    public async Task CreateParty_Sample_ReturnCreatedParty()
    {
        using (var context = DatabaseFactory.InMemoryDatabase())
        {
            var repos = new RepositoriesFactory(context);
            var usecases = new UseCasesFactory(context);

            var createLocation = usecases.CreateLocationUseCase();
            var location = await LocationSample.SetupLocation(createLocation);
            var user = await UserSample.SetupUserEmailConfirmed(usecases);

            var party = await PartyTemplateSample.SetuoPartyTemplate(usecases, location.Id, user.Id);

            Assert.NotEmpty(party.Id);
        }
    }
}
