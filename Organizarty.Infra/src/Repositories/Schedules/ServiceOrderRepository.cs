using Organizarty.Application.App.Schedules.Data;
using Organizarty.Application.App.Schedules.Entities;
using Organizarty.Application.App.Schedules.Enum;
using Organizarty.Infra.Data.Contexts;

namespace Organizarty.Infra.Repositories.Schedules;

public class ServiceOrderRepository : IServiceOrderRepository
{
    private readonly ApplicationDbContext _context;

    public ServiceOrderRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ServiceOrder> Add(ServiceOrder service)
    {
        await _context.ServiceOrders.AddAsync(service);
        await _context.SaveChangesAsync();
        return service;
    }

    public async Task<ServiceOrder> ChangeStatus(ServiceOrder food, ItemStatus newStatus)
    {
        food.Status = newStatus;
        _context.ServiceOrders.Update(food);
        await _context.SaveChangesAsync();
        return food;
    }

    public Task<ServiceOrder> Update(ServiceOrder service)
    {
        throw new NotImplementedException();
    }
}
