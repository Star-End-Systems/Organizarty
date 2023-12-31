using Organizarty.Application.App.Schedules.Entities;

namespace Organizarty.Application.App.Schedules.Data;

public interface IScheduleRepository
{
    Task<Schedule> Create(Schedule schedule);
    Task<Schedule> Update(Schedule schedule);
    Task<Schedule?> FindById(string scheduleId);

    Task<List<Schedule>> ListFromUser(string userid);
    Task<List<Schedule>> Since(DateTime date, string userid);
}
