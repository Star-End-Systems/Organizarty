using Microsoft.Extensions.DependencyInjection;
using Organizarty.Infra.Providers.EmailSender.Mailgun;

namespace Organizarty.Infra.Extensions;

internal static class ProvidersConfigrationExtensions
{
    public static IServiceCollection AddProvidersConfiguration(this IServiceCollection services)
    {
        services.AddSingleton<MailgunConfiguration>();

        return services;
    }

}
