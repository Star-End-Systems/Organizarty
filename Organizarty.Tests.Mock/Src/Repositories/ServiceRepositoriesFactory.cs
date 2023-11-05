using Organizarty.Infra.Repositories.Services;

namespace Organizarty.Tests.Mock.Repositories;

public partial class RepositoriesFactory
{
    public ServiceTypeRepository ServiceTypeRepository()
      => new ServiceTypeRepository(_context);

    public ServiceInfoRepository ServiceInfoRepository()
      => new ServiceInfoRepository(_context);
}

