using Microsoft.EntityFrameworkCore;
using Organizarty.Application.App.Schedules.Data;
using Organizarty.Application.App.Schedules.Entities;
using Organizarty.Application.App.Schedules.Enum;
using Organizarty.Infra.Data.Contexts;
using Organizarty.Infra.Utils;

namespace Organizarty.Infra.Repositories.Schedules;

public class DecorationOrderRepository : IDecorationOrderRepository
{
    private readonly ApplicationDbContext _context;

    public DecorationOrderRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<DecorationOrder> Add(DecorationOrder decoration)
    {
        decoration.Id = IdGenerator.DefaultId();
        await _context.DecorationOrders.AddAsync(decoration);
        await _context.SaveChangesAsync();
        return decoration;
    }

    public async Task<List<DecorationOrder>> All()
    => await _context.DecorationOrders.ToListAsync();

    public async Task<List<DecorationOrder>> AllOpen()
    => await _context.DecorationOrders
                     .Where(x => x.Status == ItemStatus.PENDING)
                     .Include(x => x.Decoration)
                     .Include(x => x.Decoration!.DecorationType)
                     .Select(x => new DecorationOrder
                     {
                         Id = x.Id,
                         Quantity = x.Quantity,
                         Note = x.Note,
                         Status = x.Status,
                         Decoration = new()
                         {
                             Id = x.Id,
                             DecorationType = new()
                             {
                                 Name = x.Decoration!.DecorationType.Name,
                             },
                             Price = x.Price,
                             Color = x.Decoration.Color,
                         },
                         Schedule = x.Schedule
                     })
                     .ToListAsync();


    public async Task<DecorationOrder> ChangeStatus(DecorationOrder decoration, ItemStatus newStatus)
    {
        decoration.Status = newStatus;
        return await Update(decoration);
    }

    public async Task<DecorationOrder?> FindById(string id)
      => await _context.DecorationOrders.FindAsync(id);


    public async Task<List<DecorationOrder>> ListFromSchedule(string schedule)
      => await _context.DecorationOrders
                        .Include(x => x.Decoration)
                        .Include(x => x.Decoration!.DecorationType)
                        .Where(x => x.ScheduleId == schedule)
                        .ToListAsync();

    public async Task<DecorationOrder> Update(DecorationOrder decoration)
    {
        _context.DecorationOrders.Update(decoration);
        await _context.SaveChangesAsync();
        return decoration;
    }
}
