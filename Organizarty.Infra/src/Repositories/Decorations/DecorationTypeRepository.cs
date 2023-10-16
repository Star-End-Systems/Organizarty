using Organizarty.Application.App.DecorationTypes.Data;
using Organizarty.Application.App.DecorationTypes.Entities;
using Organizarty.Infra.Data.Contexts;

namespace Organizarty.Infra.Repositories.Decorations;

public class DecorationTypeRepository : IDecorationTypeRepository
{
    private readonly ApplicationDbContext _context;

    public DecorationTypeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<DecorationType> Create(DecorationType decoration)
    {
        var d = await _context.DecorationTypes.AddAsync(decoration);
        await _context.SaveChangesAsync();

        return d.Entity;
    }
}
