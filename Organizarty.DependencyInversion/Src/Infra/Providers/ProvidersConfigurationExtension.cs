using Microsoft.Extensions.DependencyInjection;
using Organizarty.Infra.Providers.EmailSender.Mailgun;

namespace Organizarty.DependencyInversion.Infra.Providers;

internal static class ProvidersConfigrationExtensions
{
    public static IServiceCollection AddProvidersConfiguration(this IServiceCollection services)
    {
        services.AddSingleton<MailgunConfiguration>();

        return services;
    }

}
