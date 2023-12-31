using Organizarty.Application.App.Schedules.Entities;

namespace Organizarty.Application.App.Schedules.Data;

public interface IDecorationOrderRepository
{
    Task<DecorationOrder> Add(DecorationOrder decoration);
    Task<DecorationOrder> Update(DecorationOrder decoration);

    Task<DecorationOrder?> FindById(string id);

    Task<List<DecorationOrder>> ListFromSchedule(string schedule);
    Task<List<DecorationOrder>> All();
    Task<List<DecorationOrder>> AllOpen();
}
