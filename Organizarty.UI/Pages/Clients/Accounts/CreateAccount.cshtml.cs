using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Application.App.Users.UseCases;
using Organizarty.Application.Exceptions;
using Organizarty.UI.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Organizarty.UI.Pages.Clients.Accounts;

[Unauthenticated("/Clients")]
public class CreateAccountModel : PageModel
{
    private readonly RegisterUserUseCase _registerUser;
    private readonly ILogger<CreateAccountModel> _logger;

    public CreateAccountModel(ILogger<CreateAccountModel> logger, RegisterUserUseCase registerUser)

    {
        _logger = logger;
        _registerUser = registerUser;
    }

    [BindProperty]
    public InputModel Input { get; set; } = default!;

    public class InputModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; } = default!;

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
        [Display(Name = "Senha ruim")]
        public string Password { get; set; } = default!;

        [Display(Name = "CPF")]
        public string? CPF { get; set; }

        [Required]
        [Display(Name = "Telefone")]
        public string Tel { get; set; } = default!;
    }

    public void OnGet() { }
}
