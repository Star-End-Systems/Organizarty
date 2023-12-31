using Organizarty.Application.App.Services.Entities;

namespace Organizarty.Application.App.Services.Data;

public interface IServiceTypeRepository
{
    Task<ServiceType> Create(ServiceType service);
    Task<ServiceType> Update(ServiceType service);

    Task<ServiceType?> FindById(string id);
    Task<ServiceType?> FindByIdWithItens(string id);

    Task<List<ServiceType>> FindByThirdParty(string thirdPartyId);

    Task<List<ServiceType>> GetAvaibleServices();
}
