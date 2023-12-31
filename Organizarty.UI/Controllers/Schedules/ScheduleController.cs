using Microsoft.AspNetCore.Mvc;
using Organizarty.Application.App.Schedules.UseCases;
using Organizarty.UI.Helpers;

namespace Organizarty.UI.Controllers.Schedules;

public record ManyItems<T>(IEnumerable<T> data);

[ApiController]
[Route("api/[controller]")]
public partial class ScheduleController : ControllerBase
{
    private readonly ILogger<ScheduleController> _logger;
    private readonly SelectScheduleUseCase _selectSchedule;
    private readonly AuthenticationHelper _authHelper;

    public ScheduleController(ILogger<ScheduleController> logger, SelectScheduleUseCase selectSchedule, AuthenticationHelper authHelper)
    {
        _logger = logger;
        _selectSchedule = selectSchedule;
        _authHelper = authHelper;
    }
}
