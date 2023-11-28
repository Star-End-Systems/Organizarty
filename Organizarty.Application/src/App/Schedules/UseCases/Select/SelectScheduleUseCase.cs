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
    => await _decorationRepository.ListFromShedule(scheduleId);

    public async Task<List<FoodOrder>> SelectFoodOrders(Guid thirdPartyId)
    => await _foodRepository.ListFromThirdParty(thirdPartyId);
}
