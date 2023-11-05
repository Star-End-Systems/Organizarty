using Organizarty.Infra.Data.Contexts;
using Organizarty.Tests.Mock.Database;
using Organizarty.Tests.Mock.Repositories;
using Organizarty.Tests.Mock.UseCases;
using Organizarty.Tests.Unit.Samples.Users;

namespace Organizarty.Tests.Unit.Tests.Mock;

public class ConfirmUserCodeTest : IAsyncLifetime
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
    public async Task ConfirmEmailCode_ValidData_ReturnCreatedUser()
    {
        var userRepo = new RepositoriesFactory(Context).UserRepository();
        var confirmRepo = new RepositoriesFactory(Context).UserConfirmationRepository();

        var registerUser = new UseCasesFactory().RegisterUserUseCase(userRepo);
        var sendCode = new UseCasesFactory().SendEmailConfirmUseCase(confirmRepo);
        var confirmCode = new UseCasesFactory().ConfirmCodeUseCase(confirmRepo, userRepo);

        var user = await UserSample.SetupUser(registerUser);

        var code = (await sendCode.Execute(user)).Id;

        Assert.NotEqual(Guid.Empty, code);

        var u = await confirmCode.Execute(code);

        Assert.True(u.EmailConfirmed);
    }

    [Fact]
    public async Task ConfirmEmailCode_Sample_ReturnCreatedUser()
    {
        var userRepo = new RepositoriesFactory(Context).UserRepository();
        var confirmRepo = new RepositoriesFactory(Context).UserConfirmationRepository();

        var registerUser = new UseCasesFactory().RegisterUserUseCase(userRepo);
        var sendCode = new UseCasesFactory().SendEmailConfirmUseCase(confirmRepo);
        var confirmCode = new UseCasesFactory().ConfirmCodeUseCase(confirmRepo, userRepo);

        var user = await UserSample.SetupUserEmailConfirmed(registerUser, sendCode, confirmCode);

        Assert.NotNull(user);
    }
}
