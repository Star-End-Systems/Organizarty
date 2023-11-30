using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Adapters;
using Organizarty.Application.App.Schedules.Entities;
using Organizarty.Application.App.Schedules.UseCases;
using Organizarty.UI.Attributes;
using Organizarty.UI.Helpers;
using System.ComponentModel.DataAnnotations;
namespace Organizarty.UI.Pages;

[Authorized("/Clients/Accounts/Login", UserType.Client)]
public class RequestsModel : PageModel
{
    private readonly ILogger<RequestsModel> _logger;
    private readonly SelectScheduleUseCase _selectSchedule;
    private readonly AuthenticationHelper _authHelper;

    public RequestsModel(ILogger<RequestsModel> logger, SelectScheduleUseCase selectSchedule, AuthenticationHelper authHelper)
    {
        _logger = logger;

        _selectSchedule = selectSchedule;
        _authHelper = authHelper;
    }

    [BindProperty]
    public InputModel Input { get; set; } = default!;

    public class InputModel
    {
        [Required]
        [Display(Name = "Search")]
        public string Search { get; set; } = default!;
    }

    public Schedule Schedule { get; set; } = new();

    public List<ItemOrder> Items { get; set; } = new();

    public async Task<IActionResult> OnGetAsync()
    {
        var user = (await _authHelper.GetUserFromToken(_authHelper.GetToken() ?? ""))!;

        Items = await _selectSchedule.OrdersSince(DateTime.Now.AddMonths(-3), user.Id);

        return Page();
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
