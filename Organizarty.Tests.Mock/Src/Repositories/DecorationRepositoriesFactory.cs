using Organizarty.Infra.Repositories.Decorations;

namespace Organizarty.Tests.Mock.Repositories;

public partial class RepositoriesFactory
{
    public DecorationTypeRepository DecorationTypeRepository()
      => new DecorationTypeRepository(_context);

    public DecorationInfoRepository DecorationInfoRepository()
      => new DecorationInfoRepository(_context);
}

