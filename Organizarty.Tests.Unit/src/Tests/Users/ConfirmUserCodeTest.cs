using Organizarty.Infra.Data.Contexts;
using Organizarty.Tests.Mock.Database;
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
        var usecases = new UseCasesFactory(Context);
        var registerUser = usecases.RegisterUserUseCase();
        var sendCode = usecases.SendEmailConfirmUseCase();
        var confirmCode = usecases.ConfirmCodeUseCase();

        var user = await UserSample.SetupUser(registerUser);

        var code = (await sendCode.Execute(user.Email)).Code;

        Assert.NotEqual(string.Empty, code);

        var u = await confirmCode.Execute(code, user.Email);

        Assert.True(u.EmailConfirmed);
    }

    [Fact]
    public async Task ConfirmEmailCode_Sample_ReturnCreatedUser()
    {
        var usecases = new UseCasesFactory(Context);

        var user = await UserSample.SetupUserEmailConfirmed(usecases);

        Assert.NotNull(user);
    }
}
