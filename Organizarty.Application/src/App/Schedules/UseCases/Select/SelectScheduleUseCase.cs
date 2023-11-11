using Organizarty.Application.App.Schedules.Data;
using Organizarty.Application.App.Schedules.Entities;
using Organizarty.Application.Exceptions;

namespace Organizarty.Application.App.Schedules.UseCases;

public class SelectScheduleUseCase
{
    private readonly IScheduleRepository _scheduleRepository;
    private readonly IDecorationOrderRepository _decorationOrder;

    public SelectScheduleUseCase(IScheduleRepository scheduleRepository, IDecorationOrderRepository decorationOrder)
    {
        _scheduleRepository = scheduleRepository;
        _decorationOrder = decorationOrder;
    }

    public async Task<Schedule> FindById(Guid scheduleId)
    => await _scheduleRepository.FindById(scheduleId) ?? throw new NotFoundException("Schedule not found.");

    public async Task<List<DecorationOrder>> SelectDecorationOrders(Guid scheduleId)
    => await _decorationOrder.ListFromShedule(scheduleId);
}
