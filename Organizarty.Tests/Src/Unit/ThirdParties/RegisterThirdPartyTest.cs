using Organizarty.Tests.Factories.Database;
using Organizarty.Tests.Factories.Repositories;
using Organizarty.Tests.Factories.UseCases;
using Organizarty.Tests.Samples.ThirdParties;

namespace Organizarty.Tests.Unit.ThirdParties;

public class RegisterThirdPartyTest
{
    [Fact]
    public async Task RegisterThirdParty_Sample_ReturnCreatedThirdParty()
    {
        using (var context = DatabaseFactory.InMemoryDatabase())
        {
            var thirdpartyRepo = new RepositoriesFactory(context).ThirdPartyRepository();
            var registerThirdParty = new UseCasesFactory().RegisterThirdPartyUseCase(thirdpartyRepo);

            var thirdParty = await ThirdPartySample.SetupThirdParty(registerThirdParty);

            Assert.NotEqual(Guid.Empty, thirdParty.Id);
            Assert.False(thirdParty.Authorized);
        }
    }
}
