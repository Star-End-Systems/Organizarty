using System.Net.Http.Headers;
using System.Text;
using Organizarty.Adapters;
using Organizarty.Application.Exceptions;

namespace Organizarty.Infra.Providers.EmailSender.Mailgun;

public class MailgunEmailSender : IEmailSender
{
    private readonly MailgunConfiguration _emailconfiguration;

    public MailgunEmailSender(MailgunConfiguration mailgunConfiguration)
    {
        _emailconfiguration = mailgunConfiguration;
    }

    public async Task SendEmailVerificationCode(string code, string targetEmail)
    {
        using (var httpClient = new HttpClient())
        {
            var authToken = Encoding.ASCII.GetBytes($"api:{_emailconfiguration.ApiKey}");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authToken));

            var confirmUrl = _emailconfiguration.ConfirmEndpoint + code;

            var formContent = new FormUrlEncodedContent(new Dictionary<string, string> {
              { "from", $"Mailgun Sandbox <postmaster@{_emailconfiguration.Domain}>"},
              { "h:Reply-To", $"{_emailconfiguration.DisplayName} <{_emailconfiguration.ReplyTo}>" },
              { "to", targetEmail },
              { "subject", "Email confirm" },
              { "text", $"Place confirm your email using this code {confirmUrl}" }
            });

            var result = await httpClient.PostAsync($"https://api.mailgun.net/v3/{_emailconfiguration.Domain}/messages", formContent);

            if (!result.IsSuccessStatusCode)
            {
                string responseBody = await result.Content.ReadAsStringAsync();
                throw new EmailsenderException(responseBody);
            }
        }
    }
}
