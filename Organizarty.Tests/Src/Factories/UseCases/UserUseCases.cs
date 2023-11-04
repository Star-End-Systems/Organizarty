using Organizarty.Application.App.Users.Data;
using Organizarty.Application.App.Users.Entities;
using Organizarty.Application.App.Users.UseCases;
using Organizarty.Tests.Mock.Adapters;

namespace Organizarty.Tests.Factories.UseCases;

public partial class UseCasesFactory
{
    public RegisterUserUseCase RegisterUserUseCase(IUserRepository userRepository)
      => new RegisterUserUseCase(userRepository, new CryptographyMock(), new UserValidator());

    public LoginUserUseCase LoginUserUseCase(IUserRepository userRepository)
      => new LoginUserUseCase(new CryptographyMock(), userRepository);

    public SendEmailConfirmUseCase SendEmailConfirmUseCase(IUserConfirmationRepository confirmationRepository)
      => new SendEmailConfirmUseCase(confirmationRepository, new EmailSenderMock());

    public ConfirmCodeUseCase ConfirmCodeUseCase(IUserConfirmationRepository confirmationRepository, IUserRepository userRepository)
      => new ConfirmCodeUseCase(confirmationRepository, userRepository);
}
