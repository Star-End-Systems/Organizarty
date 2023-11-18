using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Application.App.ThirdParties.UseCases;
using Organizarty.Application.Exceptions;
using Organizarty.UI.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Organizarty.UI.Pages.ThirdParty.Accounts;

[Unauthenticated("/ThirdParty")]
public class RegisterThirdPartyModel : PageModel
{
    private readonly ILogger<RegisterThirdPartyModel> _logger;
    private readonly RegisterThirdPartyUseCase _registerThirdParty;

    public RegisterThirdPartyModel(ILogger<RegisterThirdPartyModel> logger, RegisterThirdPartyUseCase registerThirdParty)
    {
        _logger = logger;
        _registerThirdParty = registerThirdParty;
    }

    [BindProperty]
    public InputModel Input { get; set; } = default!;

    public class InputModel
    {
        [Display(Name = "Nome")]
        [Required]
        public string Name { get; set; } = "";

        [Display(Name = "Descrição")]
        [Required]
        public string Description { get; set; } = "";

        [Display(Name = "Endereço")]
        [Required]
        public string Address { get; set; } = "";

        [Display(Name = "Email para Login")]
        [Required]
        public string LoginEmail { get; set; } = "";

        [Display(Name = "Email para Contato")]
        [Required]
        public string ContactEmail { get; set; } = "";

        [Display(Name = "Senha")]
        [Required]
        public string Password { get; set; } = "";

        [Display(Name = "CNPJ")]
        [Required]
        public string CNPJ { get; set; } = "";

        [Display(Name = "Imagem")]
        [Required]
        public string ProfilePictureURL { get; set; } = "";

        [Display(Name = "Telefone")]
        [Required]
        public string Phone { get; set; } = "";

        [Display(Name = "Telefone para contato")]
        [Required]
        public string ContactPhone { get; set; } = "";
    }

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var data = new RegisterThirdPartyDto(Input.Name, Input.Description, Input.Address, Input.LoginEmail, Input.Password, Input.Phone, Input.ContactEmail, Input.ContactPhone, Input.CNPJ, Input.ProfilePictureURL, new());

        try
        {
            var user = await _registerThirdParty.Execute(data);
            return Redirect("/");
        }
        catch (ValidationFailException e)
        {
            foreach (var err in e.Errors)
            {
                ModelState.AddModelError(string.Empty, err.message);
            }

            return Page();
        }
    }
}
