using Organizarty.Infra.Repositories.Schedules;

namespace Organizarty.Tests.Mock.Repositories;

public partial class RepositoriesFactory
{
    public ScheduleRepository ScheduleRepository()
      => new ScheduleRepository(_context);

    public FoodOrderRepository FoodOrderRepository()
      => new FoodOrderRepository(_context);

    public ServiceOrderRepository ServiceOrderRepository()
      => new ServiceOrderRepository(_context);

    public DecorationOrderRepository DecorationOrderRepository()
      => new DecorationOrderRepository(_context);
}

