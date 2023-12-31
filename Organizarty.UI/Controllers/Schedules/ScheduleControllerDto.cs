using Organizarty.Application.App.Schedules.Entities;

namespace Organizarty.UI.Controllers.Schedules;


public record OrderResponse(Guid id, string Name, DateTime Date, String Type, String Note, int Quantity, string Status)
{
    public static OrderResponse FromOrder(ItemOrder order)
    => new OrderResponse(order.id, order.name, DateTime.Now, order.type.ToString(), order.note, order.quantity, order.Status.ToString());
}

public record ScheduleResponse(Guid id, string Name, DateTime Date, string Type, decimal price, List<OrderResponse> orders)
{
    public static ScheduleResponse FromParty(Schedule party)
    => new ScheduleResponse(party.Id, party.Name, party.StartDate, party.Type.ToString(), party.Price, new());

    public static ScheduleResponse FromParty(Schedule party, List<OrderResponse> orders)
    => new ScheduleResponse(party.Id, party.Name, party.StartDate, party.Type.ToString(), party.Price, orders);
}

