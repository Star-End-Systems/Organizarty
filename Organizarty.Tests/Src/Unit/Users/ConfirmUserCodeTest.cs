using Organizarty.Tests.Factories.Database;
using Organizarty.Tests.Factories.Repositories;
using Organizarty.Tests.Factories.UseCases;
using Organizarty.Tests.Samples.Users;

namespace Organizarty.Tests.Unit.Users;

public class ConfirmUserCodeTest
{
    [Fact]
    public async Task ConfirmEmailCode_ValidData_ReturnCreatedUser()
    {
        var context = DatabaseFactory.InMemoryDatabase();
        var userRepo = new RepositoriesFactory(context).UserRepository();
        var confirmRepo = new RepositoriesFactory(context).UserConfirmationRepository();

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
        var context = DatabaseFactory.InMemoryDatabase();
        var userRepo = new RepositoriesFactory(context).UserRepository();
        var confirmRepo = new RepositoriesFactory(context).UserConfirmationRepository();

        var registerUser = new UseCasesFactory().RegisterUserUseCase(userRepo);
        var sendCode = new UseCasesFactory().SendEmailConfirmUseCase(confirmRepo);
        var confirmCode = new UseCasesFactory().ConfirmCodeUseCase(confirmRepo, userRepo);

        var user = await UserSample.SetupUserEmailConfirmed(registerUser, sendCode, confirmCode);

        Assert.NotNull(user);
    }
}
