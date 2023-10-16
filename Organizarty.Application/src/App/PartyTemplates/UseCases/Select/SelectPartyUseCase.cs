using Organizarty.Application.App.Party.Data;
using Organizarty.Application.App.Party.Entities;

namespace Organizarty.Application.App.Party.UseCases;

public class SelectPartyUseCase
{
    private readonly IPartyTemplateRepository _partyRepository;
    private readonly IDecorationGroupRepository _decorationRepository;
    private readonly IFoodGroupRepository _foodRepository;
    private readonly IServiceGroupRepository _serviceRepository;

    public SelectPartyUseCase(IPartyTemplateRepository partyRepository, IDecorationGroupRepository decorationRepository, IFoodGroupRepository foodRepository, IServiceGroupRepository serviceRepository)
    {
        _partyRepository = partyRepository;
        _decorationRepository = decorationRepository;
        _foodRepository = foodRepository;
        _serviceRepository = serviceRepository;
    }

    public async Task<PartyTemplate> FromId(Guid partyId)
      => await _partyRepository.FromId(partyId);

    public async Task<List<DecorationGroup>> GetDecorations(Guid partyId)
      => await _decorationRepository.ListFoodFromParty(partyId);

    public async Task<List<FoodGroup>> GetFoods(Guid partyId)
      => await _foodRepository.ListFoodFromParty(partyId);

    public async Task<List<ServiceGroup>> GetServices(Guid partyId)
      => await _serviceRepository.ListFoodFromParty(partyId);
}
