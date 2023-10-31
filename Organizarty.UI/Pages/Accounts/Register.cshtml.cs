using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Organizarty.UI.Pages.Accounts;

public class RegisterUserModel : PageModel{

    [BindProperty]
    public InputModel Input {get; set;} = default!;

    public class InputModel{
        public string Email {get; set;} = default!;

        public string Password {get; set;} = default!;
         
        [Compare("Password")]
        public string ConfirmPassword {get; set;} = default!;
    }

    public void OnGet() { }

/*    public IActionResult OnPost(){
        if (!ModelState.IsValid){
            return Page();
        }
    } */
}
