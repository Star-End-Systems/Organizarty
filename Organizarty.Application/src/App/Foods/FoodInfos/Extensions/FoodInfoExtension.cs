using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Organizarty.Application.App.FoodInfos.Entities;
using Organizarty.Application.App.FoodInfos.UseCases;

namespace Organizarty.Application.Extensions;

internal static class FoodInfoExtension
{
    public static IServiceCollection AddFoodInfoUsecases(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<FoodInfoValidator>();
        services.AddScoped<CreateFoodInfoUseCase>();

        return services;
    }
}
