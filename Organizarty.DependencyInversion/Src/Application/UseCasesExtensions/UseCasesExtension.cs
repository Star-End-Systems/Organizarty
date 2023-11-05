using Microsoft.Extensions.DependencyInjection;

namespace Organizarty.DependencyInversion.Application.UseCasesExtensions;

public static class UseCasesExtension
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddUserUsecases();

        services.AddThirdPartyUsecases();

        services.AddManagerUsecases();

        services.AddFoodTypeUsecases();
        services.AddFoodInfoUsecases();

        services.AddDecorationInfoUsecases();
        services.AddDecorationTypeUsecases();

        services.AddServiceTypeUsecases();
        services.AddServiceInfoUsecases();

        services.AddLocationUsecases();
        services.AddPartyUsecases();

        services.AddScheduleUsecases();

        return services;
    }
}