using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
namespace Organizarty.UI.Pages;

public class DescriptionModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public DescriptionModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public InputModel Input{get; set;} = default!;

    public class InputModel{
        [Display(Name = "ClientNotes")]
        public string ClientNotes {get; set;} = default!;
    }
    public void OnGet()
    {

    }
        public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        return RedirectToPage("", new { clientNotes = Input.ClientNotes});
    }        
}