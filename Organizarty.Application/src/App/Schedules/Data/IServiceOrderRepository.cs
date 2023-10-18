using Organizarty.Application.App.Schedules.Entities;

namespace Organizarty.Application.App.Schedules.Data;

public interface IServiceOrderRepository
{
    Task<ServiceOrder> Add(ServiceOrder service);
    Task<ServiceOrder> Update(ServiceOrder service);
}
