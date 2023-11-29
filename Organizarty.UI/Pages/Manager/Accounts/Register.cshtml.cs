using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Application.App.Managers.UseCases;
using Organizarty.Application.Exceptions;
using Organizarty.UI.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Organizarty.UI.Pages.Manager.Accounts;

[Unauthenticated("/Manager")]
public class RegisterManagerModel : PageModel
{
    private readonly ILogger<RegisterManagerModel> _logger;
    private readonly RegisterManagerUseCase _registerManager;

    public RegisterManagerModel(ILogger<RegisterManagerModel> logger, RegisterManagerUseCase registerManager)
    {
        _logger = logger;
        _registerManager = registerManager;
    }

    [BindProperty]
    public InputModel Input { get; set; } = default!;

    public class InputModel
    {
        [Display(Name = "Nome")]
        [Required]
        public string Name { get; set; } = "";

        [Display(Name = "Email")]
        [Required]
        public string Email { get; set; } = "";

        [Display(Name = "Senha")]
        [Required]
        public string Password { get; set; } = "";
    }

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        try
        {
            var user = await _registerManager.Execute(new(Input.Name, Input.Email, Input.Password));
            return Redirect("/Manager/Accounts/Login");
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
