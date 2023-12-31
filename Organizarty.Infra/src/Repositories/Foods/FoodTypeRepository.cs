using Microsoft.EntityFrameworkCore;

using Organizarty.Application.App.Foods.Data;
using Organizarty.Application.App.Foods.Entities;
using Organizarty.Infra.Data.Contexts;
using Organizarty.Infra.Utils;

namespace Organizarty.Infra.Repositories.Foods;

public class FoodTypeRepository : IFoodTypeRepository
{
    private readonly ApplicationDbContext _context;

    public FoodTypeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<FoodType>> AllFoods()
    => await _context.FoodTypes
              .Include(x => x.Foods)
              .Select(x => new FoodType
              {
                  Id = x.Id,
                  Name = x.Name,
                  Description = x.Description,
                  ThirdParty = x.ThirdParty,
                  Foods = x.Foods,
                  TagsJSON = x.TagsJSON
              })
              .ToListAsync();


    public async Task<List<FoodType>> AllFoods(bool avaible)
    => await _context.FoodTypes
              .Include(x => x.Foods.Where(y => y.Available == avaible))
              .Select(x => new FoodType
              {
                  Id = x.Id,
                  Name = x.Name,
                  Description = x.Description,
                  ThirdParty = x.ThirdParty,
                  Foods = x.Foods,
                  TagsJSON = x.TagsJSON
              })
              .ToListAsync();

    public async Task<List<FoodType>> AllFoodsFromThirdParty(string thirdPartyId)
      => await _context.FoodTypes
                .Include(x => x.Foods)
                .Where(x => x.ThirdPartyId == thirdPartyId)
                .Select(x => new FoodType
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    ThirdParty = x.ThirdParty,
                    Foods = x.Foods,
                    TagsJSON = x.TagsJSON
                })
                .ToListAsync();

    public async Task<FoodType> Create(FoodType foodType)
    {
        foodType.Id = IdGenerator.DefaultId();
        await _context.FoodTypes.AddAsync(foodType);
        await _context.SaveChangesAsync();
        return foodType;
    }

    public async Task<FoodType?> FindById(string id)
      => await _context.FoodTypes.FindAsync(id);

    public async Task<FoodType> Update(FoodType foodType)
    {
        var f = _context.FoodTypes.Update(foodType);
        await _context.SaveChangesAsync();

        return f.Entity;
    }
}
