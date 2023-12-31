using Organizarty.Application.App.ThirdParties.Data;
using Organizarty.Application.App.ThirdParties.Entities;
using Organizarty.Application.App.Utils.Enums;

namespace Organizarty.Application.App.ThirdParties.UseCases;

public class SelectThirdPartyUseCase
{
    private readonly IThirdPartyRepository _thirdPartyRepository;

    public SelectThirdPartyUseCase(IThirdPartyRepository thirdPartyRepository)
    {
        _thirdPartyRepository = thirdPartyRepository;
    }

    public async Task<ThirdParty?> FindByEmail(string email)
      => await _thirdPartyRepository.FindByEmail(email);

    public async Task<ThirdParty?> FindById(string id)
      => await _thirdPartyRepository.FindById(id);

    public async Task<List<ThirdParty>> GetAllPending()
      => await _thirdPartyRepository.AllWithAuthorization(AuthorizationStatus.Pending);
}
