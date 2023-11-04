using Organizarty.Infra.Repositories.ThirdParties;

namespace Organizarty.Tests.Factories.Repositories;

public partial class RepositoriesFactory
{
    public ThirdPartyRepository ThirdPartyRepository()
      => new ThirdPartyRepository(_context);
}

