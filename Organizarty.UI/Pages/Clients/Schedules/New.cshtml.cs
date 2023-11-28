using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Adapters;
using Organizarty.Application.App.Locations.Entities;
using Organizarty.Application.App.Schedules.UseCases;
using Organizarty.Application.Exceptions;
using Organizarty.UI.Attributes;
using System.ComponentModel.DataAnnotations;
namespace Organizarty.UI.Pages.Clients.Schedules;

[Authorized("/Clients/Accounts/Login", UserType.Client)]
public class NewScheduleModel : PageModel
{
    private readonly ILogger<NewScheduleModel> _logger;
    private readonly ScheduleUseCase _schedule;

    public NewScheduleModel(ILogger<NewScheduleModel> logger, ScheduleUseCase schedule)
    {
        _logger = logger;
        _schedule = schedule;
    }

    [BindProperty]
    public InputModel Input { get; set; } = new();

    public class InputModel
    {
        [Required]
        [Display(Name = "Data de ínicio")]
        public DateTime Date { get; set; } = DateTime.Now.Date;

        [Required]
        [Display(Name = "Duração")]
        public int Duration { get; set; }
    }

    public List<Location> Locations { get; set; } = new();

    public async Task<IActionResult> OnPostAsync(Guid partyid)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        try
        {
            var party = await _schedule.Execute(new(partyid, Input.Date, Input.Duration));
            return Redirect("/Clients/MyParties");
        }
        catch (ValidationFailException e)
        {
            _logger.LogError(e.ToString());
            e.Errors.ForEach(e => ModelState.AddModelError(string.Empty, e.message));
            return Page();
        }
        catch (Exception e)
        {
            _logger.LogError(e.ToString());
            ModelState.AddModelError(string.Empty, "Erro ao criar festa. Tente novamente mais tarde ");
            return Page();
        }
    }
}
