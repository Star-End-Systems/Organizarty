using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Organizarty.Application.App.DecorationInfos.Entities;
using Organizarty.Application.App.DecorationInfos.UseCases;

namespace Organizarty.Application.Extensions;

internal static class DecorationInfoExtension
{
    public static IServiceCollection AddDecorationInfoUsecases(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<DecorationInfoValidator>();

        services.AddScoped<CreateDecorationInfoUseCase>();

        return services;
    }
}
