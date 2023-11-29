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
                                .Select(x => new ItemOrder(x.Id, Party.Enums.ItemType.Decoration, x.Decoration.DecorationType.Name, x.Status, x.Quantity, x.Note, x.Price, scheduleid));

        var foods = (await _foodRepository
                          .ListFromShedule(scheduleid))
                          .Select(x => new ItemOrder(x.Id, Party.Enums.ItemType.Food, x.FoodInfo.FoodType.Name, x.Status, x.Quantity, x?.Note ?? "", x.Price, scheduleid));


        var services = (await _serviceRepository
                              .ListFromShedule(scheduleid))
                              .Select(x => new ItemOrder(x.Id, Party.Enums.ItemType.Service, x.ServiceInfo.ServiceType.Name, x.Status, 1, x.Note, x.Price, scheduleid));

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
                          .Select(x => new ItemOrder(x.Id, Party.Enums.ItemType.Food, $"{x.FoodInfo.FoodType.Name} - {x.FoodInfo.Flavour}", x.Status, x.Quantity, x?.Note ?? "", x.Price, x.ScheduleId));


        var services = (await _serviceRepository
                              .ListFromThirdParty(thirdpartyid))
                              .Select(x => new ItemOrder(x.Id, Party.Enums.ItemType.Service, $"{x.ServiceInfo.ServiceType.Name} - {x.ServiceInfo.Plan}", x.Status, 1, x.Note, x.Price, x.ScheduleId));

        var itemOrder = new List<ItemOrder>();

        itemOrder.AddRange(foods);
        itemOrder.AddRange(services);

        return itemOrder;
    }
}
