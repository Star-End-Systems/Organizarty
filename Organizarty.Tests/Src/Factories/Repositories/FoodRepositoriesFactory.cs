using Organizarty.Infra.Repositories.Foods;

namespace Organizarty.Tests.Factories.Repositories;

public partial class RepositoriesFactory
{
    public FoodTypeRepository FoodTypeRepository()
      => new FoodTypeRepository(_context);

    public FoodInfoRepository FoodInfoRepository()
      => new FoodInfoRepository(_context);
}

