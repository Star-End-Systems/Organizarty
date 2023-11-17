using Organizarty.Application.App.ThirdParties.Data;
using Organizarty.Application.App.ThirdParties.Entities;

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

    public async Task<ThirdParty?> FindById(Guid id)
      => await _thirdPartyRepository.FindById(id);
}
