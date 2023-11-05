using Organizarty.Tests.Mock.Database;
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
            var usecases = new UseCasesFactory(context);

            var thirdParty = await ThirdPartySample.SetupThirdPartyAuthorized(usecases);

            Assert.NotEqual(Guid.Empty, thirdParty.Id);
            Assert.True(thirdParty.Authorized);
        }
    }

    [Fact]
    public async Task AuthorizeThirdParty_UsingEmail_ReturnAuthorizedThridParty()
    {
        using (var context = DatabaseFactory.InMemoryDatabase())
        {
            var usecases = new UseCasesFactory(context);

            var authorize = usecases.AuthorizeThirdPartyUseCase();

            var thirdParty = await ThirdPartySample.SetupThirdParty(usecases);

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
            var usecases = new UseCasesFactory(context);

            var authorize = usecases.AuthorizeThirdPartyUseCase();

            var thirdParty = await ThirdPartySample.SetupThirdParty(usecases);

            await authorize.Execute(thirdParty.Id);

            Assert.NotEqual(Guid.Empty, thirdParty.Id);
            Assert.True(thirdParty.Authorized);
        }
    }
}
