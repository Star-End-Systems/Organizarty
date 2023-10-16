using Organizarty.Application.App.Schedules.Data;
using Organizarty.Application.App.Schedules.Entities;
using Organizarty.Infra.Data.Contexts;

namespace Organizarty.Infra.Repositories.Schedules;

public class ScheduleRepository : IScheduleRepository
{
    private readonly ApplicationDbContext _context;

    public ScheduleRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Schedule> Create(Schedule schedule)
    {
        var s = await _context.Schedules.AddAsync(schedule);
        await _context.SaveChangesAsync();

        return s.Entity;
    }

    public async Task<Schedule?> FindById(Guid scheduleId)
    => await _context.Schedules.FindAsync(scheduleId);
}
