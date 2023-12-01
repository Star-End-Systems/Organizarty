using Microsoft.Extensions.DependencyInjection;
using Organizarty.Infra.Providers.EmailSender.Mailgun;
using Organizarty.Infra.Providers.ImageUpload;

namespace Organizarty.DependencyInversion.Infra.Providers;

internal static class ProvidersConfigrationExtensions
{
    public static IServiceCollection AddProvidersConfiguration(this IServiceCollection services)
    {
        services.AddSingleton<MailgunConfiguration>();
        services.AddSingleton<SupabaseImageUpload.Configuration>();

        return services;
    }

}
