using Organizarty.Application.App.Schedules.Data;
using Organizarty.Application.App.Schedules.Entities;
using Organizarty.Application.App.Schedules.Enum;
using Organizarty.Infra.Data.Contexts;

namespace Organizarty.Infra.Repositories.Schedules;

public class FoodOrderRepository : IFoodOrderRepository

{
    private readonly ApplicationDbContext _context;

    public FoodOrderRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<FoodOrder> Add(FoodOrder food)
    {
        await _context.FoodOrders.AddAsync(food);
        await _context.SaveChangesAsync();
        return food;
    }

    public async Task<FoodOrder> ChangeStatus(FoodOrder food, ItemStatus newStatus)
    {
        food.Status = newStatus;
        _context.FoodOrders.Update(food);
        await _context.SaveChangesAsync();
        return food;
    }

    public Task<FoodOrder> Update(FoodOrder food)
    {
        throw new NotImplementedException();
    }
}
