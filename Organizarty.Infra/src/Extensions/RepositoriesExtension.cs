using Microsoft.Extensions.DependencyInjection;
using Organizarty.Application.App.FoodInfos.Data;
using Organizarty.Application.App.FoodTypes.Data;
using Organizarty.Application.App.ThirdParties.Data;
using Organizarty.Application.App.Users.Data;
using Organizarty.Infra.Repositories.Foods;
using Organizarty.Infra.Repositories.ThirdParties;
using Organizarty.Infra.Repositories.Users;

namespace Organizarty.Infra.Extensions;

public static class RepositoriesExtension
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserConfirmationRepository, UserConfirmationRepository>();

        services.AddScoped<IThirdPartyRepository, ThirdPartyRepository>();

        services.AddScoped<IFoodTypeRepository, FoodTypeRepository>();
        services.AddScoped<IFoodInfoRepository, FoodInfoRepository>();

        return services;
    }
}
