using Organizarty.Application.App.Schedules.Data;
using Organizarty.Application.App.Schedules.Entities;
using Organizarty.Application.Exceptions;

namespace Organizarty.Application.App.Schedules.UseCases;

public class SelectScheduleUseCase
{
    private readonly IScheduleRepository _scheduleRepository;

    private readonly IDecorationOrderRepository _decorationRepository;
    private readonly IFoodOrderRepository _foodRepository;
    private readonly IServiceOrderRepository _serviceRepository;

    public SelectScheduleUseCase(IScheduleRepository scheduleRepository, IDecorationOrderRepository decorationOrder, IFoodOrderRepository foodRepository, IServiceOrderRepository serviceRepository)
    {
        _scheduleRepository = scheduleRepository;
        _decorationRepository = decorationOrder;
        _foodRepository = foodRepository;
        _serviceRepository = serviceRepository;
    }

    public async Task<Schedule> FindById(Guid scheduleId)
    => await _scheduleRepository.FindById(scheduleId) ?? throw new NotFoundException("Schedule not found.");

    public async Task<List<Schedule>> FromUser(Guid userid)
    => await _scheduleRepository.ListFromUser(userid);

    public async Task<List<DecorationOrder>> SelectDecorationOrders(Guid scheduleId)
    => await _decorationRepository.ListFromSchedule(scheduleId);

    public async Task<List<FoodOrder>> SelectFoodOrders(Guid thirdPartyId)
    => await _foodRepository.ListFromThirdParty(thirdPartyId);

    public async Task<List<ItemOrder>> SelectOrdersFromSchedule(Guid scheduleid)
    {
        var decorations = (await _decorationRepository
                                .ListFromSchedule(scheduleid))
                                .Select(ItemOrder.FromItem);

        var foods = (await _foodRepository
                          .ListFromShedule(scheduleid))
                          .Select(ItemOrder.FromItem);


        var services = (await _serviceRepository
                              .ListFromShedule(scheduleid))
                              .Select(ItemOrder.FromItem);

        var itemOrder = new List<ItemOrder>();

        itemOrder.AddRange(decorations);
        itemOrder.AddRange(foods);
        itemOrder.AddRange(services);

        return itemOrder;
    }

    public async Task<List<ItemOrder>> OrdersSince(DateTime date, Guid userid)
    {
        var orders = new List<ItemOrder>();

        var schedules = await _scheduleRepository.Since(date, userid);

        foreach (var schedule in schedules)
        {
            orders.AddRange(await SelectOrdersFromSchedule(schedule.Id));
        }

        return orders;
    }

    public async Task<List<ItemOrder>> OrdersFromThirdParty(Guid thirdpartyid)
    {
        var foods = (await _foodRepository
                          .ListFromThirdParty(thirdpartyid))
                          .Select(ItemOrder.FromItem);


        var services = (await _serviceRepository
                              .ListFromThirdParty(thirdpartyid))
                              .Select(ItemOrder.FromItem);

        var itemOrder = new List<ItemOrder>();

        itemOrder.AddRange(foods);
        itemOrder.AddRange(services);

        return itemOrder;
    }

    public async Task<List<ItemOrder>> OrdersFromManager()
    {
        var decorations = (await _decorationRepository.AllOpen())
                              .Select(ItemOrder.FromItem);

        var itemOrder = new List<ItemOrder>();

        itemOrder.AddRange(decorations);

        return itemOrder;
    }
}
