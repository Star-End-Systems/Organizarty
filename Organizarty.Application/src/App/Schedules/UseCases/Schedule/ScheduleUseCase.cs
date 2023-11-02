using Organizarty.Application.App.Party.Data;
using Organizarty.Application.App.Party.Entities;
using Organizarty.Application.App.Schedules.Data;
using Organizarty.Application.App.Schedules.Entities;
using Organizarty.Application.Exceptions;

namespace Organizarty.Application.App.Schedules.UseCases;

public class ScheduleUseCase
{
    private readonly IScheduleRepository _scheduleRepository;
    private readonly IPartyTemplateRepository _partyRepository;
    private readonly OrderDecorationUseCase _orderDecoration;
    private readonly ChangeItemStatusUseCase _changeStatus;

    public ScheduleUseCase(IScheduleRepository scheduleRepository, IPartyTemplateRepository partyRepository, OrderDecorationUseCase orderDecoration, ChangeItemStatusUseCase changeStatus)
    {
        _scheduleRepository = scheduleRepository;
        _partyRepository = partyRepository;
        _orderDecoration = orderDecoration;
        _changeStatus = changeStatus;
    }

    public async Task<Schedule> Execute(ScheduleDto scheduleDto)
    {
        var party = await _partyRepository.FromId(scheduleDto.partyId) ?? throw new NotFoundException("user from schedule not found");

        var schedule = MountSchedule(party, scheduleDto);

        var s = await _scheduleRepository.Create(schedule);

        await _orderDecoration.Execute(s);

        return s;
    }

    private Schedule MountSchedule(PartyTemplate party, ScheduleDto scheduleDto)
    {
        return new Schedule
        {
            Name = party.Name,
            ExpectedGuests = party.ExpectedGuests,
            Price = 0,
            LocationId = party.LocationId,
            UserId = party.UserId,
            PartyId = party.Id,
            StartDate = scheduleDto.startDate,
            EndDate = scheduleDto.endDate
        };
    }
}
