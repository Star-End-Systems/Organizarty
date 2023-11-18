using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Adapters;
using Organizarty.Application.App.Users.UseCases;
using Organizarty.Application.Exceptions;
using Organizarty.UI.Attributes;
using Organizarty.UI.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Organizarty.UI.Pages.Clients.Accounts;

[Unauthenticated]
public class LoginUserModel : PageModel
{
    private readonly LoginUserUseCase _loginUser;
    private readonly ILogger<LoginUserModel> _logger;

    private readonly AuthenticationHelper _authHelper;
    private readonly ITokenProvider _tokenProvider;

    public LoginUserModel(ILogger<LoginUserModel> logger, LoginUserUseCase loginUser, ITokenProvider tokenProvider, AuthenticationHelper authenticationHelper)

    {
        _logger = logger;
        _loginUser = loginUser;
        _tokenProvider = tokenProvider;

        _authHelper = authenticationHelper;

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

    public void OnGet()
    {
        var user = AccountHelper.GetUser(Request);

        if (user is not null)
        {
            Input.Email = user.Email;
            Input.Password = user.Password;
        }
    }

    public async Task<IActionResult> OnPostAsync()
    {
        _authHelper.AddResponse(Response);

        if (!ModelState.IsValid)
        {
            return Page();
        }

        var data = new LoginUserDto(Input.Email, Input.Password);

        try
        {
            var u = await _loginUser.Execute(data);
            var token = _tokenProvider.GenerateToken(u.Id.ToString(), u.UserName, UserType.Client);

            _authHelper.WriteToken(token);
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
            if (ModelState.TryAddModelError(string.Empty, e.Message))
            {
                return Page();
            }
        }

        // Redirect to another page
        return Page();
    }
}
