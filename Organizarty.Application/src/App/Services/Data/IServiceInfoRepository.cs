using Organizarty.Application.App.Services.Entities;

namespace Organizarty.Application.App.Services.Data;

public interface IServiceInfoRepository
{
    Task<ServiceInfo> Create(ServiceInfo service);
    Task<ServiceInfo> Update(ServiceInfo service);

    Task<ServiceInfo?> FindByIdWithParent(string id);
    Task<ServiceInfo?> FindById(string id);
}
