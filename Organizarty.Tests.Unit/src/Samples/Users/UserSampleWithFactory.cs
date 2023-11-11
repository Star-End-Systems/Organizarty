using Organizarty.Application.App.Users.Entities;
using Organizarty.Tests.Mock.UseCases;

namespace Organizarty.Tests.Unit.Samples.Users;

public static partial class UserSample
{
    public static async Task<User> SetupUserEmailConfirmed(UseCasesFactory usecases)
    {
        var registerUser = usecases.RegisterUserUseCase();
        var sendCode = usecases.SendEmailConfirmUseCase();
        var confirmCode = usecases.ConfirmCodeUseCase();

        return await UserSample.SetupUserEmailConfirmed(registerUser, sendCode, confirmCode);
    }
}
