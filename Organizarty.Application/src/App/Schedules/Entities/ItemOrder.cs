using Organizarty.Application.App.Party.Enums;
using Organizarty.Application.App.Schedules.Enum;

namespace Organizarty.Application.App.Schedules.Entities;

public record ItemOrder(Guid id, ItemType type, string name, ItemStatus Status, int quantity, string note, decimal price, Guid scheduleId)
{
  public static ItemOrder FromItem(FoodOrder order)
    => new ItemOrder(order.Id, Party.Enums.ItemType.Food, $"{order.FoodInfo.FoodType.Name} - {order.FoodInfo.Flavour}", order.Status, order.Quantity, order?.Note ?? "", order.Price, order.ScheduleId);

  public static ItemOrder FromItem(ServiceOrder order)
    => new ItemOrder(order.Id, Party.Enums.ItemType.Service, $"{order.ServiceInfo.ServiceType.Name} - {order.ServiceInfo.Plan}", order.Status, 1, order.Note, order.Price, order.ScheduleId);

  public static ItemOrder FromItem(DecorationOrder order)
    => new ItemOrder(order.Id, Party.Enums.ItemType.Decoration, $"{order.Decoration.DecorationType.Name} - {order.Decoration.Color}", order.Status, 1, order.Note, order.Price, order.ScheduleId);
}
