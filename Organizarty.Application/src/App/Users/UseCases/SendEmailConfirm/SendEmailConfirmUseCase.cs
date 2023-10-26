using Organizarty.Adapters;
using Organizarty.Application.App.Users.Data;
using Organizarty.Application.App.Users.Entities;

namespace Organizarty.Application.App.Users.UseCases;

public class SendEmailConfirmUseCase
{
    private readonly IUserConfirmationRepository _confirmRepository;
    private readonly TimeSpan TOKEN_MAX_AGE = TimeSpan.FromHours(24);
    private readonly IEmailSender _emailSender;

    public SendEmailConfirmUseCase(IUserConfirmationRepository confirmRepository, IEmailSender emailSender)
    {
        _confirmRepository = confirmRepository;
        _emailSender = emailSender;
    }

    public async Task<UserConfirmation> Execute(User user)
    {
        var confirm = new UserConfirmation
        {
            UserId = user.Id,
            ValidFor = DateTime.Now.Add(TOKEN_MAX_AGE)
        };

        var code = await _confirmRepository.Create(confirm);
        await _emailSender.SendEmailVerificationCode(code.Id.ToString(), user.Email);
        return code;
    }
}
