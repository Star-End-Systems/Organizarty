using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
namespace Organizarty.UI.Pages;

public class RequestsThirdPartyModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public RequestsThirdPartyModel(ILogger<IndexModel> logger)
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