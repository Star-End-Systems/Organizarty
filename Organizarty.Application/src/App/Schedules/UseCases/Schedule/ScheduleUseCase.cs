using FluentValidation;
using Organizarty.Application.App.Party.Data;
using Organizarty.Application.App.Party.Entities;
using Organizarty.Application.App.Schedules.Data;
using Organizarty.Application.App.Schedules.Entities;
using Organizarty.Application.Exceptions;
using Organizarty.Application.Extras;

namespace Organizarty.Application.App.Schedules.UseCases;

public class ScheduleUseCase
{
    private readonly IScheduleRepository _scheduleRepository;
    private readonly IPartyTemplateRepository _partyRepository;
    private readonly ChangeItemStatusUseCase _changeStatus;
    private readonly IValidator<Schedule> _scheduleValidator;

    private readonly OrderDecorationUseCase _orderDecoration;
    private readonly OrderFoodUseCase _orderfood;
    private readonly OrderServiceUseCase _orderService;

    private readonly int MAX_EVENT_DURATION = 8;

    public ScheduleUseCase(IScheduleRepository scheduleRepository, IPartyTemplateRepository partyRepository, OrderDecorationUseCase orderDecoration, ChangeItemStatusUseCase changeStatus, IValidator<Schedule> scheduleValidator, OrderFoodUseCase orderFood, OrderServiceUseCase orderService)
    {
        _scheduleRepository = scheduleRepository;
        _partyRepository = partyRepository;
        _changeStatus = changeStatus;
        _scheduleValidator = scheduleValidator;

        _orderDecoration = orderDecoration;
        _orderfood = orderFood;
        _orderService = orderService;
    }

    public async Task<Schedule> Execute(ScheduleDto scheduleDto)
    {
        ValidEventTIme(scheduleDto);

        var party = await _partyRepository.FindById(scheduleDto.partyId) ?? throw new NotFoundException("user from schedule not found.");

        var schedule = MountSchedule(party, scheduleDto);

        Console.WriteLine(schedule.StartDate);
        Console.WriteLine(schedule.EndDate);

        ValidationUtils.Validate(_scheduleValidator, schedule, "Fail while validating schedule.");

        var s = await _scheduleRepository.Create(schedule);

        await _orderDecoration.Execute(s, Enum.ItemStatus.PENDING);
        // await _orderfood.Execute(s);
        await _orderService.Execute(s);

        return s;
    }

    private void ValidEventTIme(ScheduleDto schedule)
    {
        if (schedule.duration > MAX_EVENT_DURATION)
        {
            throw new ValidationFailException($"The max duration of an event is {MAX_EVENT_DURATION} hours.");
        }
    }

    private Schedule MountSchedule(PartyTemplate party, ScheduleDto scheduleDto)
        => new Schedule
        {
            Name = party.Name,
            ExpectedGuests = party.ExpectedGuests,
            Price = 0,
            LocationId = party.LocationId,
            UserId = party.UserId,
            PartyId = party.Id,
            StartDate = scheduleDto.startDate,
            EndDate = scheduleDto.startDate.AddHours(scheduleDto.duration)
        };

}
