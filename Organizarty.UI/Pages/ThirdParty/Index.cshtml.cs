using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Adapters;
using Organizarty.UI.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Organizarty.UI.Pages.ThirdParty;

[Authorized("/ThirdParty/Accounts/Login", UserType.ThirdParty, UserType.Mannager)]
public class IndexModel : PageModel
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
