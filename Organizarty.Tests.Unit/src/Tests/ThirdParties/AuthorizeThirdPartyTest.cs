using Organizarty.Tests.Mock.Database;
using Organizarty.Tests.Mock.Repositories;
using Organizarty.Tests.Mock.UseCases;
using Organizarty.Tests.Unit.Samples.ThirdParties;

namespace Organizarty.Tests.Unit.Tests.ThirdParties;

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

    [Fact]
    public async Task AuthorizeThirdParty_UsingEmail_ReturnAuthorizedThridParty()
    {
        using (var context = DatabaseFactory.InMemoryDatabase())
        {
            var thirdpartyRepo = new RepositoriesFactory(context).ThirdPartyRepository();
            var registerThirdParty = new UseCasesFactory().RegisterThirdPartyUseCase(thirdpartyRepo);
            var authorize = new UseCasesFactory().AuthorizeThirdPartyUseCase(thirdpartyRepo);

            var thirdParty = await ThirdPartySample.SetupThirdParty(registerThirdParty);

            await authorize.Execute(thirdParty.LoginEmail);

            Assert.NotEqual(Guid.Empty, thirdParty.Id);
            Assert.True(thirdParty.Authorized);
        }
    }

    [Fact]
    public async Task AuthorizeThirdParty_UsingId_ReturnAuthorizedThridParty()
    {
        using (var context = DatabaseFactory.InMemoryDatabase())
        {
            var thirdpartyRepo = new RepositoriesFactory(context).ThirdPartyRepository();
            var registerThirdParty = new UseCasesFactory().RegisterThirdPartyUseCase(thirdpartyRepo);
            var authorize = new UseCasesFactory().AuthorizeThirdPartyUseCase(thirdpartyRepo);

            var thirdParty = await ThirdPartySample.SetupThirdParty(registerThirdParty);

            await authorize.Execute(thirdParty.Id);

            Assert.NotEqual(Guid.Empty, thirdParty.Id);
            Assert.True(thirdParty.Authorized);
        }
    }
}
