using Microsoft.EntityFrameworkCore;
using Organizarty.Application.App.Foods.Data;
using Organizarty.Application.App.Foods.Entities;
using Organizarty.Infra.Data.Contexts;

namespace Organizarty.Infra.Repositories.Foods;

public class FoodInfoRepository : IFoodInfoRepository
{
    private readonly ApplicationDbContext _context;

    public FoodInfoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<FoodInfo> Create(FoodInfo foodType)
    {
        await _context.FoodInfos.AddAsync(foodType);
        await _context.SaveChangesAsync();
        return foodType;
    }

    public async Task<FoodInfo?> FindById(string id)
      => await _context.FoodInfos.FindAsync(id);


    public async Task<FoodInfo?> FindWithIdWithDetail(string id)
    => await _context.FoodInfos
              .Where(x => x.Id == id)
              .Include(x => x.FoodType)
              .Select(x => new FoodInfo
              {
                  Id = x.Id,
                  Flavour = x.Flavour,
                  Price = x.Price,
                  Available = x.Available,
                  Images = x.Images,
                  FoodType = x.FoodType
              })
              .FirstOrDefaultAsync();

    public async Task<FoodInfo> Update(FoodInfo food)
    {
        _context.FoodInfos.Update(food);
        await _context.SaveChangesAsync();

        return food;
    }
}
