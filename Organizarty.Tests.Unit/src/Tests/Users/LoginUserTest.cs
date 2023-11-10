using Organizarty.Application.App.Users.UseCases;
using Organizarty.Infra.Data.Contexts;
using Organizarty.Tests.Mock.Database;
using Organizarty.Tests.Mock.UseCases;
using Organizarty.Tests.Unit.Samples.Users;

namespace Organizarty.Tests.Unit.Tests.Mock;

public class LoginUserTest : IAsyncLifetime
{
    public ApplicationDbContext Context { get; private set; } = default!;

    [Fact]
    public async Task Login_ValidData_ReturnLoggedUser()
    {
        var usecases = new UseCasesFactory(Context);

        var user = await UserSample.SetupUserEmailConfirmed(usecases);

        var loginUser = usecases.LoginUserUseCase();
        var u = await loginUser.Execute(new LoginUserDto(user.Email, "long_and_secure_password"));

        Assert.NotNull(u);
    }


    [Fact]
    public async Task Login_EmailNotFound_ReturnLoggedUser()
    {
        var usecases = new UseCasesFactory(Context);

        var user = await UserSample.SetupUserEmailConfirmed(usecases);

        var loginUser = usecases.LoginUserUseCase();
        var task = loginUser.Execute(new LoginUserDto("", "long_and_secure_password"));

        await Assert.ThrowsAsync<NotFoundException>(async () => await task);
    }

    [Fact]
    public async Task Login_WrongPassword_ReturnLoggedUser()
    {
        var usecases = new UseCasesFactory(Context);

        var user = await UserSample.SetupUserEmailConfirmed(usecases);

        var loginUser = usecases.LoginUserUseCase();

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
