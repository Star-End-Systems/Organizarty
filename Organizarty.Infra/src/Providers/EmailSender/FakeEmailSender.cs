using Microsoft.Extensions.Logging;
using Organizarty.Adapters;

namespace Organizarty.Infra.Providers.EmailSender.Mailgun;

public class FakeEmailSender : IEmailSender
{
    private readonly ILogger<FakeEmailSender> _logger;

    public FakeEmailSender(ILogger<FakeEmailSender> logger)
    {
        _logger = logger;
    }

    public Task SendEmailVerificationCode(string code, string targetEmail)
    {
        var msg = $" \"{targetEmail}\" => {code} <= ";

        _logger.LogInformation(msg);

        return Task.CompletedTask;
    }
}
