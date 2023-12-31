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

    public async Task<FoodOrder?> FindById(string id)
      => await _context.FoodOrders.FindAsync(id);

    public async Task<List<FoodOrder>> ListFromShedule(string scheduleid)
      => await _context.FoodOrders
                        .Where(x => x.ScheduleId == scheduleid)
                        .Where(x => x.Status != ItemStatus.WAITING)
                        .Include(x => x.FoodInfo)
                        .Include(x => x.FoodInfo!.FoodType)
                        .ToListAsync();

    public async Task<List<FoodOrder>> ListFromThirdParty(string thirdPartyId)
    => await _context.FoodOrders
              .Where(x => x.ThirdPartyId == thirdPartyId)
              .Where(x => x.Status == ItemStatus.PENDING)
              .Include(x => x.FoodInfo)
              .Include(x => x.FoodInfo!.FoodType)
              .Select(x => new FoodOrder
              {
                  Id = x.Id,
                  Quantity = x.Quantity,
                  Note = x.Note,
                  Status = x.Status,
                  FoodInfo = new()
                  {
                      FoodType = new()
                      {
                          Name = x.FoodInfo!.FoodType.Name,
                          ThirdParty = x.ThirdParty!
                      },
                      Price = x.Price,
                      Flavour = x.FoodInfo.Flavour,
                      Id = x.Id
                  },
                  Schedule = x.Schedule
              })
    .ToListAsync();

    public async Task<FoodOrder> Update(FoodOrder food)
    {
        _context.FoodOrders.Update(food);
        await _context.SaveChangesAsync();
        return food;
    }
}
