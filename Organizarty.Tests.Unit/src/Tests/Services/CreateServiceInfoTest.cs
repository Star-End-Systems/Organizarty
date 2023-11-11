using Organizarty.Tests.Mock.Database;
using Organizarty.Tests.Mock.Repositories;
using Organizarty.Tests.Mock.UseCases;
using Organizarty.Tests.Unit.Samples.Services;
using Organizarty.Tests.Unit.Samples.ThirdParties;

namespace Organizarty.Tests.Unit.Tests.Services;

public class CreateServiceInfoTest
{
    [Fact]
    public async Task CreateServiceInfo_ValidInfos_ReturnCreatedService()
    {
        using (var context = DatabaseFactory.InMemoryDatabase())
        {
            var repos = new RepositoriesFactory(context);
            var serviceRepo = repos.ServiceTypeRepository();
            var thirdpartyRepo = repos.ThirdPartyRepository();

            var usecases = new UseCasesFactory(context);
            var createService = usecases.CreateServiceTypeUseCase(serviceRepo);

            var thirdParty = await ThirdPartySample.SetupThirdPartyAuthorized(usecases);

            var type = await ServicesSample.SetupServiceType(createService, thirdParty.Id);

            var fRepo = repos.ServiceInfoRepository();
            var fUse = usecases.CreateServiceInfoUseCase(fRepo);
            var service = await ServicesSample.SetupServiceInfo(fUse, type.Id);

            Assert.NotEqual(Guid.Empty, service.Id);
            Assert.Equal(type.Id, service.ServiceTypeId);
        }
    }
}
