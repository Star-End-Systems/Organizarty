using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Adapters;
using Organizarty.Application.App.Locations.Entities;
using Organizarty.Application.App.Locations.UseCases;
using Organizarty.Application.App.Party.Enums;
using Organizarty.Application.App.Party.UseCases;
using Organizarty.Application.Exceptions;
using Organizarty.UI.Attributes;
using Organizarty.UI.Helpers;
using System.ComponentModel.DataAnnotations;
namespace Organizarty.UI.Pages.Clients.Party;

[Authorized("/Clients/Accounts/Login", UserType.Client)]
public class NewPartyModel : PageModel
{
    private readonly ILogger<NewPartyModel> _logger;
    private readonly CreatePartyUseCase _createParty;
    private readonly SelectLocationUseCase _selectLocation;
    private readonly AuthenticationHelper _authHelper;

    public NewPartyModel(ILogger<NewPartyModel> logger, CreatePartyUseCase createParty, SelectLocationUseCase selectLocation, AuthenticationHelper authHelper)
    {
        _logger = logger;
        _createParty = createParty;
        _selectLocation = selectLocation;
        _authHelper = authHelper;
    }

    [BindProperty]
    public InputModel Input { get; set; } = default!;

    public class InputModel
    {
        [Display(Name = "Search")]
        public string? Search { get; set; }

        [Required(ErrorMessage="O campo 'Nome' é obrigatório!")]
        [Display(Name = "Nome")]
        public string Name { get; set; } = default!;

        [Range(1, 500, ErrorMessage = "A")]
        [Required(ErrorMessage = "Material cost is required")]        
        [Display(Name = "Número de convidados")]
        public int Guests { get; set; } = default!;

        [Required]
        [Display(Name = "Tipo de Festa")]
        public PartyType PartyType { get; set; } = default!;

        [Required]
        [Display(Name = "Localização")]
        public Guid LocationId { get; set; } = default!;
    }

    public List<Location> Locations { get; set; } = new();

    public async Task OnGetAsync()
    {
        Locations = await _selectLocation.ListAllAvaible();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var user = (await _authHelper.GetUserFromToken(_authHelper.GetToken() ?? ""))!;

        if (!ModelState.IsValid)
        {
            await OnGetAsync();
            return Page();
        }

        var data = new CreatePartyDto(Input.Name, Input.Guests, Input.PartyType, Input.LocationId, user.Id);

        try
        {
            var party = await _createParty.Execute(data);
            return Redirect("/Clients/MyParties");
        }
        catch (ValidationFailException e)
        {
            e.Errors.ForEach(e => ModelState.AddModelError(string.Empty, e.message));
            await OnGetAsync();
            return Page();
        }
        catch (Exception e)
        {
            _logger.LogError(e.ToString());
            ModelState.AddModelError(string.Empty, "Erro ao criar festa. Tente novamente mais tarde ");
            await OnGetAsync();
            return Page();
        }
    }
}
