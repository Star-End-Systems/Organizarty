using Organizarty.Application.App.Party.UseCases;
using Organizarty.Tests.Mock.Database;
using Organizarty.Tests.Mock.Repositories;
using Organizarty.Tests.Mock.UseCases;
using Organizarty.Tests.Unit.Samples.Services;
using Organizarty.Tests.Unit.Samples.Locations;
using Organizarty.Tests.Unit.Samples.PartyTemplates;
using Organizarty.Tests.Unit.Samples.ThirdParties;
using Organizarty.Tests.Unit.Samples.Users;

namespace Organizarty.Tests.Unit.Tests.Parties;

public class AddServiceToPartyTest
{
    [Fact]
    public async Task AddServiceToParty_ValidData_ReturnAddedService()
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

            var serviceType = await ServicesSample.SetupServiceType(usecases, thirdParty.Id);
            var serviceInfo = await ServicesSample.SetupServiceInfo(usecases, serviceType.Id);

            var addService = usecases.AddServiceToPartyUsecase();
            var selectOnParty = usecases.SelectPartyUseCase();

            var a = await addService.Execute(new AddServiceToPartyDto(serviceInfo.Id, party.Id, "Todos de vermelho"));

            var servicess = await selectOnParty.GetServices(party.Id);

            Assert.NotEqual(Guid.Empty, a.Id);
            Assert.Single(servicess);
        }
    }

    [Fact]
    public async Task AddServiceToParty_EmptyNote_RetuenAddedService()
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

            var serviceType = await ServicesSample.SetupServiceType(usecases, thirdParty.Id);
            var serviceInfo = await ServicesSample.SetupServiceInfo(usecases, serviceType.Id);

            var addService = usecases.AddServiceToPartyUsecase();
            var selectOnParty = usecases.SelectPartyUseCase();

            var a = await addService.Execute(new AddServiceToPartyDto(serviceInfo.Id, party.Id, ""));

            var servicess = await selectOnParty.GetServices(party.Id);

            Assert.NotEqual(Guid.Empty, a.Id);
            Assert.Single(servicess);
        }
    }
}
