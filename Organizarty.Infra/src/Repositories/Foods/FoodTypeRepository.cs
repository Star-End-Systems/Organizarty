using Organizarty.Application.App.FoodTypes.Data;
using Organizarty.Application.App.FoodTypes.Entities;
using Organizarty.Infra.Data.Contexts;

namespace Organizarty.Infra.Repositories.Foods;

public class FoodTypeRepository : IFoodTypeRepository
{
    private readonly ApplicationDbContext _context;

    public FoodTypeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<FoodType> Create(FoodType foodType)
    {
        await _context.FoodTypes.AddAsync(foodType);
        await _context.SaveChangesAsync();
        return foodType;
    }
}
