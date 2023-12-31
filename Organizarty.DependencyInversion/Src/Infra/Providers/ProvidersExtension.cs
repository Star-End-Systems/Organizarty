using Microsoft.Extensions.DependencyInjection;
using Organizarty.Adapters;
using Organizarty.Infra.Providers.Cryptography.Pbkdf2;
using Organizarty.Infra.Providers.EmailSender.Mailgun;
using Organizarty.Infra.Providers.ImageUpload;
using Organizarty.Infra.Providers.Token;

namespace Organizarty.DependencyInversion.Infra.Providers;

public static class ProvidersExtension
{
    public static IServiceCollection AddProviders(this IServiceCollection services, bool isDevelopment = true)
    {
        services.AddProvidersConfiguration();
        services.AddEmailSender(isDevelopment);
        services.AddScoped<ICryptographys, Pbkdf2Cryptography>();
        services.AddScoped<ITokenProvider, JwtTokenProvider>();
        services.AddScoped<IImageUpload, SupabaseImageUpload>();

        return services;
    }

    private static IServiceCollection AddEmailSender(this IServiceCollection services, bool isDevelopment = true)
    {
        if (isDevelopment)
        {
            services.AddScoped<IEmailSender, FakeEmailSender>();
        }
        else
        {
            services.AddScoped<IEmailSender, MailgunEmailSender>();
        }

        return services;
    }
}
