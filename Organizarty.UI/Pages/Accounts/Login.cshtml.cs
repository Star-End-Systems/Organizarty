using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Organizarty.UI.Pages.Accounts;

public class LoginModel : PageModel {

    [BindProperty]
    public InputModel Input{get; set;} = default!;

    public class InputModel{
        [Required]
        [Display(Name = "Email")]
        public string Email {get; set;} = default!;

        [Required]
        [Display(Name = "Password")]
        public string Password {get; set;} = default!;

    }
        public void OnGet() { }
        public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        return RedirectToPage("", new { email = Input.Email, password = Input.Password });
    }        
}