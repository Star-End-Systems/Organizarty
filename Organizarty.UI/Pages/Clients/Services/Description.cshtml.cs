using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Application.App.Services.Entities;
using TP = Organizarty.Application.App.ThirdParties.Entities.ThirdParty;
using Organizarty.Application.App.Services.UseCases;
using Organizarty.Application.App.ThirdParties.UseCases;
using System.ComponentModel.DataAnnotations;
using Organizarty.UI.Helpers;
using Organizarty.Application.App.Party.UseCases;
using Organizarty.Application.App.Party.Entities;
using Organizarty.Application.App.Users.Entities;
using Organizarty.UI.Attributes;
using Organizarty.Adapters;

namespace Organizarty.UI.Pages.Clients.Services;

[Authorized("/Clients/Accounts/Login", UserType.Client)]
public class DescriptionModel : PageModel
{
    private readonly SelectServicesUseCase _selectServices;
    private readonly SelectThirdPartyUseCase _selectThirdParty;
    private readonly ILogger<DescriptionModel> _logger;
    private readonly AuthenticationHelper _authHelper;
    private readonly SelectPartyUseCase _selectParty;
    private readonly AddServiceToPartyUsecase _addService;

    public DescriptionModel(ILogger<DescriptionModel> logger, SelectServicesUseCase selectServices, SelectThirdPartyUseCase selectThirdParty, AuthenticationHelper authHelper, SelectPartyUseCase selectParty, AddServiceToPartyUsecase addService)
    {
        _logger = logger;
        _selectServices = selectServices;
        _selectThirdParty = selectThirdParty;
        _authHelper = authHelper;
        _selectParty = selectParty;
        _addService = addService;
    }

    [BindProperty]
    public InputModel Input { get; set; } = default!;

    public class InputModel
    {
        [Display(Name = "Notas")]
        public string? Note { get; set; }

        [Required]
        [Display(Name = "Festa")]
        public Guid PartyId { get; set; } = default!;
    }

    public ServiceInfo Service { get; set; } = new();
    public TP ThirdParty { get; set; } = new();
    public List<PartyTemplate> Parties { get; set; } = new();
    public User UserModel { get; set; } = new();

    public async Task OnGetAsync(Guid serviceId)
    {
        try
        {
            Service = await _selectServices.FindSubServiceById(serviceId);
            ThirdParty = await _selectThirdParty.FindById(Service.ServiceType.ThirdPartyId) ?? throw new Exception(Service.ServiceType.ThirdPartyId.ToString());
            UserModel = (await _authHelper.GetUserFromToken(_authHelper.GetToken()!))!;
            Parties = await _selectParty.FromUser(UserModel.Id);
        }
        catch (Exception e)
        {
            _logger.LogError(e.ToString());
        }
    }

    public async Task<IActionResult> OnPostAsync(Guid serviceId)
    {
        if (!ModelState.IsValid)
        {
            await OnGetAsync(serviceId);
            return Page();
        }

        await _selectServices.FindSubServiceById(serviceId);
        var user = await _authHelper.GetUserFromToken(_authHelper.GetToken()!);

        var data = new AddServiceToPartyDto(serviceId, Input.PartyId, Input.Note ?? "");

        try
        {
            await _addService.Execute(data);
            return Redirect($"/Clients/Party/Detail/{Input.PartyId}");
        }
        catch (Exception e)
        {
            // TODO: add error to ModelState
            _logger.LogError(e.ToString());
            await OnGetAsync(serviceId);
            return Page();
        }

    }
}
