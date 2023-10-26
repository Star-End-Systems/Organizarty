using Organizarty.Application.App.Schedules.Data;
using Organizarty.Application.App.Schedules.Entities;
using Organizarty.Application.App.Schedules.Enum;
using Organizarty.Infra.Data.Contexts;

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
        await _context.DecorationOrders.AddAsync(decoration);
        await _context.SaveChangesAsync();
        return decoration;
    }

    public async Task<DecorationOrder> ChangeStatus(DecorationOrder decoration, ItemStatus newStatus)
    {
        decoration.Status = newStatus;
        _context.DecorationOrders.Update(decoration);
        await _context.SaveChangesAsync();
        return decoration;
    }

    public Task<DecorationOrder> Update(DecorationOrder decoration)
    {
        throw new NotImplementedException();
    }
}
