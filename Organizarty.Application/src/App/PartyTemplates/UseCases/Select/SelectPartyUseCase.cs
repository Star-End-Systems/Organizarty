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

    public async Task<PartyTemplate?> ById(Guid partyId)
      => await _partyRepository.FindById(partyId);

    public async Task<PartyTemplate?> FromIdWithLocation(Guid partyId)
      => await _partyRepository.FromIdWithLocation(partyId);

    public async Task<List<DecorationGroup>> GetDecorations(Guid partyId)
      => await _decorationRepository.ListFromParty(partyId);

    public async Task<List<FoodGroup>> GetFoods(Guid partyId)
      => await _foodRepository.ListFromParty(partyId);

    public async Task<List<ServiceGroup>> GetServices(Guid partyId)
      => await _serviceRepository.ListFromParty(partyId);

    public async Task<List<PartyTemplate>> FromUser(Guid userId)
      => await _partyRepository.FromUser(userId);

    public async Task<FoodGroup?> FindFood(Guid id)
      => await _foodRepository.FindById(id);

    public async Task<DecorationGroup?> FindDecoration(Guid id)
      => await _decorationRepository.FindById(id);

    public async Task<ServiceGroup?> FindService(Guid id)
      => await _serviceRepository.FindById(id);
}
