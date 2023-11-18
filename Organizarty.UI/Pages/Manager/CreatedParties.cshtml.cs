using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
namespace Organizarty.UI.Pages;

public class CreatedPartiesModel : PageModel
{
    private readonly ILogger<CreatedPartiesModel> _logger;

    public CreatedPartiesModel(ILogger<CreatedPartiesModel> logger)
    {
        _logger = logger;
    }
    
    public InputModel Input{get; set;} = default!;

    public class InputModel{
  
        [Display(Name = "Search")]
        public string Search {get; set;} = default!;
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

        return RedirectToPage("", new { search = Input.Search});
    }        
}
