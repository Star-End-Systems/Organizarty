namespace Organizarty.Infra.Providers.EmailSender;

public class EmailSenderConfiguration
{
    public string Domain { get; }

    public string DisplayName { get; }
    public string From { get; }
    public string ReplyTo { get; }

    public EmailSenderConfiguration()
    {
        Domain = Environment.GetEnvironmentVariable("EMAILSENDER_DOMAIN") ?? throw new InvalidOperationException("Email domain not founded");
        DisplayName = Environment.GetEnvironmentVariable("EMAILSENDER_DISPLAY_NAME") ?? throw new InvalidOperationException("Email Display name not founded");
        From = Environment.GetEnvironmentVariable("EMAILSENDER_FROM") ?? throw new InvalidOperationException("Email 'FROM' not founded");
        ReplyTo = Environment.GetEnvironmentVariable("EMAILSENDER_REPLYTO") ?? throw new InvalidOperationException("Email 'Reply To' not founded");
    }
}
