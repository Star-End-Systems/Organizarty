using Organizarty.Application.App.Users.UseCases;
using Organizarty.Infra.Data.Contexts;
using Organizarty.Tests.Mock.Database;
using Organizarty.Tests.Mock.Repositories;
using Organizarty.Tests.Mock.UseCases;
using Organizarty.Tests.Unit.Samples.Users;

namespace Organizarty.Tests.Unit.Tests.Mock;

public class LoginUserTest : IAsyncLifetime
{
    public ApplicationDbContext Context { get; private set; } = default!;

    [Fact]
    public async Task Login_ValidData_ReturnLoggedUser()
    {
        var userRepo = new RepositoriesFactory(Context).UserRepository();
        var confirmRepo = new RepositoriesFactory(Context).UserConfirmationRepository();

        var registerUser = new UseCasesFactory().RegisterUserUseCase(userRepo);
        var sendCode = new UseCasesFactory().SendEmailConfirmUseCase(confirmRepo);
        var confirmCode = new UseCasesFactory().ConfirmCodeUseCase(confirmRepo, userRepo);
        var loginUser = new UseCasesFactory().LoginUserUseCase(userRepo);

        var user = await UserSample.SetupUserEmailConfirmed(registerUser, sendCode, confirmCode);

        var u = await loginUser.Execute(new LoginUserDto(user.Email, "long_and_secure_password"));

        Assert.NotNull(u);
    }


    [Fact]
    public async Task Login_EmailNotFound_ReturnLoggedUser()
    {
        var userRepo = new RepositoriesFactory(Context).UserRepository();
        var confirmRepo = new RepositoriesFactory(Context).UserConfirmationRepository();

        var registerUser = new UseCasesFactory().RegisterUserUseCase(userRepo);
        var sendCode = new UseCasesFactory().SendEmailConfirmUseCase(confirmRepo);
        var confirmCode = new UseCasesFactory().ConfirmCodeUseCase(confirmRepo, userRepo);
        var loginUser = new UseCasesFactory().LoginUserUseCase(userRepo);

        var user = await UserSample.SetupUserEmailConfirmed(registerUser, sendCode, confirmCode);

        var task = loginUser.Execute(new LoginUserDto("", "long_and_secure_password"));

        await Assert.ThrowsAsync<NotFoundException>(async () => await task);
    }

    [Fact]
    public async Task Login_WrongPassword_ReturnLoggedUser()
    {
        var userRepo = new RepositoriesFactory(Context).UserRepository();
        var confirmRepo = new RepositoriesFactory(Context).UserConfirmationRepository();

        var registerUser = new UseCasesFactory().RegisterUserUseCase(userRepo);
        var sendCode = new UseCasesFactory().SendEmailConfirmUseCase(confirmRepo);
        var confirmCode = new UseCasesFactory().ConfirmCodeUseCase(confirmRepo, userRepo);
        var loginUser = new UseCasesFactory().LoginUserUseCase(userRepo);

        var user = await UserSample.SetupUserEmailConfirmed(registerUser, sendCode, confirmCode);

        var task = loginUser.Execute(new LoginUserDto(user.Email, "wrong_password"));

        await Assert.ThrowsAsync<NotFoundException>(async () => await task);
    }

    public Task InitializeAsync()
    {
        Context = DatabaseFactory.InMemoryDatabase();
        return Task.CompletedTask;
    }

    public async Task DisposeAsync()
    {
        await Context.DisposeAsync();
    }
}
