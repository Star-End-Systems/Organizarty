using Organizarty.Tests.Mock.Database;
using Organizarty.Tests.Mock.Repositories;
using Organizarty.Tests.Mock.UseCases;
using Organizarty.Tests.Unit.Samples.Services;
using Organizarty.Tests.Unit.Samples.ThirdParties;

namespace Organizarty.Tests.Unit.Tests.Services;

public class CreateServiceTypeTest
{
    [Fact]
    public async Task CreateServiceType_ValidInfos_ReturnCreatedService()
    {
        using (var context = DatabaseFactory.InMemoryDatabase())
        {
            var usecases = new UseCasesFactory(context);

            var serviceRepo = new RepositoriesFactory(context).ServiceTypeRepository();
            var createService = usecases.CreateServiceTypeUseCase(serviceRepo);

            var thirdParty = await ThirdPartySample.SetupThirdPartyAuthorized(usecases);

            var service = await ServicesSample.SetupServiceType(createService, thirdParty.Id);

            Assert.NotEqual(string.Empty, thirdParty.Id);
            Assert.Equal(thirdParty.Id, service.ThirdPartyId);
        }
    }
}
