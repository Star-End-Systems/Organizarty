using Microsoft.EntityFrameworkCore;
using Organizarty.Application.App.DecorationTypes.Data;
using Organizarty.Application.App.DecorationTypes.Entities;
using Organizarty.Application.App.Decorations.Entities;
using Organizarty.Infra.Data.Contexts;
using Organizarty.Infra.Utils;

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
                  Category = x.Category,
                  Decorations = x.Decorations
              })
              .ToListAsync();
    public async Task<List<DecorationType>> FindByCategory(DecorationCategory Category)
    => await _context.DecorationTypes
              .Include(x => x.Decorations)
              .Where(x => x.Category == Category)
              .Select(x => new DecorationType
              {
                  Id = x.Id,
                  Name = x.Name,
                  Description = x.Description,
                  Size = x.Size,
                  Model = x.Model,
                  ObjectURL = x.ObjectURL,
                  TagsJSON = x.TagsJSON,
                  Category = x.Category,
                  Decorations = x.Decorations
              })
              .ToListAsync();

    public async Task<DecorationType> Create(DecorationType decoration)
    {
        decoration.Id = IdGenerator.DefaultId();
        var d = await _context.DecorationTypes.AddAsync(decoration);
        await _context.SaveChangesAsync();

        return d.Entity;
    }

    public async Task<DecorationType?> FindById(string id)
    => await _context.DecorationTypes.FindAsync(id);

    public async Task<DecorationType?> FindByIdWithItems(string id)
    => await _context.DecorationTypes
            .Include(x => x.Decorations)
            .Where(x => x.Id == id)
            .Select(x => new DecorationType
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Decorations = x.Decorations,
                TagsJSON = x.TagsJSON
            })
            .FirstOrDefaultAsync();

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
