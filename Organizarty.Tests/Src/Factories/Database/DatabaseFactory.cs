using Microsoft.EntityFrameworkCore;
using Organizarty.Infra.Data.Contexts;

namespace Organizarty.Tests.Factories.Database;

public class DatabaseFactory
{
    public static ApplicationDbContext InMemoryDatabase()
      => new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>()
                      .UseInMemoryDatabase(databaseName: "Organizarty_test")
                      .Options);
}
