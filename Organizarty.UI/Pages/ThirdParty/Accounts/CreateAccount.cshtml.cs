using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Application.App.ThirdParties.UseCases;
using Organizarty.Application.Exceptions;
using Organizarty.UI.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Organizarty.UI.Pages.ThirdParty.Accounts;

[Unauthenticated("/ThirdParty")]
public class CreateThirdPartyAccountModel : PageModel
{
    private readonly RegisterThirdPartyUseCase _registerThirdParty;
    private readonly ILogger<CreateThirdPartyAccountModel> _logger;

    public CreateThirdPartyAccountModel(ILogger<CreateThirdPartyAccountModel> logger, RegisterThirdPartyUseCase registerThirdParty)

    {
        _logger = logger;
        _registerThirdParty = registerThirdParty;
    }

    [BindProperty]
    public InputModel Input { get; set; } = default!;

    public class InputModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; } = default!;

        [Required]
        [Display(Name = "Localização")]
        public string Location { get; set; } = default!;


        [Required]
        [Display(Name = "Nome Completo")]
        public string FullName { get; set; } = default!;

        [Required]
        [Display(Name = "Nome de usuário")]
        public string Username { get; set; } = default!;

        [Required]
        [Display(Name = "Id da localização")]
        public string LocationID { get; set; } = default!;

        [Required]
        [Display(Name = "CNPJ")]
        public string CNPJ { get; set; } = default!;

        [Required]
        [Display(Name = "Telefone")]
        public string Tel { get; set; } = default!;

        [Required]
        [Display(Name = "Senha ruim")]
        public string Password { get; set; } = default!;

        [Required]
        [Display(Name = "Senha")]
        public string ConfirmPassword { get; set; } = default!;
    }

    public void OnGet() { }
}
