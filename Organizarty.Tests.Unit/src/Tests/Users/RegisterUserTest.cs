using Organizarty.Application.App.Users.UseCases;
using Organizarty.Infra.Data.Contexts;
using Organizarty.Tests.Mock.Database;
using Organizarty.Tests.Mock.Repositories;
using Organizarty.Tests.Mock.UseCases;
using Organizarty.Tests.Unit.Samples.Users;

namespace Organizarty.Tests.Unit.Tests.Mock;

public class RegisterUserTest : IAsyncLifetime
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
    public async Task RegisterSample_ValidData_ReturnCreatedUser()
    {
        var usecases = new UseCasesFactory(Context);

        var registerUser = usecases.RegisterUserUseCase();

        var user = await UserSample.SetupUser(registerUser);

        Assert.NotEqual(Guid.Empty, user.Id);
        Assert.False(user.EmailConfirmed);
    }

    [Fact]
    public async Task Register_InvalidEmail_ReturnCreatedUser()
    {
        var usecases = new UseCasesFactory(Context);

        var registerUser = usecases.RegisterUserUseCase();

        var data = new RegisterUserDto("testuser", "Test User Da Silva", "São Paulo, SP", "invalid_email", "long_and_secure_password", null);

        var task = registerUser.Execute(data);

        await Assert.ThrowsAsync<ValidationFailException>(async () => await task);
    }
}
