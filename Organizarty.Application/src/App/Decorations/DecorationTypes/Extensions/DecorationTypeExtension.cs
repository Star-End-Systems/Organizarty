using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Organizarty.Application.App.DecorationTypes.Entities;
using Organizarty.Application.App.DecorationTypes.UseCases;

namespace Organizarty.Application.Extensions;

internal static class DecorationTypeExtension
{
    public static IServiceCollection AddDecorationTypeUsecases(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<DecorationTypeValidator>();

        services.AddScoped<CreateDecorationTypeUseCase>();
        services.AddScoped<SelectDecorationTypeUseCase>();

        return services;
    }
}
