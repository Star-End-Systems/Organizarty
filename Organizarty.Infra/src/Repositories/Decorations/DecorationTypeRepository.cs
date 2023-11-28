using Microsoft.EntityFrameworkCore;
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

    public async Task<List<DecorationType>> All()
    => await _context.DecorationTypes
              .Include(x => x.Decorations)
              .Select(x => new DecorationType
              {
                  Id = x.Id,
                  Name = x.Name,
                  Description = x.Description,
                  Size = x.Size,
                  Model = x.Model,
                  ObjectURL = x.ObjectURL,
                  TagsJSON = x.TagsJSON,
                  Decorations = x.Decorations
              })
              .ToListAsync();

    public async Task<DecorationType> Create(DecorationType decoration)
    {
        var d = await _context.DecorationTypes.AddAsync(decoration);
        await _context.SaveChangesAsync();

        return d.Entity;
    }

    public async Task<DecorationType?> FindById(Guid id)
    => await _context.DecorationTypes.FindAsync(id);

    public async Task<List<DecorationType>> GetWithAvaible(bool avaible)
      => await _context.DecorationTypes
                .Include(x => x.Decorations)
                .Select(x => new DecorationType
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Decorations = x.Decorations.Where(y => y.IsAvaible).ToList(),
                    TagsJSON = x.TagsJSON
                })
                .ToListAsync();

    public async Task<DecorationType> Update(DecorationType decoration)
    {
        var d = _context.DecorationTypes.Update(decoration);
        await _context.SaveChangesAsync();

        return d.Entity;
    }
}
