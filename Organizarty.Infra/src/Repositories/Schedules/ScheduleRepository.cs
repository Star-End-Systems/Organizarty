using Microsoft.EntityFrameworkCore;
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

    public async Task<List<Schedule>> ListFromUser(Guid userid)
      => await _context.Schedules
                .Where(x => x.UserId == userid)
                .ToListAsync();

    public async Task<List<Schedule>> Since(DateTime date, Guid userid)
    => await _context.Schedules
                      .Where(x => x.CreatedAt.Date > date.Date && x.UserId == userid)
                      .ToListAsync();

    public async Task<Schedule> Update(Schedule schedule)
    {
        var s = _context.Schedules.Update(schedule);
        await _context.SaveChangesAsync();

        return s.Entity;
    }
}
