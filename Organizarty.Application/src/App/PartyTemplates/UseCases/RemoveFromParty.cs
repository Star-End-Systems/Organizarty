using Organizarty.Application.App.Party.Data;

namespace Organizarty.Application.App.Party.UseCases;

public class RemoveFromPartyUseCase
{
    private readonly IDecorationGroupRepository _decorationRepository;
    private readonly IFoodGroupRepository _foodRepository;
    private readonly IServiceGroupRepository _serviceRepository;

    public RemoveFromPartyUseCase(IDecorationGroupRepository decorationRepository, IFoodGroupRepository foodRepository, IServiceGroupRepository serviceRepository)
    {
        _decorationRepository = decorationRepository;
        _foodRepository = foodRepository;
        _serviceRepository = serviceRepository;
    }
    public async Task RemoveFood(string foodid)
      => await _foodRepository.Delete(foodid);

    public async Task RemoveDecoration(string foodid)
      => await _decorationRepository.Delete(foodid);

    public async Task RemoveService(string foodid)
      => await _serviceRepository.Delete(foodid);

}
