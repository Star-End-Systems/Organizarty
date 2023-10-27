using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Organizarty.Application.App.ServiceTypes.Entities;
using Organizarty.Application.App.ServiceTypes.UseCases;

namespace Organizarty.Application.Extensions;

internal static class ServiceTypeExtension
{
    public static IServiceCollection AddServiceTypeUsecases(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<ServiceTypeValidator>();

        services.AddScoped<CreateServiceTypeUseCase>();

        return services;
    }
}
