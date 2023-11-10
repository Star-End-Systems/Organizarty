using Microsoft.AspNetCore.Mvc;
using Organizarty.Application.App.Schedules.UseCases;

namespace Organizarty.UI.Areas.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ScheduleController : ControllerBase
{
    private readonly ILogger<ScheduleController> _logger;
    private readonly SelectScheduleUseCase _selectSchedule;

    public ScheduleController(ILogger<ScheduleController> logger, SelectScheduleUseCase selectSchedule)
    {
        _logger = logger;
        _selectSchedule = selectSchedule;
    }

    [HttpGet("orders/{scheduleId:Guid}")]
    public async Task<IActionResult> GetAllOrders(Guid scheduleId)
    {
        var decorations = await _selectSchedule.SelectDecorationOrders(scheduleId);

        return Ok(new
        {
            decorations,
        });
    }
}
