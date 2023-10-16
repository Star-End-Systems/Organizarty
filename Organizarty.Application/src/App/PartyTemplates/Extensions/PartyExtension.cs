using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Organizarty.Application.App.Party.Entities;
using Organizarty.Application.App.Party.UseCases;

namespace Organizarty.Application.Extensions;

internal static class PartyExtension
{
    public static IServiceCollection AddPartyUsecases(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<PartyTemplateValidator>();

        services.AddScoped<CreatePartyUseCase>();

        services.AddScoped<AddFoodToPartyUseCase>();
        services.AddScoped<AddDecorationToPartyUseCase>();
        services.AddScoped<AddServiceToPartyUsecase>();

        return services;
    }
}
