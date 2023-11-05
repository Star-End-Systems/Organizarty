using Microsoft.Extensions.DependencyInjection;

using Organizarty.Application.App.DecorationInfos.Data;
using Organizarty.Application.App.DecorationTypes.Data;
using Organizarty.Application.App.FoodInfos.Data;
using Organizarty.Application.App.FoodTypes.Data;
using Organizarty.Application.App.Locations.Data;
using Organizarty.Application.App.Managers.Data;
using Organizarty.Application.App.Party.Data;
using Organizarty.Application.App.Schedules.Data;
using Organizarty.Application.App.ServiceInfos.Data;
using Organizarty.Application.App.Services.Data;
using Organizarty.Application.App.ThirdParties.Data;
using Organizarty.Application.App.Users.Data;
using Organizarty.Infra.Repositories.Decorations;
using Organizarty.Infra.Repositories.Foods;
using Organizarty.Infra.Repositories.Locations;
using Organizarty.Infra.Repositories.Managers;
using Organizarty.Infra.Repositories.PartyTemplate;
using Organizarty.Infra.Repositories.Schedules;
using Organizarty.Infra.Repositories.Services;
using Organizarty.Infra.Repositories.ThirdParties;
using Organizarty.Infra.Repositories.Users;

namespace Organizarty.DependencyInversion.Infra.Repositories;

public static class RepositoriesExtension
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserConfirmationRepository, UserConfirmationRepository>();

        services.AddScoped<IThirdPartyRepository, ThirdPartyRepository>();

        services.AddScoped<IManagerRepository, EFManagerRepository>();

        services.AddScoped<IFoodTypeRepository, FoodTypeRepository>();
        services.AddScoped<IFoodInfoRepository, FoodInfoRepository>();

        services.AddScoped<IDecorationTypeRepository, DecorationTypeRepository>();
        services.AddScoped<IDecorationInfoRepository, DecorationInfoRepository>();

        services.AddScoped<IServiceTypeRepository, ServiceTypeRepository>();
        services.AddScoped<IServiceInfoRepository, ServiceInfoRepository>();

        services.AddScoped<IScheduleRepository, ScheduleRepository>();
        services.AddScoped<IFoodOrderRepository, FoodOrderRepository>();
        services.AddScoped<IDecorationOrderRepository, DecorationOrderRepository>();
        services.AddScoped<IServiceOrderRepository, ServiceOrderRepository>();

        services.AddScoped<ILocationRepository, LocationRepository>();

        services.AddScoped<IPartyTemplateRepository, PartyTemplateRepository>();
        services.AddScoped<IDecorationGroupRepository, DecorationGroupRepository>();
        services.AddScoped<IFoodGroupRepository, FoodGroupRepository >();
        services.AddScoped<IServiceGroupRepository, ServiceGroupRepository>();

        return services;
    }
}
