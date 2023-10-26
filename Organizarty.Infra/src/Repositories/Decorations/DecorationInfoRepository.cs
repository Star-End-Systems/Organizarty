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
}
