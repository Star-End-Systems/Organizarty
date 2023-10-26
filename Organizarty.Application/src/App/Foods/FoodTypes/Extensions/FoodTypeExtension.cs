using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Organizarty.Application.App.FoodTypes.Entities;
using Organizarty.Application.App.FoodTypes.UseCases;

namespace Organizarty.Application.Extensions;

internal static class FoodTypeExtension
{
    public static IServiceCollection AddFoodTypeUsecases(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<FoodTypeValidator>();
        services.AddScoped<CreateFoodTypeUseCase>();

        return services;
    }
}
