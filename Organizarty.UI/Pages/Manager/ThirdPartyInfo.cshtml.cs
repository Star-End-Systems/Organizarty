using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
namespace Organizarty.UI.Pages;

public class AcceptThirdPartyModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public AcceptThirdPartyModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public InputModel Input{get; set;} = default!;

    public class InputModel{
        [Display(Name = "Descrição")]
        public string Description {get; set;} = default!;

        [Display(Name = "Email de Login")]
        public string LoginEmail {get; set;} = default!;

        [Display(Name = "Email de Contato")]
        public string ContactEmail {get; set;} = default!;

        [Display(Name = "Nome")]
        public string Name {get; set;} = default!;

        [Display(Name = "CPF/CNPJ")]
        public string CP {get; set;} = default!;

        [Display(Name = "Cel/Tel 2")]
        public string PrimaryTel {get; set;} = default!;
        
        [Display(Name = "Cel/Tel 2")]
        public string SecondaryTel {get; set;} = default!;

        [Display(Name = "Localização")]
        public string Location {get; set;} = default!;
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

        return RedirectToPage("", new { description = Input.Description, loginEmail = Input.LoginEmail, contactEmail = Input.ContactEmail, name = Input.Name, cp = Input.CP, primaryTel = Input.PrimaryTel, secundaryTel = Input.SecondaryTel, location = Input.Location });
    }        
}
