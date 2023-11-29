using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Application.App.Schedules.Entities;
using Organizarty.Application.App.Schedules.UseCases;
using System.ComponentModel.DataAnnotations;
namespace Organizarty.UI.Pages;

public class RequestsModel : PageModel
{
    private readonly ILogger<RequestsModel> _logger;
    private readonly SelectScheduleUseCase _selectSchedule;

    public RequestsModel(ILogger<RequestsModel> logger, SelectScheduleUseCase selectSchedule)
    {
        _logger = logger;

        _selectSchedule = selectSchedule;
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

    public async Task<IActionResult> OnGetAsync(Guid scheduleid)
    {
        Items = await _selectSchedule.SelectOrdersFromSchedule(scheduleid);

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
