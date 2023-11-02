using Organizarty.Application.App.ThirdParties.UseCases;
using Organizarty.Tests.Factories.Database;
using Organizarty.Tests.Factories.Repositories;
using Organizarty.Tests.Factories.UseCases;
using Organizarty.Tests.Samples.ThirdParties;

namespace Organizarty.Tests.Unit.ThirdParties;

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
        var thirdpartyRepo = new RepositoriesFactory(Context).ThirdPartyRepository();
        var registerThirdParty = new UseCasesFactory().RegisterThirdPartyUseCase(thirdpartyRepo);
        var authorizeThirdParty = new UseCasesFactory().AuthorizeThirdPartyUseCase(thirdpartyRepo);
        var loginThirdParty = new UseCasesFactory().LoginThirdPartyUseCase(thirdpartyRepo);

        var thirdParty = await ThirdPartySample.SetupThirdPartyAuthorized(registerThirdParty, authorizeThirdParty);

        var b = await loginThirdParty.Execute(new LoginThirdPartyDto(thirdParty.LoginEmail, "long_password"));

        Assert.NotNull(b);
        Assert.True(b.Authorized);
    }

    [Fact]
    public async Task LoginThirdParty_WrongEmail_ReturnCreatedThirdParty()
    {
        var thirdpartyRepo = new RepositoriesFactory(Context).ThirdPartyRepository();
        var registerThirdParty = new UseCasesFactory().RegisterThirdPartyUseCase(thirdpartyRepo);
        var authorizeThirdParty = new UseCasesFactory().AuthorizeThirdPartyUseCase(thirdpartyRepo);
        var loginThirdParty = new UseCasesFactory().LoginThirdPartyUseCase(thirdpartyRepo);

        var thirdParty = await ThirdPartySample.SetupThirdPartyAuthorized(registerThirdParty, authorizeThirdParty);

        var task = loginThirdParty.Execute(new LoginThirdPartyDto("email_that_didnt_exist", "long_password"));
    }

}
