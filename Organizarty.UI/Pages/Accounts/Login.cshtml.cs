using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Adapters;
using Organizarty.Application.App.Users.UseCases;
using Organizarty.Application.Exceptions;
using Organizarty.UI.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Organizarty.UI.Pages.Accounts;

public class LoginUserModel : PageModel
{
    private readonly LoginUserUseCase _loginUser;
    private readonly ILogger<LoginUserModel> _logger;

    private readonly AuthenticationHelper authHelper;
    private readonly ITokenProvider _tokenProvider;

    public LoginUserModel(ILogger<LoginUserModel> logger, LoginUserUseCase loginUser, ITokenProvider tokenProvider)

    {
        _logger = logger;
        _loginUser = loginUser;
        _tokenProvider = tokenProvider;

        authHelper = new AuthenticationHelper(Response);
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
            var u = await _loginUser.Execute(data);
            var token = _tokenProvider.GenerateToken(u.Id.ToString(), u.UserName, UserType.Client);
        Response.Cookies.Append(
            "JWT_TOKEN",
            token ?? "nada",
            new CookieOptions()
            {
                Path = "/"
            }
        );
        }
        catch (ValidationFailException e)
        {
            foreach (var err in e.Errors)
            {
                ModelState.TryAddModelError(err.field, err.message);
            }

            return Page();
        }
        catch (NotFoundException e)
        {
           if(ModelState.TryAddModelError(string.Empty, e.Message)){
            return Page();
           }
        }


        return RedirectToPage("", new { email = Input.Email, password = Input.Password });
    }
}
