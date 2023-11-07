using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Organizarty.UI.Pages.Clients;

public class ClientModel: PageModel{
    public void OnGet(){

    }

    public IActionResult OnPost(){
        return Page();
    }
}