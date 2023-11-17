using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Organizarty.Application.App.ThirdParties.Entities;
using Organizarty.Application.App.ThirdParties.UseCases;

namespace Organizarty.DependencyInversion.Application.UseCasesExtensions;

internal static class ThirdPartyExtension
{
    public static IServiceCollection AddThirdPartyUsecases(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<ThirdPartyValidator>();

        services.AddScoped<RegisterThirdPartyUseCase>();
        services.AddScoped<LoginThirdPartyUseCase>();
        services.AddScoped<AuthorizeThirdPartyUseCase>();
        services.AddScoped<SelectThirdPartyUseCase>();

        return services;
    }
}
