using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Organizarty.Application.App.ServiceInfos.Entities;
using Organizarty.Application.App.ServiceInfos.UseCases;

namespace Organizarty.DependencyInversion.Application.UseCasesExtensions;

internal static class ServiceInfoExtension
{
    public static IServiceCollection AddServiceInfoUsecases(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<ServiceInfoValidator>();

        services.AddScoped<CreateServiceInfoUseCase>();

        return services;
    }
}
