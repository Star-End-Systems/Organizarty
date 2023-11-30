using Organizarty.Application.App.Party.Entities;
using Organizarty.Application.App.Party.UseCases;
using Organizarty.Application.App.Schedules.Data;
using Organizarty.Application.App.Schedules.Entities;
using Organizarty.Application.App.Schedules.Enum;
using Organizarty.Application.Exceptions;

namespace Organizarty.Application.App.Schedules.UseCases;

public class OrderDecorationUseCase
{
    private readonly SelectPartyUseCase _selectParty;
    private readonly IDecorationOrderRepository _decorationRepository;
    private readonly SelectScheduleUseCase _selectSchedule;

    public OrderDecorationUseCase(SelectPartyUseCase selectParty, IDecorationOrderRepository decorationRepository, SelectScheduleUseCase selectSchedule)
    {
        _decorationRepository = decorationRepository;
        _selectParty = selectParty;
        _selectSchedule = selectSchedule;
    }

    public async Task<List<DecorationOrder>> Execute(Guid scheduleId)
      => await Execute(await _selectSchedule.FindById(scheduleId), ItemStatus.WAITING);

    public async Task<List<DecorationOrder>> Execute(Schedule schedule, ItemStatus status)
    {
        var dec = new List<DecorationOrder>();
        var decorations = await _selectParty.GetDecorations(schedule.PartyId);

        foreach (var decoration in decorations)
        {
            var order = MountOrder(schedule, decoration);
            order.Status = status;
            dec.Add(await _decorationRepository.Add(order));
        }

        return dec;
    }

    private DecorationOrder MountOrder(Schedule schedule, DecorationGroup decoration)
    {
        if (decoration.DecorationInfo is null)
        {
            throw new NotFoundException("Decoration not found");
        }

        decimal total = decoration.Quantity * decoration!.DecorationInfo.Price;

        return new DecorationOrder
        {
            Quantity = decoration.Quantity,
            Note = decoration.Note ?? "",
            DecorationId = decoration.DecorationInfoId,
            EventDate = schedule.StartDate,
            ScheduleId = schedule.Id,
            Status = ItemStatus.PENDING,
            Price = total
        };
    }
}
