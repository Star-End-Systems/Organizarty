using Organizarty.Application.App.Party.Entities;
using Organizarty.Application.App.Party.UseCases;
using Organizarty.Application.App.Schedules.Data;
using Organizarty.Application.App.Schedules.Entities;
using Organizarty.Application.App.Schedules.Enum;
using Organizarty.Application.Exceptions;

namespace Organizarty.Application.App.Schedules.UseCases;

public class OrderFoodUseCase
{
    private readonly SelectPartyUseCase _selectParty;
    private readonly IFoodOrderRepository _foodRepository;
    private readonly SelectScheduleUseCase _selectSchedule;

    public OrderFoodUseCase(SelectPartyUseCase selectParty, IFoodOrderRepository foodRepository, SelectScheduleUseCase selectSchedule)
    {
        _foodRepository = foodRepository;
        _selectParty = selectParty;
        _selectSchedule = selectSchedule;
    }

    public async Task Execute(Guid scheduleId)
    {
        var schedule = await _selectSchedule.FindById(scheduleId);

        var foods = await _selectParty.GetFoods(schedule.PartyId);

        foreach (var food in foods)
        {
            var order = MountOrder(schedule, food);
            await _foodRepository.Add(order);
        }
    }

    private FoodOrder MountOrder(Schedule schedule, FoodGroup food)
    {
        if (food.FoodInfo is null)
        {
            throw new NotFoundException("Decoration not found");
        }

        decimal total = food.Quantity * food!.FoodInfo.Price;

        return new FoodOrder
        {
            Quantity = food.Quantity,
            Note = food.Note ?? "",
            FoodInfoId = food.FoodInfoId,
            EventDate = schedule.StartDate,
            ScheduleId = schedule.Id,
            Status = ItemStatus.PENDING,
            Price = total
        };
    }
}
