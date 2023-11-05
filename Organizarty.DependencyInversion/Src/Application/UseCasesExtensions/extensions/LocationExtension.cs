using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Organizarty.Application.App.Locations.Entities;
using Organizarty.Application.App.Locations.UseCases;

namespace Organizarty.DependencyInversion.Application.UseCasesExtensions;

internal static class LocationExtension
{
    public static IServiceCollection AddLocationUsecases(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<LocationValidator>();

        services.AddScoped<CreateLocationUseCase>();

        return services;
    }
}
