using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Application.App.Schedules.Entities;
using Organizarty.Application.App.Schedules.UseCases;
namespace Organizarty.UI.Pages;

public class RequestsThirdPartyModel : PageModel
{
    private readonly ILogger<RequestsThirdPartyModel> _logger;
    private readonly SelectScheduleUseCase _selectSchedule;

    public RequestsThirdPartyModel(ILogger<RequestsThirdPartyModel> logger, SelectScheduleUseCase selectSchedule)
    {
        _logger = logger;
        _selectSchedule = selectSchedule;
    }

    public List<FoodOrder> Orders { get; set; } = new();

    // public async Task OnGetAsync()
    public async Task OnGetAsync()
    {
        // Orders = await _selectSchedule.SelectFoodOrders(scheduleId);
        var food = new FoodOrder
        {
            FoodInfo = new()
            {
                Flavour = "Carne",
                FoodType = new()
                {
                    Name = "Coxinha"
                }
            },
            Note = "Sem cebola",
            Quantity = 29,
            Status = Application.App.Schedules.Enum.ItemStatus.PENDING
        };

        Orders = new() { food, food, food, food, food, food, food, food, food, food, food, food, food, food, food, food, food, food, food, food };
    }
}
