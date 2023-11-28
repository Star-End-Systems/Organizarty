using Organizarty.Application.App.Party.Entities;
using Organizarty.Application.App.Party.UseCases;
using Organizarty.Application.App.Schedules.Data;
using Organizarty.Application.App.Schedules.Entities;
using Organizarty.Application.App.Schedules.Enum;
using Organizarty.Application.Exceptions;

namespace Organizarty.Application.App.Schedules.UseCases;

public class OrderServiceUseCase
{
    private readonly SelectPartyUseCase _selectParty;
    private readonly IServiceOrderRepository _serviceRepository;
    private readonly SelectScheduleUseCase _selectSchedule;

    public OrderServiceUseCase(SelectPartyUseCase selectParty, IServiceOrderRepository serviceRepository, SelectScheduleUseCase selectSchedule)
    {
        _serviceRepository = serviceRepository;
        _selectParty = selectParty;
        _selectSchedule = selectSchedule;
    }

    public async Task Execute(Guid scheduleId)
      => await Execute(await _selectSchedule.FindById(scheduleId), ItemStatus.PENDING);

    public async Task Execute(Schedule schedule, ItemStatus status = ItemStatus.WAITING)
    {
        var services = await _selectParty.GetServices(schedule.PartyId);

        foreach (var service in services)
        {
            var order = MountOrder(schedule, service);
            order.Status = status;

            await _serviceRepository.Add(order);
        }
    }

    private ServiceOrder MountOrder(Schedule schedule, ServiceGroup service)
    {
        if (service.ServiceInfo is null)
        {
            throw new NotFoundException("Decoration not found");
        }

        return new ServiceOrder
        {
            Note = service.Note ?? "",
            ServiceInfoId = service.ServiceInfoId,
            ThirdPartyId = service.ServiceInfo.ServiceType.ThirdPartyId,
            EventDate = schedule.StartDate,
            ScheduleId = schedule.Id,
            Status = ItemStatus.WAITING,
            Price = service.ServiceInfo.Price
        };
    }
}
