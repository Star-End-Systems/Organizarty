using Organizarty.Infra.Repositories.ThirdParties;

namespace Organizarty.Tests.Mock.Repositories;

public partial class RepositoriesFactory
{
    public ThirdPartyRepository ThirdPartyRepository()
      => new ThirdPartyRepository(_context);
}

