using Organizarty.Adapters;

namespace Organizarty.Tests.Mock.Adapters;

public class EmailSenderMock : IEmailSender
{
    public async Task SendEmailVerificationCode(string code, string targetEmail)
      => await Task.Run(() => code);
}
