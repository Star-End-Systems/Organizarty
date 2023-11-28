using Microsoft.EntityFrameworkCore;
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

    public async Task<FoodOrder?> FindById(Guid id)
      => await _context.FoodOrders.FindAsync(id);


    public async Task<List<FoodOrder>> ListFromThirdParty(Guid thirdPartyId)
    => await _context.FoodOrders
              .Where(x => x.ThirdPartyId == thirdPartyId)
              .Select(x => new FoodOrder
              {
                  Id = x.Id,
                  Quantity = x.Quantity,
                  Note = x.Note,
                  Status = x.Status,
                  FoodInfo = x.FoodInfo,
                  Schedule = x.Schedule
              })
    .ToListAsync();

    public Task<FoodOrder> Update(FoodOrder food)
    {
        throw new NotImplementedException();
    }
}
