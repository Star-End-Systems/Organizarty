using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Organizarty.Application.App.Managers.Entities;
using Organizarty.Application.App.Managers.UseCases;

namespace Organizarty.DependencyInversion.Application.UseCasesExtensions;

internal static class ManagerExtension
{
    public static IServiceCollection AddManagerUsecases(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<ManagerValidator>();

        services.AddScoped<LoginManagerUseCase>();
        services.AddScoped<RegisterManagerUseCase>();

        services.AddScoped<SelectManagerUseCase>();

        return services;
    }
}
