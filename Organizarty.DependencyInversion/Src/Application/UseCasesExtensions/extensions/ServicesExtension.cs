using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Organizarty.Application.App.Services.Entities;
using Organizarty.Application.App.Services.UseCases;

namespace Organizarty.DependencyInversion.Application.UseCasesExtensions;

internal static class ServicesExtension
{
    public static IServiceCollection AddServicesUsecases(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<ServiceInfoValidator>();
        services.AddScoped<CreateServiceInfoUseCase>();

        services.AddValidatorsFromAssemblyContaining<ServiceTypeValidator>();
        services.AddScoped<CreateServiceTypeUseCase>();

        services.AddScoped<EditServiceItemUseCase>();
        services.AddScoped<EditServiceSubItemUseCase>();

        services.AddScoped<SelectServicesUseCase>();
        return services;
    }
}
