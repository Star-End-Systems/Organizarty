using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Organizarty.Application.App.Foods.Entities;
using Organizarty.Application.App.Foods.UseCases;

namespace Organizarty.DependencyInversion.Application.UseCasesExtensions;

internal static class FoodInfoExtension
{
    public static IServiceCollection AddFoodsUseCases(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<FoodInfoValidator>();
        services.AddScoped<CreateFoodUseCase>();
        services.AddScoped<CreateFoodItemUseCase>();

        services.AddScoped<SelectFoodsUseCase>();

        return services;
    }
}
