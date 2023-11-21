using Organizarty.Application.App.ThirdParties.Entities;
using Organizarty.Application.App.Utils.Enums;

namespace Organizarty.Application.App.ThirdParties.Data;

public interface IThirdPartyRepository
{
    Task<ThirdParty> Create(ThirdParty thirdParty);
    Task<ThirdParty> Update(ThirdParty thirdParty);
    Task<ThirdParty?> FindByEmail(string email);
    Task<ThirdParty?> FindById(Guid id);
    Task<List<ThirdParty>> AllWithAuthorization(AuthorizationStatus status);

}
