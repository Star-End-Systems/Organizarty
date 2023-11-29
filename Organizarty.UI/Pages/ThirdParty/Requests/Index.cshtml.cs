using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Adapters;
using Organizarty.Application.App.Schedules.Entities;
using Organizarty.Application.App.Schedules.UseCases;
using Organizarty.UI.Attributes;
using Organizarty.UI.Helpers;

namespace Organizarty.UI.Pages;

[Authorized("/ThirdParty/Accounts/Login", UserType.ThirdParty)]
public class RequestsThirdPartyModel : PageModel
{
    private readonly ILogger<RequestsThirdPartyModel> _logger;
    private readonly SelectScheduleUseCase _selectSchedule;
    private readonly AuthenticationHelper _authHelper;

    public RequestsThirdPartyModel(ILogger<RequestsThirdPartyModel> logger, SelectScheduleUseCase selectSchedule, AuthenticationHelper authHelper)
    {
        _logger = logger;
        _selectSchedule = selectSchedule;
        _authHelper = authHelper;
    }

    public List<ItemOrder> Orders { get; set; } = new();

    public async Task OnGetAsync()
    {
        var thirdParty = (await _authHelper.GetThirdPartyFromToken(_authHelper.GetToken() ?? ""))!;

        Orders = await _selectSchedule.OrdersFromThirdParty(thirdParty.Id);
    }
}
