using Organizarty.Application.App.Users.Entities;
using Organizarty.Application.App.Users.UseCases;
using Organizarty.Tests.Mock.Adapters;

namespace Organizarty.Tests.Mock.UseCases;

public partial class UseCasesFactory
{
    public RegisterUserUseCase RegisterUserUseCase()
    {
        var userRepo = _repositories.UserRepository();
        return new RegisterUserUseCase(userRepo, new CryptographyMock(), new UserValidator(), SendEmailConfirmUseCase());
    }

    public LoginUserUseCase LoginUserUseCase()
    {
        var userRepo = _repositories.UserRepository();

        return new LoginUserUseCase(new CryptographyMock(), userRepo);
    }

    public SendEmailConfirmUseCase SendEmailConfirmUseCase()
    {
        var confirmRepo = _repositories.UserConfirmationRepository();
        var userRepo = _repositories.UserRepository();

        return new SendEmailConfirmUseCase(confirmRepo, new EmailSenderMock(), userRepo);
    }

    public ConfirmCodeUseCase ConfirmCodeUseCase()
    {
        var confirmRepo = _repositories.UserConfirmationRepository();
        var userRepo = _repositories.UserRepository();

        return new ConfirmCodeUseCase(confirmRepo, userRepo);
    }
}
