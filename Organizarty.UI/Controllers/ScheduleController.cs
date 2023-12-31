using Microsoft.AspNetCore.Mvc;
using Organizarty.Application.App.Schedules.Entities;
using Organizarty.Application.App.Schedules.UseCases;
using Organizarty.Application.Exceptions;
using Organizarty.UI.Helpers;

namespace Organizarty.UI.Controllers;

public record ManyItems<T>(IEnumerable<T> data);

[ApiController]
[Route("api/[controller]")]
public class ScheduleController : ControllerBase
{
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

    private readonly ILogger<ScheduleController> _logger;
    private readonly SelectScheduleUseCase _selectSchedule;
    private readonly AuthenticationHelper _authHelper;

    public ScheduleController(ILogger<ScheduleController> logger, SelectScheduleUseCase selectSchedule, AuthenticationHelper authHelper)
    {
        _logger = logger;
        _selectSchedule = selectSchedule;
        _authHelper = authHelper;
    }

    [HttpGet("Orders")]
    public async Task<ActionResult<ManyItems<OrderResponse>>> GetOrders()
    {
        var user = await _authHelper.GetUserFromToken() ?? throw new NotFoundException("User not found. Place use a valid token.");
        var orders = await _selectSchedule.OrdersSince(DateTime.Now.AddMonths(-3), user.Id);

        return Ok(new ManyItems<OrderResponse>(orders.Select(OrderResponse.FromOrder)));
    }

    [HttpGet("Parties")]
    public async Task<ActionResult<ManyItems<ScheduleResponse>>> GetParties()
    {
        var user = await _authHelper.GetUserFromToken() ?? throw new NotFoundException("User not found. Place use a valid token.");

        var parties = await _selectSchedule.FromUser(user.Id);

        return Ok(new ManyItems<ScheduleResponse>(parties.Select(ScheduleResponse.FromParty)));
    }

    [HttpGet("Party/{scheduleid:Guid}")]
    public async Task<ActionResult<ScheduleResponse>> GetParty(Guid scheduleid)
    {
        var _ignored = await _authHelper.GetUserFromToken() ?? throw new NotFoundException("User not found. Place use a valid token.");

        var party = await _selectSchedule.FindById(scheduleid) ?? throw new NotFoundException("Festa não encontrada.");

        return Ok(ScheduleResponse.FromParty(party));
    }
}
