using Organizarty.Application.App.ThirdParties.UseCases;
using Organizarty.Infra.Data.Contexts;
using Organizarty.Tests.Mock.Database;
using Organizarty.Tests.Mock.UseCases;
using Organizarty.Tests.Unit.Samples.ThirdParties;

namespace Organizarty.Tests.Unit.Tests.ThirdParties;

public class LoginThirdPartyTest : IAsyncLifetime
{
    public ApplicationDbContext Context { get; private set; } = default!;

    public Task InitializeAsync()
    {
        Context = DatabaseFactory.InMemoryDatabase();
        return Task.CompletedTask;
    }

    public async Task DisposeAsync()
    {
        await Context.DisposeAsync();
    }

    [Fact]
    public async Task LoginThirdParty_Sample_ReturnCreatedThirdParty()
    {
        var usecases = new UseCasesFactory(Context);

        var loginThirdParty = usecases.LoginThirdPartyUseCase();

        var thirdParty = await ThirdPartySample.SetupThirdPartyAuthorized(usecases);

        var b = await loginThirdParty.Execute(new LoginThirdPartyDto(thirdParty.LoginEmail, "long_password"));

        Assert.NotNull(b);
        Assert.True(b.Authorized);
    }

    [Fact]
    public async Task LoginThirdParty_WrongEmail_ReturnCreatedThirdParty()
    {
        var usecases = new UseCasesFactory(Context);

        var loginThirdParty = usecases.LoginThirdPartyUseCase();

        var thirdParty = await ThirdPartySample.SetupThirdPartyAuthorized(usecases);

        var task = loginThirdParty.Execute(new LoginThirdPartyDto("email_that_didnt_exist", "long_password"));
    }

}
