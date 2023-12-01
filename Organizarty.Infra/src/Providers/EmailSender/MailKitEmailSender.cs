using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using MimeKit;
using Organizarty.Adapters;
using Organizarty.Application.Exceptions;

namespace Organizarty.Infra.Providers.EmailSender.Mailgun;

public class MailKitEmailSender : IEmailSender
{
    public class Configuration : EmailSenderConfiguration
    {
        public string Username { get; }
        public string Password { get; }
        public string Server { get; }
        public int Port { get; }
        public bool IsDevelopment { get; }

        public Configuration()
        {
            Username = Environment.GetEnvironmentVariable("MAILKIT_USERNAME") ?? throw new InvalidOperationException("<MAILKIT_USERNAME> not found");
            Password = Environment.GetEnvironmentVariable("MAILKIT_PASSWORD") ?? throw new InvalidOperationException("<MAILKIT_PASSWORD> not found");
            Server = Environment.GetEnvironmentVariable("MAILKIT_SMTP_SERVER") ?? throw new InvalidOperationException("<MAILKIT_SMTP_SERVER> not found");
            Port = int.Parse(Environment.GetEnvironmentVariable("MAILKIT_SMTP_PORT") ?? throw new InvalidOperationException("<MAILKIT_SMTP_PORT> not found"));
            IsDevelopment = bool.Parse(Environment.GetEnvironmentVariable("MAILKIT_DEV") ?? "true");
        }
    }

    private readonly Configuration _settings;


    public MailKitEmailSender(Configuration settings)
    {
        _settings = settings;
    }

    public async Task SendEmailVerificationCode(string code, string targetEmail)
    {
        try
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress(_settings.DisplayName,
                                                _settings.Domain));
            message.To.Add(new MailboxAddress("destino", targetEmail));
            message.Subject = "Pedrao";
            message.Body = new TextPart("plain")
            {
                Text = $"<p>Confirma teu email jovem, code => {code}</p>"
            };

            using (var client = new SmtpClient())
            {
                // client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                // if (_settings.IsDevelopment)
                // {
                await client.ConnectAsync(_settings.Server,
                                          _settings.Port, true);
                // }
                // else
                // {
                //     await client.ConnectAsync(_settings.Server);
                // }

                await client.AuthenticateAsync(_settings.Username, _settings.Password);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
        catch (Exception e)
        {
            throw new InvalidOperationException(e.Message);
        }
    }
}
