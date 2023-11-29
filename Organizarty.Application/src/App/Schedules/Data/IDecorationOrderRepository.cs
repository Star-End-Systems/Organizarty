using Organizarty.Application.App.Schedules.Entities;

namespace Organizarty.Application.App.Schedules.Data;

public interface IDecorationOrderRepository
{
    Task<DecorationOrder> Add(DecorationOrder decoration);
    Task<DecorationOrder> Update(DecorationOrder decoration);

    Task<List<DecorationOrder>> ListFromSchedule(Guid schedule);
}
