using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Application.App.Schedules.Entities;
using Organizarty.UI.Helpers;
using System.ComponentModel.DataAnnotations;
namespace Organizarty.UI.Pages;

public class NullLayoutModel : PageModel
{
    private readonly AuthenticationHelper _authHelper;

    public NullLayoutModel(AuthenticationHelper authHelper)
    {
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


    public async Task OnGetAsync()
    {
        Schedule = new()
        {
            Name = "alguma coisa"
        };
    }

    public void OnPost()
    {
        _authHelper.ClaerToken();
    }
}
