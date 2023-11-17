using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Application.App.Schedules.Entities;
using Organizarty.Application.App.Schedules.UseCases;
using System.ComponentModel.DataAnnotations;
namespace Organizarty.UI.Pages;

public class RequestsThirdPartyModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly SelectScheduleUseCase _selectSchedule;

    public RequestsThirdPartyModel(ILogger<IndexModel> logger, SelectScheduleUseCase selectSchedule)
    {
        _logger = logger;
        _selectSchedule = selectSchedule;
    }

    [BindProperty]
    public InputModel Input{get; set;} = default!;

    public List<DecorationOrder> Orders {get; set;}

    public class InputModel{
        [Required]
        [Display(Name = "Search")]
        public string Search {get; set;} = default!;
    }

    public async Task OnGetAsync(Guid scheduleId)
    {
        var decorations = await _selectSchedule.SelectDecorationOrders(scheduleId);

    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        return RedirectToPage("", new { search = Input.Search});
    }        
}