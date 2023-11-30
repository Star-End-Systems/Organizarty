using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Adapters;
using Organizarty.Application.App.Managers.UseCases;
using Organizarty.Application.Exceptions;
using Organizarty.UI.Attributes;
using Organizarty.UI.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Organizarty.UI.Pages.Manager.Accounts;

[Unauthenticated("/Manager")]
public class LoginManagerModel : PageModel
{
    private readonly ILogger<LoginManagerModel> _logger;
    private readonly LoginManagerUseCase _loginManager;

    private readonly AuthenticationHelper _authHelper;
    private readonly ITokenProvider _tokenProvider;

    public LoginManagerModel(ILogger<LoginManagerModel> logger, LoginManagerUseCase loginManager, ITokenProvider tokenProvider, AuthenticationHelper authHelper)
    {
        _logger = logger;
        _loginManager = loginManager;
        _tokenProvider = tokenProvider;
        _authHelper = authHelper;
    }

    [BindProperty]
    public InputModel Input { get; set; } = default!;

    public class InputModel
    {
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
        _authHelper.AddResponse(Response);

        _logger.LogInformation(Input.Email, Input.Password);

        if (!ModelState.IsValid)
        {
            return Page();
        }

        _logger.LogInformation(Input.Email, Input.Password);

        try
        {
            var manager = await _loginManager.Execute(new(Input.Email, Input.Password));

            var token = _tokenProvider.GenerateToken(manager.Id.ToString(), manager.Email, UserType.Mannager);

            _authHelper.WriteToken(token);
            return Redirect("/Manager");
        }
        catch (ValidationFailException e)
        {
            _logger.LogError(e.ToString());
            foreach (var err in e.Errors)
            {
                ModelState.AddModelError(string.Empty, err.message);
            }

            return Page();
        }
        catch (Exception e)
        {
            _logger.LogError(e.StackTrace);
            _logger.LogError(e.ToString());
            ModelState.AddModelError(string.Empty, e.Message);
            return Page();
        }
    }
}
