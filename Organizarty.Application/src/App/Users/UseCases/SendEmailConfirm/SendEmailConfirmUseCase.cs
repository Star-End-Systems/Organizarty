using NanoidDotNet;
using Organizarty.Adapters;
using Organizarty.Application.App.Users.Data;
using Organizarty.Application.App.Users.Entities;
using Organizarty.Application.Exceptions;

namespace Organizarty.Application.App.Users.UseCases;

public class SendEmailConfirmUseCase
{
    private readonly IUserConfirmationRepository _confirmRepository;
    private readonly IUserRepository _userRepository;
    private readonly IEmailSender _emailSender;

    private readonly TimeSpan CODE_MAX_AGE = TimeSpan.FromHours(24);
    private readonly int CODE_SIZE = 4;
    public readonly string CODE_VALID_CHARACTERS = "1234567890";

    public SendEmailConfirmUseCase(IUserConfirmationRepository confirmRepository, IEmailSender emailSender, IUserRepository userRepository)
    {
        _confirmRepository = confirmRepository;
        _emailSender = emailSender;
        _userRepository = userRepository;
    }

    public async Task<UserConfirmation> Execute(string email)
    {
        var confirm = new UserConfirmation
        {
            ValidFor = DateTime.Now.Add(CODE_MAX_AGE),
            Code = GetCode(),
            UserEmail= email
        };

        var code = await _confirmRepository.Create(confirm);

        await _emailSender.SendEmailVerificationCode(code.Code, email);

        return code;
    }

    private string GetCode() => Nanoid.Generate(CODE_VALID_CHARACTERS, size: CODE_SIZE);
}
