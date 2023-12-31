using DotNetEnv;
using Microsoft.Extensions.DependencyInjection;

namespace Organizarty.DependencyInversion.Application;

public static class EnvironmentInjection
{
    public static IServiceCollection AddEnvironment(this IServiceCollection services)
    {
        Env.TraversePath().Load();

        return services;
    }
}
