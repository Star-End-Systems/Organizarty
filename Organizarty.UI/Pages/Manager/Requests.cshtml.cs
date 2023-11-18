using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
namespace Organizarty.UI.Pages;

public class RequestsManagerModel : PageModel
{
    private readonly ILogger<RequestsManagerModel> _logger;

    public RequestsManagerModel(ILogger<RequestsManagerModel> logger)
    {
        _logger = logger;
    }
    public InputModel Input{get; set;} = default!;
    public class InputModel{
        [Required]
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
