using Organizarty.Application.App.Services.Entities;

namespace Organizarty.Application.App.Services.Data;

public interface IServiceInfoRepository
{
    Task<ServiceInfo> Create(ServiceInfo service);

    Task<ServiceInfo?> FindByIdWithParent(Guid id);
}
