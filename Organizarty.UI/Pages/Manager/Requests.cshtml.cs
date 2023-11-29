using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Application.App.Schedules.Entities;
using Organizarty.Application.App.Schedules.UseCases;
using System.ComponentModel.DataAnnotations;
namespace Organizarty.UI.Pages;

public class RequestsManagerModel : PageModel
{
    private readonly ILogger<RequestsManagerModel> _logger;
    private readonly SelectScheduleUseCase _selectSchedule;

    public RequestsManagerModel(ILogger<RequestsManagerModel> logger, SelectScheduleUseCase selectSchedule)
    {
        _logger = logger;
        _selectSchedule = selectSchedule;
    }

    public InputModel Input { get; set; } = default!;

    public class InputModel
    {
        [Required]
        [Display(Name = "Search")]
        public string Search { get; set; } = default!;
    }

    public List<ItemOrder> Orders { get; set; } = new();

    public async Task OnGetAsync()
    {
        Orders = await _selectSchedule.OrdersFromManager();
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
