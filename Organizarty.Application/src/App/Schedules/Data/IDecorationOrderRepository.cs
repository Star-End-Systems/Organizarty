using Organizarty.Application.App.Schedules.Entities;
using Organizarty.Application.App.Schedules.Enum;

namespace Organizarty.Application.App.Schedules.Data;

public interface IDecorationOrderRepository
{
    Task<DecorationOrder> Add(DecorationOrder decoration);
    Task<DecorationOrder> Update(DecorationOrder decoration);
}
