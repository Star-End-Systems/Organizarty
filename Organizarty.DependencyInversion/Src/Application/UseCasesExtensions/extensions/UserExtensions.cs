using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Organizarty.Application.App.Users.Entities;
using Organizarty.Application.App.Users.UseCases;

namespace Organizarty.DependencyInversion.Application.UseCasesExtensions;

internal static class UserExtensions
{
    public static IServiceCollection AddUserUsecases(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<UserValidator>();

        services.AddScoped<ConfirmCodeUseCase>();
        services.AddScoped<LoginUserUseCase>();
        services.AddScoped<RegisterUserUseCase>();
        services.AddScoped<SendEmailConfirmUseCase>();
        services.AddScoped<SelectUserUseCase>();

        return services;
    }
}
