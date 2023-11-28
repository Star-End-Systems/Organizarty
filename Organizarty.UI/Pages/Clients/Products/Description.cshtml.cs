using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Application.App.Foods.Entities;
using TP = Organizarty.Application.App.ThirdParties.Entities.ThirdParty;
using System.ComponentModel.DataAnnotations;
using Organizarty.Application.App.Party.Entities;
using Organizarty.Application.App.Users.Entities;
using Organizarty.UI.Helpers;
using Organizarty.Application.App.Party.UseCases;
using Organizarty.Application.App.ThirdParties.UseCases;
using Organizarty.Application.App.Foods.UseCases;
using Organizarty.UI.Attributes;
using Organizarty.Adapters;

namespace Organizarty.UI.Pages.Clients.Products;

[Authorized("/Clients/Accounts/Login", UserType.Client)]
public class DescriptionModel : PageModel
{
    private readonly ILogger<DescriptionModel> _logger;
    private readonly AuthenticationHelper _authHelper;
    private readonly SelectPartyUseCase _selectParty;
    private readonly SelectThirdPartyUseCase _selectThirdParty;
    private readonly SelectFoodsUseCase _selectFoods;
    private readonly AddFoodToPartyUseCase _addFood;

    public DescriptionModel(ILogger<DescriptionModel> logger, AuthenticationHelper authHelper, SelectPartyUseCase selectParty, SelectThirdPartyUseCase selectThirdParty, SelectFoodsUseCase selectFoods, AddFoodToPartyUseCase addFood)
    {
        _logger = logger;
        _authHelper = authHelper;
        _selectParty = selectParty;
        _selectThirdParty = selectThirdParty;
        _selectFoods = selectFoods;
        _addFood = addFood;
    }

    [BindProperty]
    public InputModel Input { get; set; } = default!;

    public class InputModel
    {
        [Display(Name = "Notas")]
        public string? Note { get; set; }

        [Display(Name = "Quantidade")]
        [Required]
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Festa")]
        public Guid PartyId { get; set; } = default!;
    }

    public FoodInfo Food { get; set; } = new();
    public TP ThirdParty { get; set; } = new();
    public List<PartyTemplate> Parties { get; set; } = new();
    public User UserModel { get; set; } = new();

    public async Task OnGetAsync(Guid productId)
    {
        Food = await _selectFoods.FindByIdWithDetail(productId) ?? new();

        ThirdParty = await _selectThirdParty.FindById(Food.FoodType.ThirdPartyId) ?? throw new Exception(Food.FoodType.ThirdPartyId.ToString());

        UserModel = (await _authHelper.GetUserFromToken(_authHelper.GetToken()!))!;
        Parties = await _selectParty.FromUser(UserModel.Id);

    }

    public async Task<IActionResult> OnPostAsync(Guid productId)
    {
        if (!ModelState.IsValid)
        {
            await OnGetAsync(productId);
            return Page();
        }

        try
        {
            await _selectFoods.FindByIdWithDetail(productId);

            await _addFood.Execute(new(productId, Input.PartyId, Input.Quantity, Input.Note ?? ""));
            return Redirect($"/Clients/Party/Detail/{Input.PartyId}");
        }
        catch (Exception e)
        {
            // TODO: add error to ModelState
            _logger.LogError(e.ToString());
            return Page();
        }

    }
}
