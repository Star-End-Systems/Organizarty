using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
namespace Organizarty.UI.Pages;

public class ContactUsModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public ContactUsModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }
    
    public InputModel Input{get; set;} = default!;

    public class InputModel{
  
        [Display(Name = "Name")]
        public string Name {get; set;} = default!;

        [Display(Name = "Email")]
        public string Email {get; set;} = default!;

        [Display(Name = "Messagem")]
        public string Message {get; set;} = default!;
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

        return RedirectToPage("", new { name = Input.Name, email = Input.Email, message = Input.Message});
        }        
}