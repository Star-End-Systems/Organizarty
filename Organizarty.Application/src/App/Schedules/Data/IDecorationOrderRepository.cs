using Organizarty.Application.App.Schedules.Entities;

namespace Organizarty.Application.App.Schedules.Data;

public interface IDecorationOrderRepository
{
    Task<DecorationOrder> Add(DecorationOrder decoration);
}
