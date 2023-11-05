using Microsoft.Extensions.DependencyInjection;
using Organizarty.Application.App.Schedules.UseCases;

namespace Organizarty.DependencyInversion.Application.UseCasesExtensions;

internal static class ScheduleExtension
{
    public static IServiceCollection AddScheduleUsecases(this IServiceCollection services)
    {
        services.AddScoped<ScheduleUseCase>();
        services.AddScoped<OrderDecorationUseCase>();
        services.AddScoped<OrderFoodUseCase>();
        services.AddScoped<OrderServiceUseCase>();
        services.AddScoped<SelectScheduleUseCase>();
        services.AddScoped<ChangeItemStatusUseCase>();

        return services;
    }
}
