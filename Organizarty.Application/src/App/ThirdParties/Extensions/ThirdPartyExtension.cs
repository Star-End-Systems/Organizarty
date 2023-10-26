using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Organizarty.Application.App.ThirdParties.Entities;
using Organizarty.Application.App.ThirdParties.UseCases;

namespace Organizarty.Application.Extensions;

internal static class ThirdPartyExtension
{
    public static IServiceCollection AddThirdPartyUsecases(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<ThirdPartyValidator>();

        services.AddScoped<RegisterThirdPartyUseCase>();
        services.AddScoped<LoginThirdPartyUseCase>();
        services.AddScoped<AuthorizeThirdPartyUseCase>();

        return services;
    }
}
