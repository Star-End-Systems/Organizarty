using Microsoft.AspNetCore.Mvc;
using Organizarty.Application.Exceptions;

namespace Organizarty.UI.Controllers.Schedules;

public partial class ScheduleController
{
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
