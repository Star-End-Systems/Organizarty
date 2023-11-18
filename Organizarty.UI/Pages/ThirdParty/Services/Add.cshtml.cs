using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Organizarty.UI.Pages.ThirdParty.Services;

public class AddServiceModel : PageModel
{
    public void OnGet()
    {
    }


    public IActionResult OnPost()
    {
        return Page();
    }

    [BindProperty]
    public InputModel Input { get; set; } = default!;

    public class InputModel
    {
        public InputModel Input { get; set; } = default!;
        [Required]
        [Display(Name = "Search")]
        public string Search { get; set; } = default!;
    }
}
