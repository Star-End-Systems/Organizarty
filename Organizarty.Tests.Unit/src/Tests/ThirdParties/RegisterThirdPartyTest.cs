using Organizarty.Tests.Mock.Database;
using Organizarty.Tests.Mock.Repositories;
using Organizarty.Tests.Mock.UseCases;
using Organizarty.Tests.Unit.Samples.ThirdParties;

namespace Organizarty.Tests.Unit.Tests.ThirdParties;

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
