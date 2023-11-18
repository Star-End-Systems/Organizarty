using Organizarty.Application.App.Services.Entities;

namespace Organizarty.Application.App.Services.Data;

public interface IServiceTypeRepository
{
    Task<ServiceType> Create(ServiceType service);

    Task<ServiceType?> FindById(Guid id);
    Task<ServiceType?> FindByIdWithItens(Guid id);

    Task<List<ServiceType>> FindByThirdParty(Guid thirdPartyId);

    Task<List<ServiceType>> GetAvaibleServices();
}
