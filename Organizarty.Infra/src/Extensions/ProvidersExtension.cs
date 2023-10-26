using Microsoft.Extensions.DependencyInjection;
using Organizarty.Adapters;
using Organizarty.Infra.Providers.Cryptography.Pbkdf2;
using Organizarty.Infra.Providers.EmailSender.Mailgun;
using Organizarty.Infra.Providers.Token;

namespace Organizarty.Infra.Extensions;

public static class ProvidersExtension
{
    public static IServiceCollection AddProviders(this IServiceCollection services)
    {
        services.AddProvidersConfiguration();
        services.AddScoped<IEmailSender, MailgunEmailSender>();
        services.AddScoped<ICryptographys, Pbkdf2Cryptography>();
        services.AddScoped<ITokenProvider, JwtTokenProvider>();

        return services;
    }

}
