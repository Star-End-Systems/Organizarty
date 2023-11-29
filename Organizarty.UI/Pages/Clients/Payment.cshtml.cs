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
public class PaymentModel : PageModel
{
    private readonly ILogger<PaymentModel> _logger;
    private readonly SelectScheduleUseCase _selectSchedule;
    private readonly AuthenticationHelper _authHelper;

    public PaymentModel(ILogger<PaymentModel> logger, SelectScheduleUseCase selectSchedule, AuthenticationHelper authHelper)
    {
        _logger = logger;
        _selectSchedule = selectSchedule;
        _authHelper = authHelper;
    }

    [BindProperty]
    public InputModel Input { get; set; } = default!;

    public List<ItemOrder> Items { get; set; } = new();
    public Schedule Schedule { get; set; } = new();

    public class InputModel
    {
        [Display(Name = "Search")]
        public string Search { get; set; } = default!;
    }
    public async Task<IActionResult> OnGetAsync(Guid scheduleid)
    {
        Items = await _selectSchedule.SelectOrdersFromSchedule(scheduleid);
        Schedule = await _selectSchedule.FindById(scheduleid);

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
