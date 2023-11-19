using Microsoft.Extensions.DependencyInjection;

namespace Organizarty.DependencyInversion.Application.UseCasesExtensions;

public static class UseCasesExtension
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddUserUsecases();

        services.AddThirdPartyUsecases();

        services.AddManagerUsecases();

        services.AddFoodsUseCases();

        services.AddDecorationInfoUsecases();
        services.AddDecorationTypeUsecases();

        services.AddServicesUsecases();

        services.AddLocationUsecases();
        services.AddPartyUsecases();

        services.AddScheduleUsecases();

        return services;
    }
}
