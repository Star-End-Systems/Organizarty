using Organizarty.Application.App.Schedules.Data;
using Organizarty.Application.App.Schedules.Entities;
using Organizarty.Application.App.Schedules.Enum;
using Organizarty.Application.Exceptions;

namespace Organizarty.Application.App.Schedules.UseCases;

public class ChangeItemStatusUseCase
{
    private readonly IDecorationOrderRepository _decorationRepository;
    private readonly IFoodOrderRepository _foodRepository;
    private readonly IServiceOrderRepository _serviceRepository;

    private readonly OrderFoodUseCase _orderFood;
    private readonly OrderServiceUseCase _orderService;

    public ChangeItemStatusUseCase(IDecorationOrderRepository decorationRepository, IFoodOrderRepository foodRepository, IServiceOrderRepository serviceRepository, OrderFoodUseCase orderFood, OrderServiceUseCase orderService)
    {
        _decorationRepository = decorationRepository;
        _foodRepository = foodRepository;
        _serviceRepository = serviceRepository;
        _orderFood = orderFood;
        _orderService = orderService;
    }

    public async Task<DecorationOrder> Execute(DecorationOrder decoration, ItemStatus status)
    {
        decoration.Status = status;

        var dec = await _decorationRepository.Update(decoration);

        var empty = (await _decorationRepository.AllOpen()).Count == 0;

        if (empty)
        {
            await _orderFood.Execute(dec.ScheduleId);
            await _orderService.Execute(dec.ScheduleId);
        }

        return dec;
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

    public async Task<DecorationOrder> AcceptDecoration(Guid orderid)
    {
        var decoration = await _decorationRepository.FindById(orderid) ?? throw new NotFoundException("Pedido não encontrado.");

        return await Execute(decoration, ItemStatus.ACCEPT);
    }

    public async Task<DecorationOrder> RefuseDecoration(Guid orderid)
    {
        var decoration = await _decorationRepository.FindById(orderid) ?? throw new NotFoundException("Pedido não encontrado.");

        return await Execute(decoration, ItemStatus.REFUSED);
    }

    public async Task<FoodOrder> AcceptFood(Guid orderid)
    {
        var food = await _foodRepository.FindById(orderid) ?? throw new NotFoundException("Pedido não encontrado.");

        return await Execute(food, ItemStatus.ACCEPT);
    }

    public async Task<FoodOrder> RefuseFood(Guid orderid)
    {
        var food = await _foodRepository.FindById(orderid) ?? throw new NotFoundException("Pedido não encontrado.");

        return await Execute(food, ItemStatus.REFUSED);
    }

    public async Task<ServiceOrder> AcceptService(Guid orderid)
    {
        var service = await _serviceRepository.FindById(orderid) ?? throw new NotFoundException("Pedido não encontrado.");

        return await Execute(service, ItemStatus.ACCEPT);
    }

    public async Task<ServiceOrder> RefuseService(Guid orderid)
    {
        var food = await _serviceRepository.FindById(orderid) ?? throw new NotFoundException("Pedido não encontrado.");

        return await Execute(food, ItemStatus.REFUSED);
    }
}
