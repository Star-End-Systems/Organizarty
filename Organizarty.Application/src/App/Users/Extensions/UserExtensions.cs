using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Organizarty.Application.App.Users.Entities;
using Organizarty.Application.App.Users.UseCases;

namespace Organizarty.Application.Extensions;

internal static class UserExtensions
{
    public static IServiceCollection AddUserUsecases(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<UserValidator>();

        services.AddScoped<ConfirmCodeUseCase>();
        services.AddScoped<RegisterUserUseCase>();
        services.AddScoped<SendEmailConfirmUseCase>();

        return services;
    }
}
