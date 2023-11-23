using Microsoft.EntityFrameworkCore;
using Organizarty.Application.App.DecorationInfos.Data;
using Organizarty.Application.App.DecorationInfos.Entities;
using Organizarty.Infra.Data.Contexts;

namespace Organizarty.Infra.Repositories.Decorations;

public class DecorationInfoRepository : IDecorationInfoRepository
{
    private readonly ApplicationDbContext _context;

    public DecorationInfoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<DecorationInfo> Create(DecorationInfo decoration)
    {
        var d = await _context.DecorationInfos.AddAsync(decoration);
        await _context.SaveChangesAsync();

        return d.Entity;
    }

    public async Task<DecorationInfo?> FindById(Guid id)
    => await _context.DecorationInfos.FindAsync(id);

    public async Task<DecorationInfo?> FindByIdWithType(Guid id)
    => await _context.DecorationInfos
              .Where(x => x.Id == id)
              .Include(x => x.DecorationType)
              .Select(x => new DecorationInfo
              {
                  Id = x.Id,
                  Color = x.Color,
                  Material = x.Material,
                  IsAvaible = x.IsAvaible,
                  Price = x.Price,
                  DecorationType = x.DecorationType
              })
              .FirstOrDefaultAsync();

    public async Task<DecorationInfo> Update(DecorationInfo decoration)
    {
        var d = _context.DecorationInfos.Update(decoration);
        await _context.SaveChangesAsync();

        return d.Entity;
    }
}
