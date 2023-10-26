namespace Organizarty.Adapters;

public interface IEmailSender
{
    Task SendEmailVerificationCode(string code, string targetEmail);
}
