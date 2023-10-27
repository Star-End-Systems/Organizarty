using Organizarty.Application.App.Schedules.Data;
using Organizarty.Application.App.Schedules.Entities;
using Organizarty.Application.App.Schedules.Enum;

namespace Organizarty.Application.App.Schedules.UseCases;

public class ChangeItemStatusUseCase
{
    private readonly IDecorationOrderRepository _decorationRepository;
    private readonly IFoodOrderRepository _foodRepository;
    private readonly IServiceOrderRepository _serviceRepository;

    public ChangeItemStatusUseCase(IDecorationOrderRepository decorationRepository, IFoodOrderRepository foodRepository, IServiceOrderRepository serviceRepository)
    {
        _decorationRepository = decorationRepository;
        _foodRepository = foodRepository;
        _serviceRepository = serviceRepository;
    }

    public async Task<DecorationOrder> Execute(DecorationOrder decoration, ItemStatus status)
    {
        decoration.Status = status;

        return await _decorationRepository.Update(decoration);
    }

    public async Task<ServiceOrder> Execute(ServiceOrder service, ItemStatus status)
    {
        service.Status = status;

        return await _serviceRepository.Update(service);
    }

    public async Task<FoodOrder> Execute(FoodOrder food, ItemStatus status)
    {
        food.Status = status;

        return await _foodRepository.Update(food);
    }
}