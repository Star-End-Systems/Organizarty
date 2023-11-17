using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Adapters;
using Organizarty.Application.App.ThirdParties.UseCases;
using Organizarty.Application.Exceptions;
using Organizarty.UI.Attributes;
using Organizarty.UI.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Organizarty.UI.Pages.ThirdParty.Accounts;

[Unauthenticated]
public class LoginThirdPartyModel : PageModel
{
    private readonly LoginThirdPartyUseCase _loginUseCase;
    private readonly ILogger<LoginThirdPartyModel> _logger;

    private readonly AuthenticationHelper _authHelper;
    private readonly ITokenProvider _tokenProvider;

    public LoginThirdPartyModel(ILogger<LoginThirdPartyModel> logger, LoginThirdPartyUseCase login, ITokenProvider tokenProvider, AuthenticationHelper authenticationHelper)

    {
        _logger = logger;
        _loginUseCase = login;
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

    public void OnGet(){}

    public async Task<IActionResult> OnPostAsync()
    {
        _authHelper.AddResponse(Response);

        if (!ModelState.IsValid)
        {
            return Page();
        }

        var data = new LoginThirdPartyDto(Input.Email, Input.Password);

        try
        {
            var u = await _loginUseCase.Execute(data);
            var token = _tokenProvider.GenerateToken(u.Id.ToString(), u.LoginEmail, UserType.ThirdParty);

            _authHelper.WriteToken(token);
        }
        catch (ValidationFailException e)
        {
            foreach (var err in e.Errors)
            {
                ModelState.TryAddModelError(string.Empty, err.message);
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


        return Page();
    }
}
