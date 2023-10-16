using Organizarty.Application.App.Schedules.Entities;

namespace Organizarty.Application.App.Schedules.Data;

public interface IFoodOrderRepository
{
    Task<FoodOrder> Add(FoodOrder food);
}
