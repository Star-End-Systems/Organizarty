using Organizarty.Infra.Repositories.PartyTemplate;

namespace Organizarty.Tests.Mock.Repositories;

public partial class RepositoriesFactory
{
    public PartyTemplateRepository PartyTemplateRepository()
      => new PartyTemplateRepository(_context);

    public FoodGroupRepository FoodGroupRepository()
      => new FoodGroupRepository(_context);

    public ServiceGroupRepository ServiceGroupRepository()
      => new ServiceGroupRepository(_context);

    public DecorationGroupRepository DecorationGroupRepository()
      => new DecorationGroupRepository(_context);
}

