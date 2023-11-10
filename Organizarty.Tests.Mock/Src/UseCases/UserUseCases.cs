using Organizarty.Application.App.Users.Data;
using Organizarty.Application.App.Users.Entities;
using Organizarty.Application.App.Users.UseCases;
using Organizarty.Tests.Mock.Adapters;
using Organizarty.Tests.Mock.Repositories;

namespace Organizarty.Tests.Mock.UseCases;

public partial class UseCasesFactory
{
    public RegisterUserUseCase RegisterUserUseCase()
    {
        var userRepo = _repositories.UserRepository();
        return new RegisterUserUseCase(userRepo, new CryptographyMock(), new UserValidator());
    }

    public LoginUserUseCase LoginUserUseCase()
    {
        var userRepo = _repositories.UserRepository();

        return new LoginUserUseCase(new CryptographyMock(), userRepo);
    }

    public SendEmailConfirmUseCase SendEmailConfirmUseCase()
    {
        var confirmRepo = _repositories.UserConfirmationRepository();
        return new SendEmailConfirmUseCase(confirmRepo, new EmailSenderMock());
    }

    public ConfirmCodeUseCase ConfirmCodeUseCase()
    {
        var confirmRepo = _repositories.UserConfirmationRepository();
        var userRepo = _repositories.UserRepository();

        return new ConfirmCodeUseCase(confirmRepo, userRepo);
    }
}
