using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Organizarty.Application.App.Party.Entities;
using Organizarty.Application.App.Party.UseCases;

namespace Organizarty.DependencyInversion.Application.UseCasesExtensions;

internal static class PartyExtension
{
    public static IServiceCollection AddPartyUsecases(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<PartyTemplateValidator>();

        services.AddScoped<CreatePartyUseCase>();

        services.AddScoped<AddFoodToPartyUseCase>();
        services.AddScoped<AddDecorationToPartyUseCase>();
        services.AddScoped<AddServiceToPartyUsecase>();

        services.AddScoped<SelectPartyUseCase>();

        return services;
    }
}
