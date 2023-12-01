using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Organizarty.Infra.Data.Contexts;

namespace Organizarty.DependencyInversion.Infra.Database;

public static class DatabaseExtension
{
    private static string GetConnectionString(IConfiguration configuration)
    {
        string? envConnectionString = Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING");

        if (envConnectionString is not null)
        {
            return envConnectionString;
        }

        return configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connect string not found");
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
                  options.UseMySql(GetConnectionString(configuration),
                  new MySqlServerVersion(new Version(8, 0, 26)),
                  b =>
                  {
                      b.EnableRetryOnFailure(
                          maxRetryCount: 5,
                          maxRetryDelay: TimeSpan.FromSeconds(30),
                          errorNumbersToAdd: null
                          );
                      b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                  }

                ));

        return services;
    }

    public static IServiceCollection AddInMemoryDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
                  options.UseInMemoryDatabase("Organizarty"));

        return services;
    }
}
