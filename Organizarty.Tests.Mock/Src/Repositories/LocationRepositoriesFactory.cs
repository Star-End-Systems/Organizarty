using Organizarty.Infra.Repositories.Locations;

namespace Organizarty.Tests.Mock.Repositories;

public partial class RepositoriesFactory
{
    public LocationRepository LocationRepository()
      => new LocationRepository(_context);
}

