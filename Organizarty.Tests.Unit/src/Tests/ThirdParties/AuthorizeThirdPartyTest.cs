using Organizarty.Application.App.Utils.Enums;
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

            Assert.NotEqual(string.Empty, thirdParty.Id);
            Assert.Equal(AuthorizationStatus.Authorized, thirdParty.AuthorizationStatus);
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

            Assert.NotEqual(string.Empty, thirdParty.Id);
            Assert.Equal(AuthorizationStatus.Authorized, thirdParty.AuthorizationStatus);
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

            await authorize.ExecuteFromId(thirdParty.Id);

            Assert.NotEqual(string.Empty, thirdParty.Id);
            Assert.Equal(AuthorizationStatus.Authorized, thirdParty.AuthorizationStatus);
        }
    }
}
