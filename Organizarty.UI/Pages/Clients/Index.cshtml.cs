using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Organizarty.UI.Pages.Clients;

public class ClientIndexModel : PageModel
{
    [BindProperty]
    public InputModel Input { get; set; } = default!;

    public class InputModel
    {
        public string Search { get; set; } = default!;

    }

    public void OnGet()
    {

    }

    public IActionResult OnPost()
    {
        return Page();
    }
}
