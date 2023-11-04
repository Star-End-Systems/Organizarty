using Organizarty.Tests.Factories.Database;
using Organizarty.Tests.Factories.Repositories;
using Organizarty.Tests.Factories.UseCases;
using Organizarty.Tests.Samples.ThirdParties;

namespace Organizarty.Tests.Unit.ThirdParties;

public class AuthorizeThirdPartyTest
{
    [Fact]
    public async Task AuthorizeThirdParty_Sample_ReturnAuthorizedThridParty()
    {
        using (var context = DatabaseFactory.InMemoryDatabase())
        {
            var thirdpartyRepo = new RepositoriesFactory(context).ThirdPartyRepository();
            var registerThirdParty = new UseCasesFactory().RegisterThirdPartyUseCase(thirdpartyRepo);
            var authorize = new UseCasesFactory().AuthorizeThirdPartyUseCase(thirdpartyRepo);

            var thirdParty = await ThirdPartySample.SetupThirdPartyAuthorized(registerThirdParty, authorize);

            Assert.NotEqual(Guid.Empty, thirdParty.Id);
            Assert.True(thirdParty.Authorized);
        }
    }
}
