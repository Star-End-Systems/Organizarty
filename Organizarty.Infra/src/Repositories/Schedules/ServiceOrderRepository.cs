using Microsoft.EntityFrameworkCore;
using Organizarty.Application.App.Schedules.Data;
using Organizarty.Application.App.Schedules.Entities;
using Organizarty.Application.App.Schedules.Enum;
using Organizarty.Infra.Data.Contexts;

namespace Organizarty.Infra.Repositories.Schedules;

public class ServiceOrderRepository : IServiceOrderRepository
{
    private readonly ApplicationDbContext _context;

    public ServiceOrderRepository(ApplicationDbContext context)
      => _context = context;

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

    public async Task<ServiceOrder?> FindById(Guid id)
    => await _context.ServiceOrders.FindAsync(id);

    public async Task<List<ServiceOrder>> ListFromShedule(Guid scheduleid)
      => await _context.ServiceOrders
                        .Where(x => x.ScheduleId == scheduleid && x.Status != ItemStatus.WAITING)
                        .Include(x => x.ServiceInfo)
                        .Include(x => x.ServiceInfo!.ServiceType)
                        .ToListAsync();

    public async Task<List<ServiceOrder>> ListFromThirdParty(Guid thirdPartyId)
    => await _context.ServiceOrders
              .Where(x => x.ThirdPartyId == thirdPartyId)
              .Where(x => x.Status == ItemStatus.PENDING)
              .Include(x => x.ServiceInfo)
              .Include(x => x.ServiceInfo!.ServiceType)
              .Select(x => new ServiceOrder
              {
                  Id = x.Id,
                  Note = x.Note,
                  Status = x.Status,
                  ServiceInfo = new()
                  {
                      ServiceType = new()
                      {
                          Name = x.ServiceInfo!.ServiceType.Name,
                          ThirdParty = x.ThirdParty!
                      },
                      Price = x.Price,
                      Plan = x.ServiceInfo.Plan
                  },
                  Schedule = x.Schedule
              })
    .ToListAsync();

    public async Task<ServiceOrder> Update(ServiceOrder service)
    {
        _context.ServiceOrders.Update(service);
        await _context.SaveChangesAsync();
        return service;
    }
}
