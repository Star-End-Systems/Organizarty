using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Adapters;
using Organizarty.UI.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Organizarty.UI.Pages.ThirdParty.Services;

[Authorized("/ThirdParty/Accounts/Login", UserType.ThirdParty, UserType.Mannager)]
public class AddServiceModel : PageModel
{
    public void OnGet()
    {
      Console.WriteLine("salve");
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
