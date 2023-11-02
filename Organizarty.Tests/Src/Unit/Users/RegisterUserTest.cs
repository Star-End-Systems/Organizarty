using Organizarty.Application.App.Users.UseCases;
using Organizarty.Application.Exceptions;
using Organizarty.Tests.Factories.Database;
using Organizarty.Tests.Factories.Repositories;
using Organizarty.Tests.Factories.UseCases;
using Organizarty.Tests.Samples.Users;

namespace Organizarty.Tests.Unit.Users;

public class RegisterUserTest
{
    [Fact]
    public async Task RegisterSample_ValidData_ReturnCreatedUser()
    {
        var context = DatabaseFactory.InMemoryDatabase();
        var userRepo = new RepositoriesFactory(context).UserRepository();
        var registerUser = new UseCasesFactory().RegisterUserUseCase(userRepo);

        var user = await UserSample.SetupUser(registerUser);

        Assert.NotEqual(Guid.Empty, user.Id);
        Assert.False(user.EmailConfirmed);
    }

    [Fact]
    public async Task Register_InvalidEmail_ReturnCreatedUser()
    {
        var context = DatabaseFactory.InMemoryDatabase();
        var userRepo = new RepositoriesFactory(context).UserRepository();
        var registerUser = new UseCasesFactory().RegisterUserUseCase(userRepo);

        var data = new RegisterUserDto("testuser", "Test User Da Silva", "São Paulo, SP", "invalid_email", "long_and_secure_password", null);
        
        var task = registerUser.Execute(data);

        await Assert.ThrowsAsync<ValidationFailException>(async () => await task);
    }
}
