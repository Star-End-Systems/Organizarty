using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Adapters;
using Organizarty.Application.App.Party.Entities;
using Organizarty.Application.App.Party.UseCases;
using Organizarty.Application.App.Schedules.Entities;
using Organizarty.Application.App.Schedules.UseCases;
using Organizarty.UI.Attributes;
using Organizarty.UI.Helpers;
using System.ComponentModel.DataAnnotations;
namespace Organizarty.UI.Pages;

[Authorized("/Clients/Accounts/Login", UserType.Client)]
public class MyPartiesModel : PageModel
{
    private readonly ILogger<MyPartiesModel> _logger;
    private readonly SelectPartyUseCase _selectParty;
    private readonly SelectScheduleUseCase _selectSchedule;
    private readonly AuthenticationHelper _authHelper;

    public MyPartiesModel(ILogger<MyPartiesModel> logger, SelectPartyUseCase selectParty, AuthenticationHelper authHelper, SelectScheduleUseCase selectSchedule)
    {
        _logger = logger;
        _selectParty = selectParty;
        _selectSchedule = selectSchedule;
        _authHelper = authHelper;
    }

    [BindProperty]
    public InputModel Input { get; set; } = default!;

    public class InputModel
    {
        [Display(Name = "Search")]
        public string Search { get; set; } = default!;
    }

    public List<Schedule> Schedules = new();
    public List<PartyTemplate> PartyTemplates = new();

    public async Task OnGetAsync()
    {
        var user = (await _authHelper.GetUserFromToken(_authHelper.GetToken() ?? ""))!;

        Schedules = await _selectSchedule.FromUser(user.Id);
        PartyTemplates = await _selectParty.FromUser(user.Id);
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        return RedirectToPage("", new { search = Input.Search });
    }
}
