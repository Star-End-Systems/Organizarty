using Microsoft.Extensions.DependencyInjection;
using Organizarty.UI.Helpers;

namespace Organizarty.DependencyInversion.Application.UseCasesExtensions;

public static class HelperExtension
{
    public static IServiceCollection AddHelpers(this IServiceCollection services)
    {
        services.AddScoped<AuthenticationHelper>();
        return services;
    }
}
