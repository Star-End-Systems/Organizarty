using Organizarty.Application.App.Users.Entities;
using Organizarty.Application.App.Users.UseCases;

namespace Organizarty.Tests.Unit.Samples.Users;

public static class UserSample
{
    public static async Task<User> SetupUser(RegisterUserUseCase registerUser)
    {
        var data = new RegisterUserDto("testuser", "Test User Da Silva", "São Paulo, SP", $"user-{Guid.NewGuid().ToString()}@test.com", "long_and_secure_password", null);

        return await registerUser.Execute(data);
    }

    public static async Task<User> SetupUserEmailConfirmed(RegisterUserUseCase registerUser, SendEmailConfirmUseCase sendEmailConfirm, ConfirmCodeUseCase confirmCode)
    {
        var user = await UserSample.SetupUser(registerUser);

        var code = (await sendEmailConfirm.Execute(user)).Id;

        return await confirmCode.Execute(code);
    }
}
