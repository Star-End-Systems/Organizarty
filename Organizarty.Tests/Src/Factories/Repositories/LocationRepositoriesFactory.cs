using Organizarty.Infra.Repositories.Locations;

namespace Organizarty.Tests.Factories.Repositories;

public partial class RepositoriesFactory
{
    public LocationRepository LocationRepository()
      => new LocationRepository(_context);
}

