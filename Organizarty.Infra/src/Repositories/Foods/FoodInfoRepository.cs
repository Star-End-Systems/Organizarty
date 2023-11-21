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
}
