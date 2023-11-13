using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Application.App.Users.UseCases;
using Organizarty.Application.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace Organizarty.UI.Pages.Accounts;

public class LoginUserModel : PageModel
{
    private readonly LoginUserUseCase _loginUser;
    private readonly ILogger<LoginUserModel> _logger;

    public LoginUserModel(ILogger<LoginUserModel> logger, LoginUserUseCase loginUser)

    {
        _logger = logger;
        _loginUser = loginUser;
    }

    [BindProperty]
    public InputModel Input { get; set; } = default!;

    public class InputModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; } = default!;

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; } = default!;

    }

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var data = new LoginUserDto(Input.Email, Input.Password);

        try
        {
            await _loginUser.Execute(data);
        }
        catch (ValidationFailException e)
        {
            foreach (var err in e.Errors)
            {
                ModelState.TryAddModelError(err.field, err.message);
            }
        }
        catch (NotFoundException e)
        {
            ModelState.TryAddModelError(string.Empty, e.Message);
        }

        if (!ModelState.IsValid)
        {
            return Page();
        }

        return RedirectToPage("", new { email = Input.Email, password = Input.Password });
    }
}
